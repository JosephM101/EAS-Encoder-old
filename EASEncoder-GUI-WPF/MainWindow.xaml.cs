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

namespace EASEncoder_GUI_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<SAMERegion> Regions = new List<SAMERegion>();
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

        public MainWindow()
        {
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
            catch (Exception ex)
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
                dialogHost_AddNewItem.IsOpen = false;
                try
                {
                    _selectedCounty = MessageRegions.Counties.FirstOrDefault(x => x.State.Id == _selectedState.Id && x.Name == county_SelectionComboBox.Text);
                    if (state_SelectionComboBox.SelectedIndex >= 0 && county_SelectionComboBox.SelectedIndex >= 0 && !Regions.Exists(x => x.County.Id == _selectedCounty.Id && x.State.Id == _selectedState.Id))
                    //if (state_SelectionComboBox.SelectedIndex >= 0 && county_SelectionComboBox.SelectedIndex >= 0 && !Regions.Exists(x => x.County.Id == _selectedCounty.Id && x.State.Id == _selectedState.Id))
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
                catch (Exception ex)
                {
                    CheckIfAllLocationCombosArePopulated();
                }
            }
            else
            {
                CheckIfAllLocationCombosArePopulated();
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

        private void button_previewAlertAudio_Click(object sender, RoutedEventArgs e)
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
            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "temp.wav");
            FileStream faudio_stream = new FileStream(path, FileMode.OpenOrCreate);
            audioStream.WriteTo(faudio_stream);
            faudio_stream.Close();
            audioStream.Close();

            preview_MediaElement.Source = new Uri(path);
            timer.Enabled = true;
            preview_MediaElement.LoadedBehavior = MediaState.Play; //Theoretically, this should make the MediaElement autoplay when it loads the file
                                                                   //preview_MediaElement.Play();
        }

        void SyncPreviewPlaybackVolume()
        {
            try
            {
                preview_MediaElement.Volume = preview_VolumeScrollBar.Value / 100;
            }
            catch (Exception ex)
            {

            }
        }

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
            catch (Exception ex)
            {

            }
        }
    }
}