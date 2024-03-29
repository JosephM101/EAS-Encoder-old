﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B3421FF33EDE5EFC9FD63B3261238AF024F148DAD906885EA0A9EF642D5F26C1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EASEncoder_GUI_WPF;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace EASEncoder_GUI_WPF {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton switch_DarkModeToggle;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost dialogHost_PreviewWindow;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement preview_MediaElement;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock_ElapsedTime;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider preview_PositionScrollBar;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock_TotalTime;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider preview_VolumeScrollBar;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_dismissPreview;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_previewAlertAudio;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_saveAlertToWaveFile;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Snackbar main_snackbar;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel sPanel;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox groupBox_alertIdentifier;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboOriginator;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSender;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboCode;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox groupBox_alertLocationAndTime;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.TimePicker alertStart_TimePicker;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker alertStart_DatePicker;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock label_alertStartsTimeDateSelectionRequiredError;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBox_durationInHours;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBox_durationInMinutes;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock label_alertValidForSelectionRequiredError;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagridRegions;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteLocationButton;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost dialogHost_AddNewItem;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox state_SelectionComboBox;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock label_stateNotSelectedError;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox county_SelectionComboBox;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock label_countyNotSelectedError;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem addItemDialog_menu_checkBox_keepDialogOpen;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addItemDialog_menuButton_addWholeState;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addItemDialog_menuButton_addTheWorld;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_dialogCancel;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_confirmAdd;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addLocationButton;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox groupBox_message;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAnnouncement;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox groupBox_toneSettings;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkEbsTones;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkNwsTone;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button appMenu_newAlert;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button appMenu_loadAlertFile;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button appMenu_saveAlertFile;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button appMenu_Exit;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost dialogHost_exitWithoutSaving;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitDialog_Ignore;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitDialog_Confirm;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost dialogHost_settings;
        
        #line default
        #line hidden
        
        
        #line 190 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox setting_normalizeAudioOutput;
        
        #line default
        #line hidden
        
        
        #line 194 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button settingsDialog_Cancel;
        
        #line default
        #line hidden
        
        
        #line 195 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button settingsDialog_Confirm;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EASEncoder-GUI-WPF;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.switch_DarkModeToggle = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 24 "..\..\MainWindow.xaml"
            this.switch_DarkModeToggle.Checked += new System.Windows.RoutedEventHandler(this.switch_DarkModeToggle_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dialogHost_PreviewWindow = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 4:
            this.preview_MediaElement = ((System.Windows.Controls.MediaElement)(target));
            
            #line 30 "..\..\MainWindow.xaml"
            this.preview_MediaElement.MediaEnded += new System.Windows.RoutedEventHandler(this.preview_MediaElement_MediaEnded);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TextBlock_ElapsedTime = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.preview_PositionScrollBar = ((System.Windows.Controls.Slider)(target));
            
            #line 34 "..\..\MainWindow.xaml"
            this.preview_PositionScrollBar.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.preview_PositionScrollBar_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TextBlock_TotalTime = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.preview_VolumeScrollBar = ((System.Windows.Controls.Slider)(target));
            
            #line 41 "..\..\MainWindow.xaml"
            this.preview_VolumeScrollBar.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.preview_VolumeScrollBar_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.button_dismissPreview = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.button_previewAlertAudio = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\MainWindow.xaml"
            this.button_previewAlertAudio.Click += new System.Windows.RoutedEventHandler(this.button_previewAlertAudio_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.button_saveAlertToWaveFile = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\MainWindow.xaml"
            this.button_saveAlertToWaveFile.Click += new System.Windows.RoutedEventHandler(this.button_saveAlertToWaveFile_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.main_snackbar = ((MaterialDesignThemes.Wpf.Snackbar)(target));
            return;
            case 13:
            this.sPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 14:
            this.groupBox_alertIdentifier = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 15:
            this.comboOriginator = ((System.Windows.Controls.ComboBox)(target));
            
            #line 65 "..\..\MainWindow.xaml"
            this.comboOriginator.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboOriginator_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 16:
            this.txtSender = ((System.Windows.Controls.TextBox)(target));
            return;
            case 17:
            this.comboCode = ((System.Windows.Controls.ComboBox)(target));
            
            #line 68 "..\..\MainWindow.xaml"
            this.comboCode.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboCode_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 18:
            this.groupBox_alertLocationAndTime = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 19:
            this.alertStart_TimePicker = ((MaterialDesignThemes.Wpf.TimePicker)(target));
            return;
            case 20:
            this.alertStart_DatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 21:
            this.label_alertStartsTimeDateSelectionRequiredError = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 22:
            this.comboBox_durationInHours = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 23:
            this.comboBox_durationInMinutes = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 24:
            this.label_alertValidForSelectionRequiredError = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 25:
            this.datagridRegions = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 26:
            this.deleteLocationButton = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\MainWindow.xaml"
            this.deleteLocationButton.Click += new System.Windows.RoutedEventHandler(this.deleteLocationButton_Click);
            
            #line default
            #line hidden
            return;
            case 27:
            this.dialogHost_AddNewItem = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 28:
            this.state_SelectionComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 101 "..\..\MainWindow.xaml"
            this.state_SelectionComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.state_SelectionComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 29:
            this.label_stateNotSelectedError = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 30:
            this.county_SelectionComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 105 "..\..\MainWindow.xaml"
            this.county_SelectionComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.county_SelectionComboBox_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 105 "..\..\MainWindow.xaml"
            this.county_SelectionComboBox.DataContextChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.county_SelectionComboBox_DataContextChanged);
            
            #line default
            #line hidden
            return;
            case 31:
            this.label_countyNotSelectedError = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 32:
            this.addItemDialog_menu_checkBox_keepDialogOpen = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 33:
            this.addItemDialog_menuButton_addWholeState = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\MainWindow.xaml"
            this.addItemDialog_menuButton_addWholeState.Click += new System.Windows.RoutedEventHandler(this.addItemDialog_menuButton_addWholeState_Click);
            
            #line default
            #line hidden
            return;
            case 34:
            this.addItemDialog_menuButton_addTheWorld = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\MainWindow.xaml"
            this.addItemDialog_menuButton_addTheWorld.Click += new System.Windows.RoutedEventHandler(this.addItemDialog_menuButton_addTheWorld_Click);
            
            #line default
            #line hidden
            return;
            case 35:
            this.button_dialogCancel = ((System.Windows.Controls.Button)(target));
            return;
            case 36:
            this.button_confirmAdd = ((System.Windows.Controls.Button)(target));
            
            #line 118 "..\..\MainWindow.xaml"
            this.button_confirmAdd.Click += new System.Windows.RoutedEventHandler(this.addLocationButton_Click);
            
            #line default
            #line hidden
            return;
            case 37:
            this.addLocationButton = ((System.Windows.Controls.Button)(target));
            return;
            case 38:
            this.groupBox_message = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 39:
            this.txtAnnouncement = ((System.Windows.Controls.TextBox)(target));
            
            #line 133 "..\..\MainWindow.xaml"
            this.txtAnnouncement.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textBox1_TextChanged);
            
            #line default
            #line hidden
            return;
            case 40:
            this.groupBox_toneSettings = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 41:
            this.chkEbsTones = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 42:
            this.chkNwsTone = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 43:
            this.appMenu_newAlert = ((System.Windows.Controls.Button)(target));
            
            #line 149 "..\..\MainWindow.xaml"
            this.appMenu_newAlert.Click += new System.Windows.RoutedEventHandler(this.appMenu_newAlert_Click);
            
            #line default
            #line hidden
            return;
            case 44:
            this.appMenu_loadAlertFile = ((System.Windows.Controls.Button)(target));
            
            #line 150 "..\..\MainWindow.xaml"
            this.appMenu_loadAlertFile.Click += new System.Windows.RoutedEventHandler(this.appMenu_loadAlertFile_Click);
            
            #line default
            #line hidden
            return;
            case 45:
            this.appMenu_saveAlertFile = ((System.Windows.Controls.Button)(target));
            
            #line 151 "..\..\MainWindow.xaml"
            this.appMenu_saveAlertFile.Click += new System.Windows.RoutedEventHandler(this.appMenu_saveAlertFile_Click);
            
            #line default
            #line hidden
            return;
            case 46:
            this.appMenu_Exit = ((System.Windows.Controls.Button)(target));
            
            #line 155 "..\..\MainWindow.xaml"
            this.appMenu_Exit.Click += new System.Windows.RoutedEventHandler(this.appMenu_Exit_Click);
            
            #line default
            #line hidden
            return;
            case 47:
            this.dialogHost_exitWithoutSaving = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 48:
            this.exitDialog_Ignore = ((System.Windows.Controls.Button)(target));
            return;
            case 49:
            this.exitDialog_Confirm = ((System.Windows.Controls.Button)(target));
            
            #line 176 "..\..\MainWindow.xaml"
            this.exitDialog_Confirm.Click += new System.Windows.RoutedEventHandler(this.exitDialog_Confirm_Click);
            
            #line default
            #line hidden
            return;
            case 50:
            this.dialogHost_settings = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 51:
            this.setting_normalizeAudioOutput = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 52:
            this.settingsDialog_Cancel = ((System.Windows.Controls.Button)(target));
            return;
            case 53:
            this.settingsDialog_Confirm = ((System.Windows.Controls.Button)(target));
            
            #line 195 "..\..\MainWindow.xaml"
            this.settingsDialog_Confirm.Click += new System.Windows.RoutedEventHandler(this.exitDialog_Confirm_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

