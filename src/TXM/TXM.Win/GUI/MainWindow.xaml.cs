﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using TXM.GUI.Dialogs;
using TXM.GUI.Windows;
using TXM.Core;
using TXM.Core.Models;
using TXM.Core.ViewModels;

namespace TXM.GUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICollectionView dataView;
        private TournamentController tournamentController;
        private int refresh = 0;
        private List<Pairing> currentPairingList;
        private bool hide = false;
        private string currentScenario;

        public MainWindow()
        {
            InitializeComponent();

            Closing += WindowClosed;

            tournamentController = new TournamentController(new IO(new WindowsFile(), new WindowsMessage()));

            // if (tournamentController.ActiveIO.ActiveSettings.TextColor == "Black")
            //     SliderText.Value = 1.0;
            // else
            //     SliderText.Value = 2.0;

            // double size = tournamentController.ActiveIO.ActiveSettings.TextSize;
            // if (size > 100.0)
            //     SliderSize.Value = 100.0;
            // else
            //     SliderSize.Value = size;

            tournamentController.ActiveTimer.Changed += Time_Changed;

        }

        private void InitDataGridPairing(bool update = false, bool bonus = false)
        {
//TODO Binding Readonly to Locked
        }
  

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WindowClosed(object sender, CancelEventArgs e)
        {
            tournamentController.Close();
        }

        private void NewPlayer_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.NewPlayer(new NewPlayerDialog(tournamentController.ActiveTournament.Rule));
            Refresh();
            e.Handled = true;
        }

        private void Refresh()
        {
            //currentPairingList = tournamentController.ActiveTournament.Rounds[^1].Pairings.ToList();
            RefreshDataGridPairings();
            //RefreshDataGridPlayer(tournamentController.ActiveTournament.Participants.ToList());
            if (tournamentController.ActiveTournament != null && tournamentController.ActiveTournament.Rule != null && tournamentController.ActiveTournament.Rule.UsesScenarios)
            {
                this.LabelScenario.Visibility = Visibility.Visible;
                this.ComboboxScenarios.Visibility = Visibility.Visible;
                this.LabelScenarios.Visibility = Visibility.Visible;
                SetScenarios();
            }
        }

        private void SetScenarios()
        {
            ComboboxScenarios.Items.Clear();
            foreach (var s in tournamentController.ActiveTournament.ActiveScenarios)
            {
                ComboBoxItem newListItem = new ComboBoxItem();
                newListItem.Content = s;
                ComboboxScenarios.Items.Add(newListItem);
            }
            ComboboxScenarios.SelectedIndex = 0;
        }

        private void NewTournament_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.NewTournament(new NewTournamentDialog());
            if (tournamentController.ActiveTournament != null)
            {
                SetGUIState(true);
                Refresh();
                InitDataGridPairing();
            }
            e.Handled = true;
        }

        private void NewTimer_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.ShowTimerWindow(new TimerWindow());
        }

        private void Time_Changed(object sender, EventArgs e)
        {
            Dispatcher.Invoke(new Action(PrintTime));
        }

        private void RibbonButtonEditPlayer_Click(object sender, RoutedEventArgs e)
        {
            EditPlayer();
            e.Handled = true;
        }

        private void EditPlayer()
        {
            if (DataGridPlayer.SelectedItems.Count > 1)
            {
                tournamentController.ActiveIO.ShowMessage("Please select only 1 player you want to edit.");
                return;
            }
            if (DataGridPlayer.SelectedIndex >= 0)
            {
                tournamentController.EditPlayer(new NewPlayerDialog(tournamentController.ActiveTournament.Rule), DataGridPlayer.SelectedIndex);
                //RefreshDataGridPlayer(tournamentController.ActiveTournament.Participants.ToList());
            }
        }

        private void GOEPPImport_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.Import(new NewTournamentDialog(), false);
            if (tournamentController.ActiveTournament != null)
            {
                ComboBoxRounds.Items.Clear();

                SetGUIState(true);
                Refresh();
                DataGridPlayer.ItemsSource = tournamentController.ActiveTournament.Participants;
                //RefreshDataGridPlayer(tournamentController.ActiveTournament.Participants.ToList());
                SetRandomTime();
            }
        }

        private void GOEPPExport_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.GOEPPExport();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.Save(ButtonGetResults.Content.ToString(), ButtonCut.IsEnabled);
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void Load(bool autosave = false)
        {
            tournamentController.Load(new AutosaveDialog(), autosave);
            if (tournamentController.ActiveTournament != null)
            {
                ComboBoxRounds.Items.Clear();
                if (tournamentController.ActiveTournament.Rounds != null)
                {
                    for (int i = 1; i <= tournamentController.ActiveTournament.Rounds.Count; i++)
                        AddRoundButton(i);
                    if (tournamentController.ActiveTournament.Rounds != null && tournamentController.ActiveTournament.Rounds.Count > 0)
                        DataGridPairing.ItemsSource = tournamentController.ActiveTournament.Rounds[tournamentController.ActiveTournament.Rounds.Count - 1].Pairings;
                    // if (tournamentController.ActiveTournament.FirstRound && (tournamentController.ActiveTournament.Rounds == null || tournamentController.ActiveTournament.Rounds.Count == 0))
                    // {
                    //     SetGUIState(true);
                    // }
                    // else
                    // {
                    //     SetGUIState(false, true);
                    // }
                    ButtonGetResults.Content = tournamentController.ActiveTournament.ButtonGetResultsText;
                    ButtonGetResults.IsEnabled = true;
                    ButtonCut.IsEnabled = tournamentController.ActiveTournament.ButtonCutState == true;
                    tournamentController.ActiveTournament.Sort();
                    //RefreshDataGridPlayer(tournamentController.ActiveTournament.Participants);
                    // if (tournamentController.ActiveTournament.Pairings != null)
                    // {
                    //     currentPairingList = tournamentController.ActiveTournament.Pairings;
                    //     RefreshDataGridPairings();
                    // }

                    // if (tournamentController.ActiveTournament.bonus)
                    // {
                    //     InitDataGridPairing(false, true);
                    // }
                    // else
                    // {
                    //     InitDataGridPairing();
                    // }
                    ButtonGetResults.ToolTip = ButtonGetResults.Content.ToString();
                }
                SetRandomTime();
            }
        }

        private void SetRandomTime()
        {
            string rand =  tournamentController.GetRandomTime();
            if (tournamentController.GetRandomTime() != "")
            {
                CheckboxRandomTime.IsChecked = true;
                TextBoxRandomTime.Text = rand;
            }
            else
            {
                CheckboxRandomTime.IsChecked = false;
                TextBoxRandomTime.Text = "";
            }
            SetRandomStatus();
        }

        private void GetSeed(bool cut = false)
        {
            // List<Pairing> pairings = tournamentController.GetSeed(cut);
            // currentPairingList = pairings;
            RefreshDataGridPairings();
            AddRoundButton();
            ChangeGUIState(true);
            tournamentController.Save(ButtonGetResults.Content.ToString(), ButtonCut.IsEnabled, true);
            if (tournamentController.ActiveTournament.Rule.UsesScenarios)
            {
                LabelScenarios.Content = "Selected Scenario: " + tournamentController.ActiveTournament.ChosenScenario;
                SetScenarios();
            }
        }

        private void PariringCurrentCellChanged(object sender, EventArgs e)
        {
            DataGridPairing.CommitEdit();
            refresh++;
            if (refresh >= 5 && currentPairingList != null)
            {
                RefreshDataGridPairings();
                refresh = 0;
            }
        }

        private void RefreshDataGridPlayer(List<Player> players)
        {
            DataGridPlayer.ItemsSource = null;
            DataGridPlayer.ItemsSource = players;
            dataView = CollectionViewSource.GetDefaultView(DataGridPlayer.ItemsSource);
            dataView.SortDescriptions.Clear();

            tournamentController.ActiveTournament.Sort();

            dataView.SortDescriptions.Add(new SortDescription("Rank", ListSortDirection.Ascending));
            dataView.Refresh();
        }

        private void RefreshDataGridPairings()
        {
            if (currentPairingList == null)
                return;
            DataGridPairing.ItemsSource = null;
            List<Pairing> p = new List<Pairing>();
            if (hide)
            {
                foreach (var pa in currentPairingList)
                {
                    if (!pa.IsHidden)
                        p.Add(pa);
                }
            }
            else
            {
                p = currentPairingList;
            }
            DataGridPairing.ItemsSource = p;
        }

        private void DataGridPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridPlayer.SelectedItem != null)
            {
                RemovePlayerIsEnabled = true;
                DisqualifyPlayerIsEnabled = tournamentController.Started;
                EditPlayerIsEnabled = true;
            }
            else
            {
                RemovePlayerIsEnabled = false;
                EditPlayerIsEnabled = false;
                DisqualifyPlayerIsEnabled = false;
            }
        }

        private void DataGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            // Lookup for the source to be DataGridCell
            if (e.OriginalSource.GetType() == typeof(DataGridCell))
            {
                var cell = (DataGridCell)e.OriginalSource;
                if(cell.Content.GetType() == typeof(CheckBox))
                {
                    var cb = (CheckBox)cell.Content;
                    cb.IsChecked = !cb.IsChecked;
                }
                else
                {
                    // Starts the Edit on the row;
                    DataGrid grd = (DataGrid)sender;
                    grd.BeginEdit(e);
                }  
            }
        }

        private void GridMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as DataGrid;

            if (grid == null)
            {
                return;
            }

            try
            {
                // Assume first column is the checkbox column.
                if (grid.CurrentColumn == grid.Columns[5])
                {
                    var gridCheckBox = (grid.CurrentColumn.GetCellContent(grid.SelectedItem) as CheckBox);

                    if (gridCheckBox != null)
                    {
                        gridCheckBox.IsChecked = !gridCheckBox.IsChecked;
                    }
                }
            }
            catch (ArgumentOutOfRangeException) { }
            catch (ArgumentNullException) { }
        }

        private void DataGridPlayer_DoubleClicked(object sender, MouseButtonEventArgs e)
        {
            EditPlayer();
            e.Handled = true;
        }

        private void ButtonNextRound_Click(object sender, RoutedEventArgs e)
        {
            GetSeed();
        }

        private void AddRoundButton(int actRound = -1)
        {
            ComboBoxItem newListItem = new ComboBoxItem();
            if (actRound == -1)
                actRound = tournamentController.ActiveTournament.Rounds.Count;
            newListItem.Content = actRound;
            ComboBoxRounds.Items.Add(newListItem);
        }

        private void ButtonGetResults_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonGetResults.Content.ToString() == "Start Tournament")
            {
                if (tournamentController.StartTournament(ButtonGetResults.Content.ToString(), ButtonCut.IsEnabled))
                {
                    SetGUIState(false, true);
                }
                return;
            }
            if (ButtonGetResults.Content.ToString() == "Next Round")
            {
                GetSeed();
                return;
            }
            if (ButtonGetResults.Content.ToString() == "Update")
            {
                if (tournamentController.GetResults((List<Pairing>)DataGridPairing.ItemsSource, ButtonGetResults.Content.ToString(), false, true))
                {
                    //RefreshDataGridPlayer(tournamentController.ActiveTournament.Participants.ToList());
                    tournamentController.ActiveIO.ShowMessage("Update done!");
                    ButtonGetResults.IsEnabled = true;
                    ButtonGetResults.Content = tournamentController.ActiveTournament.ButtonGetResultsText;
                    ButtonCut.IsEnabled = tournamentController.ActiveTournament.ButtonCutState;
                    ComboBoxRounds.SelectedIndex = ComboBoxRounds.Items.Count - 1;
                   // currentPairingList = tournamentController.ActiveTournament.Rounds[^1].Pairings;
                    RefreshDataGridPairings();
                    ButtonGetResults.ToolTip = ButtonGetResults.Content.ToString();
                    tournamentController.Save(ButtonGetResults.Content.ToString(), false, true, "Update_Round");
                }
                return;
            }
            if (ButtonGetResults.Content.ToString() == "Get Results")
            {
                if (tournamentController.GetResults((List<Pairing>)DataGridPairing.ItemsSource, ButtonGetResults.Content.ToString(), ButtonCut.IsEnabled))
                {
                   // RefreshDataGridPlayer(tournamentController.ActiveTournament.Participants.ToList());
                    ChangeGUIState(false);
                    tournamentController.Save(ButtonGetResults.Content.ToString(), false, true, "Result_Round");
                    LabelScenarios.Content = "";
                }
                return;
            }
        }

        private void ComboBoxRounds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string header = ((ComboBox)sender).SelectedValue.ToString();
            header = header.Remove(0, header.IndexOf(" "));
            int round = Int32.Parse(header);
            Round activeRound = tournamentController.ActiveTournament.Rounds[round - 1];
            //currentPairingList = activeRound.Pairings.ToList();
            RefreshDataGridPairings();
            //RefreshDataGridPlayer(activeRound.Participants);
            if (tournamentController.ActiveTournament.Rounds.Count == round)
            {
                ButtonGetResults.IsEnabled = true;
                ButtonGetResults.Content = tournamentController.ActiveTournament.ButtonGetResultsText;
                ButtonCut.IsEnabled = tournamentController.ActiveTournament.ButtonCutState;
                InitDataGridPairing();
                ComboboxScenarios.IsEnabled = true;
                LabelScenarios.Content = currentScenario;
            }
            else
            {
                tournamentController.ActiveTournament.ButtonGetResultsText = ButtonGetResults.Content.ToString();
                tournamentController.ActiveTournament.ButtonCutState = ButtonCut.IsEnabled;
                ButtonGetResults.IsEnabled = true;
                ButtonGetResults.Content = "Update";
                ButtonCut.IsEnabled = false;
                InitDataGridPairing(true);
                ComboboxScenarios.IsEnabled = false;
                currentScenario = LabelScenarios.Content.ToString();
                LabelScenarios.Content = "Chosen Scenario: " + activeRound.Scenario;
            }
            //tournamentController.ActiveTournament.DisplayedRound = round;
            ButtonGetResults.ToolTip = ButtonGetResults.Content.ToString();
        }

        private void ButtonAutosave_Click(object sender, RoutedEventArgs e)
        {
            // if (tournamentController.ActiveIO.AutosavePathExists)
            //     Load(true);
            // else
            //     tournamentController.ActiveIO.ShowMessage("No Autosavefolder");
        }

        private void MenuItemOpenAutoSaveFolder_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.ActiveIO.OpenAutosaveFolder();
            if(tournamentController.ActiveTournament != null)
            {
                SetRandomTime();
            }
        }

        private void MenuItemTSettings_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.EditTournament(new NewTournamentDialog());
        }

        private void ButtonCut_Click(object sender, RoutedEventArgs e)
        {
            GetSeed(true);
        }

        private void MenuItemDeleteAutosave_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.ActiveIO.DeleteAutosaveFolder();
        }

        private void RemovePlayer_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridPlayer.SelectedItems.Count > 1)
            {
                foreach (Player s in DataGridPlayer.SelectedItems)
                {
                    tournamentController.RemovePlayer(s);
                }
            }
            else if (DataGridPlayer.SelectedIndex >= 0)
            {
                tournamentController.RemovePlayer(DataGridPlayer.SelectedIndex);
            }
           // RefreshDataGridPlayer(tournamentController.ActiveTournament.Participants.ToList());
        }

        private void ButtonChangePairing_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.EditPairings(new SetPairingDialog(), ButtonGetResults.Content.ToString(), ButtonCut.IsEnabled);
            //currentPairingList = tournamentController.ActiveTournament.Rounds[^1].Pairings;
            RefreshDataGridPairings();
        }

        private void MenuItemResetLastResults_Click(object sender, RoutedEventArgs e)
        {
            List<Pairing> pl = tournamentController.ResetLastResults();
            ChangeGUIState(true);
            currentPairingList = pl;
            RefreshDataGridPairings();
           // RefreshDataGridPlayer(tournamentController.ActiveTournament.Participants.ToList());
        }

        private void SetGUIState(bool start, bool tournamentStart = false)
        {
            if (start)
            {
                NewPlayerIsEnabled = true;
                MenuItemTSettings.IsEnabled = tournamentController.ActiveTournament != null;
                MenuItemBonusPoints.IsEnabled = tournamentController.ActiveTournament != null;
                ButtonEndTournament.IsEnabled = tournamentController.ActiveTournament != null;
                ButtonNewTournament.IsEnabled = true;
                ButtonGOEPPImport.IsEnabled = true;
                MenuItemListFortressExport.IsEnabled = true;
                EditPlayerIsEnabled = tournamentController.ActiveTournament != null;
                RemovePlayerIsEnabled = tournamentController.ActiveTournament != null;
                ChangePairingIsEnabled = tournamentController.ActiveTournament.Rounds[^1].Pairings != null;
                SaveIsEnabled = tournamentController.ActiveTournament != null;
                ResetLastResultsIsEnabled = false;
                ButtonGetResults.IsEnabled = true;
                ButtonGetResults.Content = "Start Tournament";
                DisqualifyPlayerIsEnabled = false;
                MenuItemPrintHeader.IsEnabled = tournamentController.ActiveTournament != null;
                MenuItemCSVAdd.IsEnabled = tournamentController.ActiveTournament != null;
                MenuItemListFortressExport.IsEnabled = tournamentController.ActiveTournament != null;
            }
            if (tournamentStart)
            {
                if (tournamentController.ActiveTournament.Rounds.Count > 1)
                    NewPlayerIsEnabled = false;
                else
                    NewPlayerIsEnabled = true;
                MenuItemTSettings.IsEnabled = true;
                MenuItemBonusPoints.IsEnabled = true; 
                ButtonEndTournament.IsEnabled = true;
                ButtonGOEPPExport.IsEnabled = true;
                MenuItemListFortressExport.IsEnabled = true;
                //ButtonEndTournament.IsEnabled = true;
                EditPlayerIsEnabled = false;
                RemovePlayerIsEnabled = false;
                ChangePairingIsEnabled = true;
                SaveIsEnabled = true;
                ResetLastResultsIsEnabled = true;
                DisqualifyPlayerIsEnabled = true;
                ButtonGetResults.Content = "Next Round";
            }
            ButtonGetResults.ToolTip = ButtonGetResults.Content.ToString();
        }

        private void ChangeGUIState(bool seed, bool end = false)
        {
            if (seed)
            {
                ButtonGetResults.Content = "Get Results";
                ButtonCut.IsEnabled = false;
                MenuItemResetLastResults.IsEnabled = false;
                DisqualifyPlayerIsEnabled = true;
            }
            else
            {
                ButtonGetResults.Content = "Next Round";
                MenuItemResetLastResults.IsEnabled = !end;
                ButtonGetResults.IsEnabled = !end;
                // if (tournamentController.ActiveTournament.Cut == TournamentCut.NoCut || tournamentController.ActiveTournament.CutStarted)
                //     ButtonCut.IsEnabled = false;
                // else
                //     ButtonCut.IsEnabled = true;
            }
            ButtonGetResults.ToolTip = ButtonGetResults.Content.ToString();
        }

        public bool SaveIsEnabled
        {
            get
            {
                return ButtonSave.IsEnabled;
            }
            set
            {
                ButtonSave.IsEnabled = value;
                MenuItemSave.IsEnabled = value;
            }
        }

        public bool NewPlayerIsEnabled
        {
            get
            {
                return ButtonNewPlayer.IsEnabled;
            }
            set
            {
                ButtonNewPlayer.IsEnabled = value;
                MenuItemNewPlayer.IsEnabled = value;
            }
        }

        public bool EditPlayerIsEnabled
        {
            get
            {
                return ButtonEditPlayer.IsEnabled;
            }
            set
            {
                ButtonEditPlayer.IsEnabled = value;
                MenuItemEditPlayer.IsEnabled = value;
            }
        }

        public bool RemovePlayerIsEnabled
        {
            get
            {
                return ButtonRemovePlayer.IsEnabled;
            }
            set
            {
                ButtonRemovePlayer.IsEnabled = value;
                MenuItemRemovePlayer.IsEnabled = value;
            }
        }

        public bool DisqualifyPlayerIsEnabled
        {
            get
            {
                return ButtonDisqualifyPlayer.IsEnabled;
            }
            set
            {
                ButtonDisqualifyPlayer.IsEnabled = value;
                MenuItemDisqualifyPlayer.IsEnabled = value;
            }
        }

        public bool ChangePairingIsEnabled
        {
            get
            {
                return ButtonChangePairing.IsEnabled;
            }
            set
            {
                ButtonChangePairing.IsEnabled = value;
                MenuItemChangePairing.IsEnabled = value;
            }
        }

        public bool ResetLastResultsIsEnabled
        {
            get
            {
                return ButtonResetLastResults.IsEnabled;
            }
            set
            {
                ButtonResetLastResults.IsEnabled = value;
                MenuItemResetLastResults.IsEnabled = value;
            }
        }

        public bool TimerIsEnabled
        {
            get
            {
                return ButtonTimer.IsEnabled;
            }
            set
            {
                ButtonTimer.IsEnabled = value;
                MenuItemTimer.IsEnabled = value;
            }
        }

        private void DisqualifyPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridPlayer.SelectedItems.Count > 1)
            {
                foreach (Player s in DataGridPlayer.SelectedItems)
                {
                    tournamentController.RemovePlayer(s, true);
                }
            }
            else if (DataGridPlayer.SelectedIndex >= 0)
            {
                tournamentController.RemovePlayer(DataGridPlayer.SelectedIndex, true);
            }
            //RefreshDataGridPlayer(tournamentController.ActiveTournament.Participants);
        }

        private void MenuItemShowPairings_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.ShowProjector(new ProjectorWindow(), false);
        }

        private void MenuItemShowTable_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.ShowProjector(new ProjectorWindow(), true);
        }

        private void MenuItemPrint_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.Print(true);
        }

        private void MenuItemTimeStart_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.StartTimer(TextBoxStartTime.Text);
        }

        private void MenuItemTimePause_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.PauseTimer();
        }

        private void MenuItemTimeReset_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.ResetTimer();
        }

        private void PrintTime()
        {
            LabelTime.Content = tournamentController.ActiveTimer.ActualTime;
        }

        private void MenuItemPrintPairing_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.Print(true, true);
        }

        private void RefreshPlayerList(object sender, RoutedEventArgs e)
        {
            //RefreshDataGridPlayer(tournamentController.ActiveTournament.Participants);
        }

        private void RefreshPairingsList(object sender, RoutedEventArgs e)
        {
            //currentPairingList = tournamentController.ActiveTournament.Pairings;
            RefreshDataGridPairings();
        }

        private void MenuItemPrintParingScore_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.PrintScoreSheet();
        }

        private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog ad = new AboutDialog()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            tournamentController.ShowAbout(ad);
        }

        private void MenuItemSupport_Click(object sender, RoutedEventArgs e)
        {
            SupportDialog ad = new SupportDialog()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            tournamentController.ShowSupport(ad);
        }

        private void MenuItemThanks_Click(object sender, RoutedEventArgs e)
        {
            ThanksDialog ad = new ThanksDialog()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            tournamentController.ShowThanks(ad);
        }

        private void DataGridPlayer_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //(List<Player>)Data.ItemsSource
            if (e.EditAction == DataGridEditAction.Commit)
            {
                if (DataGridPlayer.SelectedItems.Count > 1)
                    return;
                Player player = tournamentController.ActiveTournament.Participants[DataGridPlayer.SelectedIndex];
                player.IsPresent = !player.IsPresent;
                //activeTournament.ChangePlayer(player);
            }
        }

        private void MenuItemPrintResult_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.Print(true, true, true);
        }

        private void MenuItemBBCode_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.GetBBCode(new OutputDialog(), new WindowsClipboard());
        }

        private void MenuItemCSVImport_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.Import(new NewTournamentDialog(), true);
            if (tournamentController.ActiveTournament != null)
            {
                ComboBoxRounds.Items.Clear();
                SetGUIState(true);
                //RefreshDataGridPlayer(tournamentController.ActiveTournament.Participants);
                SetRandomTime();
            }
        }

        private void TextBoxTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxTime.Text = tournamentController.SetTimer(TextBoxTime.Text);
        }

        private void SetImage_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.SetImage();
        }

        private void SliderColor_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (tournamentController != null)
            { 
                tournamentController.SetTimerLabelColor(SliderText.Value == 1.0 ? "Black" : "White");
            }
        }

        private void SliderSize_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (tournamentController != null)
            {
                tournamentController.SetTimerTextSize(SliderSize.Value);
            }
        }

        private void EndTournament_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.CalculateWonByes();
        }

        private void MenuItemUserHelp_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.ShowUserManual();
        }

        private void MenuItemBonusPoints_Click(object sender, RoutedEventArgs e)
        {
            //List<Pairing> pairings = tournamentController.AwardBonusPoints();
            InitDataGridPairing(false, true);
            //currentPairingList = pairings;
            RefreshDataGridPairings();
            AddRoundButton();
            ChangeGUIState(true);
            tournamentController.Save(ButtonGetResults.Content.ToString(), ButtonCut.IsEnabled, true);
        }

        private void DataGridPairing_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (e.Column.DisplayIndex != 0)
            {
                int t = e.Row.GetIndex();
                // if (tournamentController.ActiveTournament.Pairings[e.Row.GetIndex()].Locked)
                // {
                //     e.Cancel = true;
                // }
            }
        }

        private void SliderHide_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            hide = SliderHide.Value == 2.0;
            RefreshDataGridPairings();
        }

        private void ComboboxScenarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBox)sender).SelectedValue != null)
                tournamentController.ActiveTournament.ChosenScenario = ((ComboBoxItem)((ComboBox)sender).SelectedItem).Content.ToString();
        }

        private void CheckboxRandomTime_Click(object sender, RoutedEventArgs e)
        {
            SetRandomStatus();
        }

        private void SetRandomStatus()
        {
            tournamentController.ActiveTimer.RandomTime = CheckboxRandomTime.IsChecked == true;
            TextBoxRandomTime.IsEnabled = CheckboxRandomTime.IsChecked == true;
            LabelRandomMin.IsEnabled = CheckboxRandomTime.IsChecked == true;
            LabelRandomPM.IsEnabled = CheckboxRandomTime.IsChecked == true;
        }

        private void TextBoxRandomTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxRandomTime.Text = tournamentController.SetRandomTime(TextBoxRandomTime.Text);
        }

        private void MenuItemCSVAdd_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.AddCSV();
            //RefreshDataGridPlayer(tournamentController.ActiveTournament.Participants);
        }

        private void MenuItemListFortressExport_Click(object sender, RoutedEventArgs e)
        {
            tournamentController.GetJSON(new WindowsClipboard());
        }
    }
}
