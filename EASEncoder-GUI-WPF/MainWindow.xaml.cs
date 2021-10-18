using EASEncoder.Models.SAME;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using EASEncoder.Models;
using NAudio.Wave;
using MaterialDesignThemes.Wpf;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.Serialization;
using Polenter.Serialization;
using System.IO.Compression;

namespace EASEncoder_GUI_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Serializable]
    public partial class MainWindow : Window
    {
        private List<SAMERegion> Regions = new List<SAMERegion>();
        private string _length;
        private SAMEMessageAlertCode _selectedAlertCode;
        private SAMECounty _selectedCounty;
        private SAMEMessageOriginator _selectedOriginator;
        private SAMEState _selectedState;
        //private SAMESubdivision _selectedSubdivision;
        private string _senderId;
        private DateTime _start;
        //private WaveOutEvent player;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer volumeTimer = new System.Windows.Forms.Timer();

        /// <summary>
        /// File extension for EAS Encoder documents
        /// </summary>
        string EAS_FileExtension = "easf";

        /// <summary>
        /// Filter for SaveFileDialog / OpenFileDialog (EAS File Extension)
        /// </summary>
        string EAS_FileDialogFilterString; //Assigned later

        SaveFileDialog saveAlertFileDialog = new SaveFileDialog();
        SaveFileDialog saveAudioOutputFileDialog = new SaveFileDialog();
        OpenFileDialog loadAlertFileDialog = new OpenFileDialog();

        public MainWindow()
        {
            EAS_FileDialogFilterString = "EAS Encoder Document|*." + EAS_FileExtension;
            saveAudioOutputFileDialog.Filter = "Lossless Audio File|*.wav";

            InitializeComponent();
            //string[] alertCodes = MessageTypes.AlertCodes.OrderBy(x => x.Name).Select(x => x.Name).ToArray();
            //string[] originators = MessageTypes.Originators.OrderBy(x => x.Name).Select(x => x.Name).ToArray();
            timer.Tick += Timer_Tick;
            timer.Interval = 500;
            timer.Enabled = false;
            volumeTimer.Tick += VolumeTimer_Tick;
            volumeTimer.Interval = 1;
            volumeTimer.Enabled = true;
            preview_PositionScrollBar.MouseDown += Preview_PositionScrollBar_MouseDown;
            preview_PositionScrollBar.MouseUp += Preview_PositionScrollBar_MouseUp;
            MessageTypes.AlertCodes.OrderBy(x => x.Name).Select(x => x.Name).ToArray().ToList().ForEach(item => comboCode.Items.Add(item));
            MessageTypes.Originators.OrderBy(x => x.Name).Select(x => x.Name).ToArray().ToList().ForEach(item => comboOriginator.Items.Add(item));
            MessageRegions.States.OrderBy(x => x.Name).Select(x => x.Name).ToArray().ToList().ForEach(item => state_SelectionComboBox.Items.Add(item));

            for (int x = 0; x <= 99; x++)
            {
                if (x <= 60)
                {
                    comboBox_durationInMinutes.Items.Add(x.ToString());
                }
                comboBox_durationInHours.Items.Add(x.ToString());
            }
            comboBox_durationInHours.SelectedIndex = 1;
            comboBox_durationInMinutes.SelectedIndex = 0;

            saveAlertFileDialog.Title = "Save Alert file";
            loadAlertFileDialog.Title = "Load Alert file";
            saveAlertFileDialog.DefaultExt = EAS_FileExtension;
            saveAlertFileDialog.Filter = EAS_FileDialogFilterString;
            loadAlertFileDialog.Filter = EAS_FileDialogFilterString;

            preview_MediaElement.MediaEnded += Preview_MediaElement_MediaEnded;
            button_dismissPreview.Click += Button_dismissPreview_Click;
            appMenu_newAlert.Click += AppMenu_newAlert_Click;
            InitializeAlertProject();
        }

        private void AppMenu_newAlert_Click(object sender, RoutedEventArgs e)
        {
            InitializeAlertProject();
        }

        void InitializeAlertProject()
        {
            alertStart_TimePicker.SelectedTime = null;
            alertStart_DatePicker.SelectedDate = null;
            comboOriginator.SelectedIndex = -1;
            comboCode.SelectedIndex = -1;
            Regions = new List<SAMERegion>();
            comboBox_durationInHours.SelectedIndex = 1;
            comboBox_durationInMinutes.SelectedIndex = 0;
            txtSender.Text = "12345678";
            chkEbsTones.IsChecked = false;
            chkNwsTone.IsChecked = false;
            txtAnnouncement.Text = "";
            _selectedAlertCode = null;
            _selectedCounty = null;
            _selectedOriginator = null;
            _selectedState = null;
            _senderId = "";
            var bindingList = new BindingList<SAMERegion>(Regions);
            var source = new BindingSource(bindingList, null);
            datagridRegions.ItemsSource = source;
        }

        private void Button_dismissPreview_Click(object sender, RoutedEventArgs e)
        {
            DeleteTempFile();
        }

        void DeleteTempFile()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerAsync();
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "preview.wav");
            File.Delete(path);
        }

        private void Preview_MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            DeleteTempFile();
        }

        private void VolumeTimer_Tick(object sender, EventArgs e)
        {
            SyncPreviewPlaybackVolume();
        }

        private void Preview_PositionScrollBar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            timer.Enabled = true;
        }

        private void Preview_PositionScrollBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            timer.Enabled = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                preview_PositionScrollBar.Maximum = preview_MediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
                preview_PositionScrollBar.Value = preview_MediaElement.Position.TotalMilliseconds;
                TextBlock_ElapsedTime.Text = preview_MediaElement.Position.ToString(@"m\:ss");
                TextBlock_TotalTime.Text = preview_MediaElement.NaturalDuration.TimeSpan.ToString(@"m\:ss");
            }
            catch (Exception)
            {

            }
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void switch_DarkModeToggle_Checked(object sender, RoutedEventArgs e)
        {
            //PaletteHelper _paletteHelper = new PaletteHelper();
            //ITheme theme = _paletteHelper.GetTheme();
            //IBaseTheme baseTheme;
            //if ((bool)switch_DarkModeToggle.IsChecked)
            //{
            //    baseTheme = new MaterialDesignDarkTheme();
            //}
            //else
            //{
            //    baseTheme = new MaterialDesignLightTheme();
            //}
            //theme.SetBaseTheme(baseTheme);
            //_paletteHelper.SetTheme(theme);
        }

        private void state_SelectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedState = MessageRegions.States.FirstOrDefault(x => x.Name == e.AddedItems[0].ToString());
            if (_selectedState != null)
            {
                county_SelectionComboBox.Items.Clear();
                _selectedCounty = null;
                MessageRegions.Counties.Where(x => x.State.Id == _selectedState.Id).OrderBy(x => x.Name).ToArray().ToList().ForEach(item => county_SelectionComboBox.Items.Add(item.Name));
            }
            CheckIfAllLocationCombosArePopulated();
        }

        private void addLocationButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreAllLocationCombosPopulated())
            {
                if (!addItemDialog_menu_checkBox_keepDialogOpen.IsChecked)
                {
                    dialogHost_AddNewItem.IsOpen = false;
                }
                try
                {
                    _selectedCounty = MessageRegions.Counties.FirstOrDefault(x => x.State.Id == _selectedState.Id && x.Name == county_SelectionComboBox.Text);
                    if (state_SelectionComboBox.SelectedIndex >= 0 && county_SelectionComboBox.SelectedIndex >= 0 && !Regions.Exists(x => x.County.Id == _selectedCounty.Id && x.State.Id == _selectedState.Id))
                    {
                        label_stateNotSelectedError.Visibility = Visibility.Hidden;
                        label_countyNotSelectedError.Visibility = Visibility.Hidden;
                        Regions.Add(new SAMERegion(_selectedState, _selectedCounty));
                        var bindingList = new BindingList<SAMERegion>(Regions);
                        var source = new BindingSource(bindingList, null);
                        datagridRegions.ItemsSource = source;

                        county_SelectionComboBox.SelectedIndex = -1;
                        _selectedCounty = null;
                    }
                }
                catch (Exception)
                {
                    CheckIfAllLocationCombosArePopulated();
                    CheckIfTimeRangesAreSelected();
                }
            }
            else
            {
                CheckIfAllLocationCombosArePopulated();
                CheckIfTimeRangesAreSelected();
            }
        }

        void CheckIfAllLocationCombosArePopulated()
        {
            if (state_SelectionComboBox.SelectedIndex <= 0)
            {
                label_stateNotSelectedError.Visibility = Visibility.Visible;
            }
            else
            {
                label_stateNotSelectedError.Visibility = Visibility.Hidden;
            }
            if (county_SelectionComboBox.SelectedIndex <= 0)
            {
                label_countyNotSelectedError.Visibility = Visibility.Visible;
            }
            else
            {
                label_countyNotSelectedError.Visibility = Visibility.Hidden;
            }
        }

        bool AreAllLocationCombosPopulated()
        {
            if ((state_SelectionComboBox.SelectedIndex >= 0) && (county_SelectionComboBox.SelectedIndex >= 0))
            {
                return true;
            }
            else return false;
        }

        private void county_SelectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //_selectedCounty = MessageRegions.Counties.FirstOrDefault(x => x.State.Id == _selectedState.Id && x.Name == county_SelectionComboBox.Text);
            //try
            //{
            //    string[] strings = new string[e.AddedItems.Count];
            //    e.AddedItems.CopyTo(strings, e.AddedItems.Count);
            //
            //    _selectedCounty = MessageRegions.Counties.FirstOrDefault(x => x.State.Id == _selectedState.Id && x.Name == strings[0]);
            //}
            //catch
            //{
            //
            //}
        }

        private void county_SelectionComboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void deleteLocationButton_Click(object sender, RoutedEventArgs e)
        {
            if (datagridRegions.SelectedItems.Count > 0)
            {
                foreach (SAMERegion item in datagridRegions.SelectedItems)
                {
                    //DataGridCellInfo cellToRemove = cell;
                    //datagridRegions.Items.Remove(cellToRemove);
                    Regions.Remove(item);
                }
                //datagridRegions.Items.Remove(datagridRegions.SelectedItem);
                var bindingList = new BindingList<SAMERegion>(Regions);
                var source = new BindingSource(bindingList, null);
                datagridRegions.ItemsSource = source;
            }
        }

        void ExportAudio(string output_path)
        {
            DateTime startI = (DateTime)alertStart_DatePicker.SelectedDate;
            startI.AddHours(alertStart_TimePicker.SelectedTime.Value.Hour);
            startI.AddMinutes(alertStart_TimePicker.SelectedTime.Value.Minute);
            _start = startI.ToUniversalTime();
            _senderId = txtSender.Text;
            _length = ZeroPad(comboBox_durationInHours.Text, 2) + ZeroPad(comboBox_durationInMinutes.Text, 2);
            _selectedOriginator = MessageTypes.Originators.FirstOrDefault(y => y.Name == comboOriginator.Text);
            _selectedAlertCode = MessageTypes.AlertCodes.FirstOrDefault(y => y.Name == comboCode.Text);
            var newMessage = new EASMessage(_selectedOriginator.Id, _selectedAlertCode.Id, Regions, _length, _start, _senderId);

            MemoryStream audioStream = EASEncoder.EASEncoder.GetMemoryStreamFromNewMessage(newMessage, (bool)chkEbsTones.IsChecked, (bool)chkNwsTone.IsChecked, formatAnnouncement(txtAnnouncement.Text));
            
            FileStream faudio_stream = new FileStream(output_path, FileMode.OpenOrCreate);
            audioStream.WriteTo(faudio_stream);
            faudio_stream.Close();
            audioStream.Close();
        }

        private void button_previewAlertAudio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "preview.wav");
                ExportAudio(path);
                dialogHost_PreviewWindow.IsOpen = true;
                preview_MediaElement.Source = new Uri(path);
                timer.Enabled = true;
                preview_MediaElement.LoadedBehavior = MediaState.Play; //Theoretically, this should make the MediaElement autoplay when it loads the file
                //preview_MediaElement.Play();
            }
            catch (Exception)
            {
                CheckIfTimeRangesAreSelected();
                dialogHost_PreviewWindow.IsOpen = false;
            }
        }

        void CheckIfTimeRangesAreSelected()
        {
            if ((!(alertStart_DatePicker.SelectedDate.HasValue)) || (!(alertStart_TimePicker.SelectedTime.HasValue)))
            {
                label_alertStartsTimeDateSelectionRequiredError.Visibility = Visibility.Visible;
            }
            if ((!(comboBox_durationInHours.SelectedIndex == -1)) || (!(comboBox_durationInMinutes.SelectedIndex == -1)))
            {
                label_alertValidForSelectionRequiredError.Visibility = Visibility.Visible;
            }
        }

        bool AreTimeRangesSelected()
        {
            if (((!(comboBox_durationInHours.SelectedIndex == -1)) || (!(comboBox_durationInMinutes.SelectedIndex == -1))) && (!(comboBox_durationInHours.SelectedIndex == -1)) || (!(comboBox_durationInMinutes.SelectedIndex == -1)))
            {
                return false;
            }
            else return true;
        }

        void SyncPreviewPlaybackVolume()
        {
            try
            {
                preview_MediaElement.Volume = preview_VolumeScrollBar.Value / 100;
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Convert announcement text into speakable text (expand abbreviations)
        /// </summary>
        private string formatAnnouncement(string announcement)
        {
            return
                announcement.Replace("*", "")
                    .Replace("\r\n", " ")
                    .ToLower()
                    .Replace(" cdt", "central daylight time")
                    .Replace(" cst", "central standard time")
                    .Replace(" edt", "eastern daylight time")
                    .Replace(" est", "eastern standard time")
                    .Replace(" mdt", "mountain daylight time")
                    .Replace(" mst", "moutain standard time")
                    .Replace(" pdt", "pacific daylight time")
                    .Replace(" pst", "pacific standard time")
                    .Replace(" mph", "miles per hour")
                    .Replace(" winds", "whinds")
                    .Replace("  ", " ")
                    .Replace("...", ", ")
                    .Replace("precautionary/preparedness actions", "")
                    .ToLower();
        }

        internal string ZeroPad(string String, int Length)
        {
            if (string.IsNullOrEmpty(String))
            {
                String = "0";
            }
            if (String.Length > Length)
            {
                return String;
            }

            while (String.Length < Length)
            {
                String = "0" + String;
            }

            return String;
        }

        private void preview_VolumeScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SyncPreviewPlaybackVolume();
        }

        private void comboOriginator_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void preview_PositionScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                preview_MediaElement.Position = TimeSpan.FromMilliseconds(preview_PositionScrollBar.Value);
            }
            catch (Exception)
            {

            }
        }

        private void addItemDialog_menuButton_addWholeState_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //_selectedCounty = MessageRegions.Counties.FirstOrDefault(x => x.State.Id == _selectedState.Id && x.Name == county_SelectionComboBox.Text);
                if (state_SelectionComboBox.SelectedIndex >= 0)
                {
                    dialogHost_AddNewItem.IsOpen = false;
                    label_stateNotSelectedError.Visibility = Visibility.Hidden;
                    label_countyNotSelectedError.Visibility = Visibility.Hidden;
                    MessageRegions.Counties.Where(x => x.State.Id == _selectedState.Id).OrderBy(x => x.Name).ToArray().ToList().ForEach(item =>
                    {
                        Regions.Add(new SAMERegion(_selectedState, item));
                        var bindingList = new BindingList<SAMERegion>(Regions);
                        var source = new BindingSource(bindingList, null);
                        datagridRegions.ItemsSource = source;
                    });
                }
                else
                {
                    label_stateNotSelectedError.Visibility = Visibility.Visible;
                    label_countyNotSelectedError.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception)
            {
                //CheckIfAllLocationCombosArePopulated();
            }
        }

        private void addItemDialog_menuButton_addTheWorld_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dialogHost_AddNewItem.IsOpen = false;
                label_stateNotSelectedError.Visibility = Visibility.Hidden;
                label_countyNotSelectedError.Visibility = Visibility.Hidden;
                MessageRegions.States.ToArray().ToList().ForEach(state =>
                {
                    MessageRegions.Counties.Where(x => x.State.Id == state.Id).OrderBy(x => x.Name).ToArray().ToList().ForEach(county =>
                    {
                        Regions.Add(new SAMERegion(state, county));
                        var bindingList = new BindingList<SAMERegion>(Regions);
                        var source = new BindingSource(bindingList, null);
                        datagridRegions.ItemsSource = source;
                    });
                });
            }
            catch (Exception)
            {
                //CheckIfAllLocationCombosArePopulated();
            }
        }

        private void appMenu_Exit_Click(object sender, RoutedEventArgs e)
        {
            dialogHost_exitWithoutSaving.IsOpen = true;
        }

        private void exitDialog_Confirm_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void appMenu_saveAlertFile_Click(object sender, RoutedEventArgs e)
        {
            DialogResult result = saveAlertFileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                DirectoryInfo tempDir = Directory.CreateDirectory("temp");
                var serializer = new SharpSerializer();
                WriteToBinaryFile(System.IO.Path.Combine(tempDir.FullName, "regions"), Regions);
                CautiousSerialize(alertStart_TimePicker.SelectedTime, System.IO.Path.Combine(tempDir.FullName, "startTime"));
                CautiousSerialize(alertStart_DatePicker.SelectedDate, System.IO.Path.Combine(tempDir.FullName, "startDate"));
                CautiousSerialize(comboOriginator.SelectedIndex, System.IO.Path.Combine(tempDir.FullName, "id_originator"));
                CautiousSerialize(comboCode.SelectedIndex, System.IO.Path.Combine(tempDir.FullName, "id_code"));
                CautiousSerialize(alertStart_DatePicker.SelectedDate, System.IO.Path.Combine(tempDir.FullName, "startDate"));
                CautiousSerialize(alertStart_TimePicker.SelectedTime, System.IO.Path.Combine(tempDir.FullName, "startTime"));
                CautiousSerialize(comboBox_durationInHours.SelectedIndex, MakeFilename("dHours"));
                CautiousSerialize(comboBox_durationInMinutes.SelectedIndex, MakeFilename("dMinutes"));
                CautiousSerialize(txtSender.Text, MakeFilename("senderId"));
                CautiousSerialize(chkEbsTones.IsChecked, MakeFilename("ebsTones"));
                CautiousSerialize(chkNwsTone.IsChecked, MakeFilename("nwsTone"));
                CautiousSerialize(txtAnnouncement.Text, MakeFilename("message"));

                if (File.Exists(saveAlertFileDialog.FileName))
                {
                    File.Delete(saveAlertFileDialog.FileName);
                }
                ZipFile.CreateFromDirectory("temp", saveAlertFileDialog.FileName, CompressionLevel.NoCompression, false);
                DeleteTempDir();
            }
        }

        string MakeFilename(string filename)
        {
            DirectoryInfo tempDir = Directory.CreateDirectory("temp");
            return System.IO.Path.Combine(tempDir.FullName, filename);
        }

        private void appMenu_loadAlertFile_Click(object sender, RoutedEventArgs e)
        {
            //alertStart_TimePicker = ReadFromBinaryFile<TimePicker>("temp/startTime");
            if (loadAlertFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string tempDir = "temp/";
                DeleteTempDir(); //Just in case...
                ZipFile.ExtractToDirectory(loadAlertFileDialog.FileName, tempDir);
                var serializer = new SharpSerializer();
                alertStart_TimePicker.SelectedTime = (DateTime?)serializer.Deserialize(System.IO.Path.Combine(tempDir, "startTime"));
                alertStart_DatePicker.SelectedDate = (DateTime?)serializer.Deserialize(System.IO.Path.Combine(tempDir, "startDate"));
                comboOriginator.SelectedIndex = (int)serializer.Deserialize(System.IO.Path.Combine(tempDir, "id_originator"));
                comboCode.SelectedIndex = (int)serializer.Deserialize(System.IO.Path.Combine(tempDir, "id_code"));
                Regions = ReadFromBinaryFile<List<SAMERegion>>(System.IO.Path.Combine(tempDir, "regions"));
                comboBox_durationInHours.SelectedIndex = (int)serializer.Deserialize(MakeFilename("dHours"));
                comboBox_durationInMinutes.SelectedIndex = (int)serializer.Deserialize(MakeFilename("dMinutes"));
                txtSender.Text = (string)serializer.Deserialize(MakeFilename("senderId"));
                chkEbsTones.IsChecked = (bool)serializer.Deserialize(MakeFilename("ebsTones"));
                chkNwsTone.IsChecked = (bool)serializer.Deserialize(MakeFilename("nwsTone"));
                txtAnnouncement.Text = (string)serializer.Deserialize(MakeFilename("message"));
                var bindingList = new BindingList<SAMERegion>(Regions);
                var source = new BindingSource(bindingList, null);
                datagridRegions.ItemsSource = source;
                DeleteTempDir();
            }
        }

        void DeleteTempDir()
        {
            try
            {
                Directory.Delete("temp", true);
            }
            catch
            {

            }
        }

        private void appMenu_newAlert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_saveAlertToWaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (saveAudioOutputFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ExportAudio(saveAudioOutputFileDialog.FileName);
            }
        }

        void CautiousRun(Action method)
        {
            try
            {
                method();
            }
            catch
            {

            }
        }

        /// <summary>
        /// Serializer (Cautious: hides exception if serialization fails)
        /// </summary>
        void CautiousSerialize(object o, string path)
        {
            try
            {
                var serializer = new SharpSerializer();
                serializer.Serialize(o, path);
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Deserializer (Cautious: hides exception if deserialization fails)
        /// </summary>
        void CautiousDeserialize(object outTo, string path)
        {
            //try
            //{
            var serializer = new SharpSerializer();
            outTo = serializer.Deserialize(path);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        /// <summary>
        /// Writes the given object instance to a binary file.
        /// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
        /// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the XML file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the XML file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        /// <summary>
        /// Reads an object instance from a binary file.
        /// </summary>
        /// <remarks>Used for loading EAS Documents which are saved as raw binary files</remarks>
        /// <typeparam name="T">The type of object to read from the XML.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the binary file.</returns>
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        private void preview_MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            dialogHost_PreviewWindow.IsOpen = false;
        }

        private void appMenu_gSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            dialogHost_settings.IsOpen = true;
        }
    }
}