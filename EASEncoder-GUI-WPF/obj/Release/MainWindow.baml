   M S B A M L   `   `   `  ���� M  IEASEncoder-GUI-WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:EASEncoder_GUI_WPFEASEncoder_GUI_WPF  #    EASEncoder_GUI_WPF.MainWindow   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:EASEncoder_GUI_WPF        MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � Title$ EAS Encoder��$	��720��$��946.4��$	��920��$	��720��.��� .+�)  #MaterialDesignThemes.Wpf.DialogHost  -     Name$" dialogHost_exitWithoutSaving��   CloseOnClickAway .    DialogContent ��  �� Orientation$ Vertical=�$
��Left=�$��8,16,8,4q�.+��� $ 
Horizontal=�$��Center=�$��Bottom=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Warning=�$��32��$��32��$��8,0,0,0q��� $��16,0,8,0q�.+��� $��Exit?��$��18(�$��Center=�$
��auto��$
��Wrap=�$��0,6,0,8q��� $F��@Are you sure you want to exit? Any unsaved changes will be lost.��$��Center=�$��0,0,8,0q�$	��256��$
��Wrap=��� $ 
Horizontal=�$��Right=�$��Bottom=�.+��� -    ��Name$ exitDialog_Ignore��$��NO��$��4q�  MaterialDesignFlatButton#��[ 	   CloseDialogCommand#��Z	 �� -   $ exitDialog_Confirm��$	��YES��$��4q�#��[ ]� $��Bottom=�.+��� $ 
Horizontal=�$��Bottom=�$��Right=�.+��� $ 
Horizontal=�$��Right=�$��Right=�$��Center=�$��0,0,16,8q�$y�	Collapsed=�.+��� -   
 ��Name$
 label��$��	Dark mode��$��Center=�$��Right=�$��Right=�$��0,1,8,0q�d� -    d�Name$ switch_DarkModeToggle�� $  MaterialDesignSwitchToggleButton#��[  d� 	IsChecked$ FalseY�$��Center=�$��Right=�$��Right=��� $��Bottom=�$��Right=�$	��Top=�$ 
Horizontal=�$
��auto��$��0,0,8,8q�.+�  -   $ dialogHost_PreviewWindow�� .  �� $ Vertical=�$
��Left=�$��8,8,8,8q�.+�r� -    r�Name$ preview_MediaElement���� $ Vertical=�.+��� $ 
Horizontal=�$��Center=�$��4,0,4,0q�.+��� -    ��Name$ TextBlock_ElapsedTime��$
��0:00��$��Center=��� -	    ��Name$ preview_PositionScrollBar��$	��300�� � Minimum$ 0Q� � Maximum$	 100Q�$��8,8,8,8q��� -
   $ TextBlock_TotalTime��$
��0:00��$��Center=�� .+��� $ 
Horizontal=�$
��Left=�.+�  $ 	VolumeLow=�$	��0,5q��� -   $ preview_VolumeScrollBar��$	��100��$ 0Q�$	 100Q� �� TickFrequency$ 10Q� �� TickPlacement$ BottomRight=� � Value$ 50Q�$��4q�  $ 
VolumeHigh=�$	��0,5q��� $ 
Horizontal=�$��Right=�$��Bottom=�.+��� -   $ button_dismissPreview��$��Dismiss��#��Z	 $��0,4,0,0q�#��[ .���� -   $ button_previewAlertAudio��$��PREVIEW AUDIO��$
��auto��$��0,0,4,0q��� -   $  button_saveAlertToWaveFile��$��GENERATE & SAVE WAV��$
��auto��$��4,0,0,0q�'  !MaterialDesignThemes.Wpf.Snackbar  -     Name$ main_snackbar��$��Stretch=�$
��auto��$��Stretch=�� $��4,70,-1.4,0q���. $��Visible=�.+��� -    ��Name$ sPanel��$ 
Horizontal=�$
��auto��.+��� $ Vertical=�$
��auto��$��8,0,0,0q�$��Stretch=�.+��� -    ��Name$ groupBox_alertIdentifier��$$��Alert Identifier Configuration��$��Stretch=�$
��auto��$��0q�$	��Top=�$
��auto��  MaterialDesignCardGroupBox#���  .���� $ Vertical=�.+��� $ 
Horizontal=�.+��� -    ��Name$ comboOriginator��   MaterialDesignFilledComboBox#��[ $
��Left=�$��0,0,0,0q�$	��Top=�$	��283��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Originator���� -    ��Name$ 	txtSender��  MaterialDesignFilledTextBox#��[ $
��Left=�$
��auto��$��16,0,0,0q� �� TextWrapping$
 Wrap=�$��12345678��$	��Top=�$	��150��$ Sender ID (8 chars)�� �� 	MaxLength$ 8���� -   $ 	comboCode��#��[ $
��Left=�$��0,12,0,0q�$	��Top=�$	��283��$ 
Alert Code�� J� RenderTransformOrigin$ 0.508,0.436&��� -   $# groupBox_alertLocationAndTime��$��Alert Location(s) & Time��$��0,8,0,0q�$	��506��#���  $��Stretch=�$��Stretch=�$	��397��.���� $ Vertical=� �� CanVerticallyScroll . $��Stretch=�.+��� $ 
Horizontal=�$
��Left=�$
��auto��$��0,4,0,0q�$	��Top=�$
��auto��$ 0.495,0.563&�.+��� $��Alert starts:��$��0,0,8,0q�$��90��$��Right=�)  #MaterialDesignThemes.Wpf.TimePicker  -     Name$ alertStart_TimePicker��$
��Left=�$��0,0,0,0q�$	��Top=�$	��110��$��50��$ Choose time��(  "System.Windows.Controls.DatePicker  -      Name$  alertStart_DatePicker��$
��Left=�$��16,0,0,0q�$	��Top=�$	��110��$��50��$ Choose date���� -   $5 /label_alertStartsTimeDateSelectionRequiredError��$ ��These fields are required.��
���  ��$��10(�$��Roboto Medium)�$��8,2,0,0q�$y�Hidden=�$��Center=��� $
��Left=�$
��auto��$��0,4,0,0q�$	��Top=�$
��auto��$ 0.495,0.563&�! �� CanHorizontallyScroll! . $ 
Horizontal=�.+��� $��
Valid for:��$��0,0,8,0q�$��90��$��Right=��� -   $ comboBox_durationInHours��$
��Left=�$��0,0,0,0q�$	��Top=�$
��auto��$��50��$ Hours���� $�� hour(s) and��$��0,0,0,0q�$
��auto���� -   $  comboBox_durationInMinutes��$
��Left=�$��8,0,0,0q�$	��Top=�$
��auto��$��50��$ Minutes���� $��
 minute(s)��$��0,0,0,0q�$
��auto���� -   $/ )label_alertValidForSelectionRequiredError��$ ��These fields are required.��
���  ��$��10(�$��Roboto Medium)�$��8,2,0,0q�$y�Hidden=�$��Center=��� $��8,16,0,0q�.��Event Locations� $	��240��$ 0.5,0.5&�$��Stretch=�.+�&   System.Windows.Controls.DataGrid  -   "  Name$" datagridRegions��$��8,4,8,0q����	#FF373737$
��auto��$��Stretch=�$��Stretch=�# J� Effect# 3	  -System.Windows.Media.Effects.DropShadowEffect	  $ 	  	Direction$	$ 270Q�% 	  Opacity$	% 0.4Q�& 	  ShadowDepth$& 5Q�' 	  
BlurRadius$' 8Q�#
  MaterialDesignThemes.Wpf.Card
  $��Right=�$��0,8,8,0q�$��Bottom=�$ 0.507,1.138&�.���� $��Right=�$ 
Horizontal=�.+��� -   $ deleteLocationButton�� & "MaterialDesignToolForegroundButton#���  $��30��$��30��$��0,0,0,0q�$��Center=�$��Center=���0  *MaterialDesignThemes.Wpf.PackIconExtension  (   Kind$( Minus=�)   Size$) 20X�  -   $ dialogHost_AddNewItem�� .  �� $ Vertical=�$
��Left=�$��8,12,8,4q�.+��� $ Vertical=�.+��� -   $��state_SelectionComboBox�� &	 "MaterialDesignFloatingHintComboBox#��[	 $ State��$
��auto��$	��8,0q��� -    $! label_stateNotSelectedError��$��Please select state.��
���  ��$��10(�$��Roboto Medium)�$��8,2,0,0q�$y�Hidden=��� $ Vertical=�.+��� -!   $��county_SelectionComboBox��#��[	 $ County��$
��auto��$	��8,0q��� -"   $" label_countyNotSelectedError��$��Please select county.��
���  ��$��10(�$��Roboto Medium)�$��8,2,0,0q�$y�Hidden=��� $ 
Horizontal=�$��Center=�$��Bottom=�.+�'  !MaterialDesignThemes.Wpf.PopupBox  *   	StaysOpen* .  +   PopupContent.+ �� .+�m� -#   , m�Name$0, *addItemDialog_menu_checkBox_keepDialogOpen��$��Keep dialog open��- m� IsCheckable- . �� �� -$   $, &addItemDialog_menuButton_addWholeState��$��Add the whole state���� -%   $* $addItemDialog_menuButton_addTheWorld��$��Add the world!���� -&   $ button_dialogCancel��$��CANCEL��#��Z	 $��4q�#��[ �� -'   $ button_confirmAdd��$	��ADD��$��4q�#��[ .���� -(   $ addLocationButton��#���  $��30��$��30��$��0,0,0,0q�$��Center=�$��Center=�.   OpenDialogCommand#��Z. ��  $	( Add=�$) 20X��� $ Vertical=�$
��auto��$��8,0,0,0q�.+��� -)   $ groupBox_message��$��Message��$
��Left=�$��0q�$	��400��#���  $
 0, 0&�$	��429��.��� $
��auto��$	��Top=�$
��auto��.+��� -*   $ txtAnnouncement��$��Stretch=�$��Stretch=�$
��auto��$
 Wrap=�$
��auto��"/ �� VerticalScrollBarVisibility$
/ Auto=�$ Message��0 �� AcceptsReturn0 . �� -+   $ groupBox_toneSettings��$��Tone Settings��$
��Left=�$��0,8,0,0q�$	��400��#���  $
 0, 0&�$	��104��.���� $ Vertical=�.+��� -,   1 ��Name$1 chkEbsTones��$!��Include EBS Attention Tones��$��4q��� --   $1 
chkNwsTone��$ ��Include NWS Attention Tone��$��4q�(  "MaterialDesignThemes.Wpf.ColorZone  2   Mode$2 PrimaryDark=�$��16q�3   CornerRadius$3 2��+  %MaterialDesignThemes.Wpf.ShadowAssist4   ShadowDepth$4 Depth5=�}�.  $��2,2,2,0q�$��64��.���� $ 
Horizontal=�.+�  * .  .+ �� .+��� -.   $ appMenu_newAlert��$	��New���� -/   $ appMenu_loadAlertFile��$��Load alert file���� -0   $ appMenu_saveAlertFile��$��Save alert file���� �� -1   $ appMenu_Exit��$
��Exit���� $��Center=�$��16 0 0 0q�$��18(�$��Center=�5 �� Padding$5 0,2,0,0q��� $�EAS Encoder��