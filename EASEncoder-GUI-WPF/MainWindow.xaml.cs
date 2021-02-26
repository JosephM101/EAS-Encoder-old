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
        private WaveOutEvent player;

        public MainWindow()
        {
            InitializeComponent();
            //string[] alertCodes = MessageTypes.AlertCodes.OrderBy(x => x.Name).Select(x => x.Name).ToArray();
            //string[] originators = MessageTypes.Originators.OrderBy(x => x.Name).Select(x => x.Name).ToArray();

            MessageTypes.AlertCodes.OrderBy(x => x.Name).Select(x => x.Name).ToArray().ToList().ForEach(item => comboCode.Items.Add(item));
            MessageTypes.Originators.OrderBy(x => x.Name).Select(x => x.Name).ToArray().ToList().ForEach(item => comboOriginator.Items.Add(item));
            MessageRegions.States.OrderBy(x => x.Name).Select(x => x.Name).ToArray().ToList().ForEach(item => state_SelectionComboBox.Items.Add(item));
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
            if(datagridRegions.SelectedItems.Count > 0)
            {
                foreach(SAMERegion item in datagridRegions.SelectedItems)
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
    }
}