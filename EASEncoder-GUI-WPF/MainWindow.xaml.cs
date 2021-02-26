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
    }
}