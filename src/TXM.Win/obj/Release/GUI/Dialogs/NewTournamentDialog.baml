   M S B A M L   `   `   `  ����   TXM)    #TXM.GUI.Dialogs.NewTournamentDialog   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Create new Tournament��$��376.244��$��494.561�� � 
ResizeMode$ NoResize=�.���  � ColumnDefinitions �� $
��203* ��� $
��286* �.+��� -    ��Name$ LabelTournamentForm��$��Choose Tournamenttype:��$
��Left=�$��	12,43,0,0q�$	��Top=�$��33���� -    ��Name$ ComboBoxTournamentType��$
��Left=�$��5,43,0,0q�$	��Top=�$	��263��$��1���� -   $ LabelCut��$
��Cut?��$
��Left=�$��	12,76,0,0q�$	��Top=�$��33��	� -    	�Name$ RadioButtonTop4�� 	� 	GroupName$	 Cut��$��Top 4��$
��Left=�$��
147,82,0,0q�$	��Top=�{�. $��1��	� -   $ RadioButtonTop8��$	 Cut��$��Top 8��$
��Left=�$��	5,102,0,0q�$	��Top=�{�. $��1��	� -   $ RadioButtonTop16��$	 Cut��$��Top 16��$
��Left=�$��147,102,0,0q�$	��Top=�{�. $��1��	� -   $ RadioButtonNoCut��$	 Cut��$��No Cut��$
��Left=�$��5,82,0,0q�$	��Top=�{�.  d� 	IsChecked$
 TrueY�$��1���� -    ��Name$ TextBoxMaxSquad��$��	9,156,0,0q�$
��Left=�$	��259��$��19��$	��Top=�$��1���� -	   	 ��Name$	 ButtonOK��$
��Save��$
��Left=�$��108,313,0,0q�$	��Top=�$��72��$��1���� -
   $	 ButtonCancel��$��Cancel��$
��Left=�$��194,313,0,0q�$	��Top=�$��75��$��1���� -   $ LabelTournamentName��$��Tournamentname:��$
��Left=�$��
12,122,0,0q�$	��Top=��� -   $ TextboxName��$
��Left=�$��23��$��	9,126,0,0q�
 �� TextWrapping$

 Wrap=�$	��Top=�$	��259��$��1���� -   $ LabelListsize��$��Max Listpoints:��$
��Left=�$��
12,153,0,0q�$	��Top=��� -   $ label��$A��;First Round Teamprotection?
(only allowed in casual events)��$
��Left=�$��
14,210,0,0q�$	��Top=�$	��187��	� -   $ radioButtonTPYes��$	��Yes��$ TeamProtection��$
��Left=�$��
10,231,0,0q�$	��Top=�$��1��	� -   $ radioButtonTPNo��$
 trueY�$ TeamProtection��$��No��$
��Left=�$��148,231,0,0q�$	��Top=�$��1���� -   $ label_Copy1��$��Tournamenttype:��$
��Left=�$��
14,257,0,0q�$	��Top=�$	��194��$��2��	� -   $ radioButtonTypeSingle��$
 TrueY�$��Single��$
 Type��$
��Left=�$��
11,263,0,0q�$	��Top=�$��1��	� -   $ radioButtonTypeTeam��$ falseY�$
 Type��$
��Team��$
��Left=�$��
79,263,0,0q�$	��Top=�$��1���� -   $ LabelGameSystem��$��Choose Gamesystem:��$
��Left=�$��	13,10,0,0q�$	��Top=�$��33���� -   $ ComboBoxGameSystem��$
��Left=�$��5,10,0,0q�$	��Top=�$	��263��$��1���� -   $ label_Copy2��$3��-Only needed at games with Army or Squadlists.��$
��Left=�$��
14,175,0,0q�$	��Top=�$	��266��$��2��