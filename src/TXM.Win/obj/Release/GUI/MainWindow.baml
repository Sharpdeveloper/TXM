   M S B A M L   `   `   `  ����   TXM    TXM.GUI.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  TXM - The Tournament App��$	��650��$	��725�� � WindowState$ 	Maximized=�.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��2* � � ColumnDefinitions �� $��4* ��� $	��5px ��� $��3* ��� $��150px �.+�o� $��18��$	��Top=�$��0��$��4��.@�m� -    m�Name$ MenuItemFile��$
��File��.@�m� -   $ ButtonNewTournament��$��New Tournament��m� -   $ 
ButtonLoad��$
��Load��m� -   $ MenuItemSave��$
��Save��{�.  m� -   $ MenuItemAutosave��$��Autosave Files��.@�m� -   $ ButtonAutosave��$��Load Autosave Files��m� -   $  MenuItemShowAutoSaveFolder��$��Show Autosave Folder��m� -   $" MenuItemDeleteAutosaveFolder��$��Delete Autosave Folder��m� -	   $ MenuItemImportExport��$��Import/Export��.@�m� -
   $ ButtonGOEPPImport��$��	T3 Import��m� -   $ MenuItemCSVImport��$��Excel (CSV) Import��m� -   $ ButtonGOEPPExport��$��	T3 Export��{�.  m� -   $ MenuItemPrintHeader��$��Print��.@�m� -   $ MenuItemPrint��$��Print Table��m� -   $ MenuItemPrintPairing��$&�� Print Pairings (without Results)��m� -   $ MenuItemPrintResult��$#��Print Pairings (with Results)��m� -   $$ MenuItemPrintPairingScoreSheet��$$��Print Pairing with Score Sheet��m� -   $ MenuItemExit��$
��Quit��m� -   $ MenuItemTournament��$��
Tournament��.@�m� -   $ MenuItemChangePairing��$��Change Pairings��{�.  m� -   $ MenuItemResetLastResults��$��Reset Last Results��{�.  m� -   $ MenuItemTSettings��$��Change Tournamentsettings��{�.  m� -   $ ButtonEndTournament��$ ��Calculate SoS for Won Byes��{�. m� -   $ MenuItemBonusPoints��$��Award Bonus Points��{�. m� -   $ MenuItemPlayerManagement��$��Playermanagement��.@�m� -   $ MenuItemNewPlayer��$��Create new Player��{�.  m� -   $ MenuItemEditPlayer��$��Edit Player��{�.  m� -   $ MenuItemRemovePlayer��$��Delete/Drop Player��{�.  m� -   $ MenuItemDisqualifyPlayer��$��Disqualify Player��{�.  m� -   $ MenuItemView��$
��View��.@�m� -   $ MenuItemShowPairings��$��Show Pairings��m� -    $ MenuItemShowTable��$��
Show Table��m� -!   $ MenuItemBBCode��$��Get BBCode for Forum��m� -"   $ MenuItemRefreshPlayerList��$��Refresh Player List��m� -#   $! MenuItemRefreshPairingsList��$��Refresh Pairings List��m� -$   $ MenuItemTools��$��Tools��.@�m� -%   $ MenuItemTimer��$��Timer��m� -&   $ MenuItemHelp��$
��Help��.@�m� -'   $ MenuItemUserHelp��$��User Manual (online)��m� -(   $ MenuItemAbout��$��	About TXM��c� $��1��$��0��$��4��.@��� -)    ��Name$ ButtonGetResults��{�.  $��Start Tournament�� � ToolTip$ Start Tournament���� -*   $ 	ButtonCut��{�.  $��	Start Cut��$ 	Start Cut���� �� $��Rounds���� -+    ��Name$ ComboBoxRounds�� �� Text$ Rounds��$ Rounds���� �� -,   $ 
ButtonSave��$
 Save��{�.  .���� $3��-pack://application:,,,/Resources/Save-100.png��$��25��$��25���� --   $ ButtonNewPlayer��$ Create new Player��{�.  .���� $7��1pack://application:,,,/Resources/Add User-100.png��$��25��$��25���� -.   $ ButtonEditPlayer��$ Edit Player��{�.  .���� $8��2pack://application:,,,/Resources/Edit User-100.png��$��25��$��25���� -/   $ ButtonRemovePlayer��$ Delete/Drop Player��{�.  .���� $:��4pack://application:,,,/Resources/Remove User-100.png��$��25��$��25���� -0   $ ButtonDisqualifyPlayer��$ Disqualify Player��{�.  .���� $<��6pack://application:,,,/Resources/Unfriend Male-100.png��$��25��$��25���� -1   $ ButtonChangePairing��$ Change Pairings��{�.  .���� $9��3pack://application:,,,/Resources/User Group-100.png��$��25��$��25���� -2   $ ButtonResetLastResults��$ Reset last results��{�.  .���� $:��4pack://application:,,,/Resources/Rotate Left-100.png��$��25��$��25���� -3   $ ButtonTimer��$ Timer��.���� $4��.pack://application:,,,/Resources/Watch-100.png��$��25��$��25��� $��2��$��0��.+�&   System.Windows.Controls.DataGrid  -4   	  Name$	 DataGridPlayer��
   AutoGenerateColumns
 .  ��. $
��Auto=�$
��Auto=��� $��1��$��2��$��5��$��Stretch=�� $��2��$��2��.+�  -5   $	 DataGridPairing��
 .  ��. $
��Auto=�$
��Auto=�   CanUserAddRows .  � $��3��$��2��.+��� -6    ��Name$ 	LabelTime��$��MM:SS��$	��Top=�$��40��$��20(�$��0,0,0,0q�$��Center=��� -7   $ ButtonStartTimer��$��Start��$ Start��$	��Top=�$��0,40,0,0q�$��20���� -8   $ ButtonPause��$��Pause��$ Pause��$	��Top=�$��0,60,0,0q�$��20���� -9   $ ButtonReset��$��Reset��$ Reset��$	��Top=�$��0,80,0,0q�$��20���� -:   $ ButtonSetImage��$��	Set Image��$ 	Set Image��$	��Top=�$��	0,100,0,0q�$��20���� -;    ��Name$ TextBoxTime��$�� ��$	��Top=�$
��Left=�$��	0,120,0,0q�$��20��$	��120���� $	��Min��$	��Top=�$��Right=�$��	0,117,0,0q�$��25��$��30���� -<    ��Name$ 
SliderText��$��Center=�$��
0,140,0,22q�$��20��$	��Top=� � Maximum$ 2Q� � Minimum$ 1Q� � SmallChange$ 1Q�$��50���� -=   $ LabelWhiteText��$��White��$
��Left=�$��	0,137,0,0q�$��25��$	��Top=��� ->   $ LabelBlackText��$��Black��$��Right=�$��	0,137,0,0q�$��25��$	��Top=��� -?   $ 
SliderSize��$��Center=�$��
0,160,0,22q�$��20��$	��Top=�$	 100Q�$ 1Q�$ 1Q�$��75���� -@   $ 
LabelSmall��$��Small��$
��Left=�$��	0,157,0,0q�$��25��$	��Top=��� -A   $ LabelBig��$��Large��$��Right=�$��	0,157,0,0q�$��25��$	��Top=��� -B   $ LabelTimerStart��$��Start Timer at��$
��Left=�$��	0,180,0,0q�$��25��$	��Top=��� -C   $ TextBoxStartTime��$�� ��$	��Top=�$
��Left=�$��	0,205,0,0q�$��20��$	��100���� $��HH:MM��$	��Top=�$��Right=�$��	0,202,0,0q�$��25��$��50���� -D   $ LabelHideHint��$��H/S locked/edited rows.��$
��Left=�$��	0,230,0,0q�$��25��$	��Top=��� -E   $ 
SliderHide��$��Center=�$��
0,250,0,22q�$��20��$	��Top=�$ 2Q�$ 1Q�$ 1Q�$��75���� -F   $ 	LabelShow��$
��Show��$
��Left=�$��	0,247,0,0q�$��25��$	��Top=��� -G   $ 	LabelHide��$
��Hide��$��Right=�$��	0,247,0,0q�$��25��$	��Top=��� -H    ��Name$ 	ImageLogo��$��Bottom=�$3��-pack://application:,,,/Resources/TXM_Logo.png��