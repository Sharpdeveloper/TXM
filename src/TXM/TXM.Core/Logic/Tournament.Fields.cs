﻿using System;
namespace TXM.Core.Logic
{
	public partial class Tournament
	{
        private int version = 3;

        #region Tournament Information
        public List<Player> Participants { get; set; }
        public List<Player> Teamplayer { get; set; }
        public bool FirstRound { get; set; }
        public List<Pairing> PrePaired { get; set; }
        public string Name { get; set; }
        public List<string> Nicknames { get; internal set; }
        public int MaxPoints { get; set; }
        public List<Round> Rounds { get; internal set; }
        public string FilePath { get; internal set; }
        public string AutoSavePath { get; internal set; }
        public int DisplayedRound { get; set; }
        public TournamentCut Cut { get; set; }
        public bool CutStarted { get; internal set; }
        public bool WonByeCalculated { get; internal set; }
        public List<Pairing> Pairings { get; set; }
        public bool TeamProtection { get; set; }
        public bool Single { get; set; }
        public bool PrintDDGER { get; set; }
        public bool PrintDDENG { get; set; }
        public AbstractRules Rule
        {
            get
            {
                return rule;
            }
            set
            {
                rule = value;
                if (rule != null && rule.UsesScenarios)
                {
                    ResetScenarios();
                }
            }
        }
        public bool bonus;
        public List<string> ActiveScenarios { get; private set; }
        public string ChoosenScenario { get; set; }
        public string ActiveScenario { get; set; }
        #endregion

        #region GUI_State
        public string ButtonGetResultsText { get; set; }
        public bool ButtonCutState { get; set; }
        #endregion

        #region T3 Information
        public int T3ID { get; set; }
        public string GOEPPVersion { get; internal set; }
        #endregion

        #region internal Fields
        internal static List<int> givenStartNo = new List<int>();
        public Player WonBye = Player.GetWonBye();
        public Player Bye = Player.GetBye();
        private Player Bonus = Player.GetBonus();
        internal List<Player> ListOfPlayers;
        private List<Player>[] PointGroup;
        internal int WonByes;
        internal int currentCountOfPlayer;
        internal List<Player> WinnerLastRound;
        internal bool bye;
        private AbstractRules rule;
        #endregion
	}
}

