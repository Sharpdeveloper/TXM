﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using TXM.Core.Models;

namespace TXM.Core
{
	[Serializable]
	public class LegendOfThe5RingesRules : AbstractRules
	{
        private new static string name = "Legend of the Five Rings\u2122: The Card Game - Experimental";

		public LegendOfThe5RingesRules()
		{
			IsDrawPossible = false;
			OptionalFields = new List<string>() { " ModWins", "eSoS" };
			IsDoubleElimination = false;
			IsRandomSeeding = true;
			IsWinnerDropDownNeeded = true;
			DefaultMaxPoints = 0;
			Factions = new string[] { "The Crab Clan", "The Crane Clan", "The Dragon Clan", "The Lion Clan", "The Phoenix Clan", "The Scorpion Clan", "The Unicorn Clan" };
			DefaultTime = 55;
			base.name = name;
		}

		public static string GetRuleName()
		{
			return name;
		}

		protected override bool CalculateResult(Result result, Func<int, int, int> f)
		{
			Result newResult = result;

			//ID == -1 => Bye
			if (result.EnemyID == -1 || result.EnemyID == -2)
			{
				newResult = new Result(1, 0, result.EnemyID, 1, result.WinnerID);
			}

			int tP = newResult.Destroyed - newResult.Lost;
			if (tP > 0)
			{
				tP = 5;
			}
			else if (tP == 0 && newResult.WinnerID != newResult.EnemyID)
			{
				tP = 4;
			}
			else
			{
				tP = 0;
			}

			TtournamentPoints = f.Invoke(0, tP);
			switch (tP)
			{
				case 5:
					Twins = f.Invoke(0, 1);
					break;
				case 4:
					TmodifiedWins = f.Invoke(0, 1);
					break;
				case 0:
					Tlosses = f.Invoke(0, 1);
					break;
			}

			return tP == 1;
		}

		public override ObservableCollection<Models.Player> SortTable(ObservableCollection<Models.Player> unsorted)
		{
            var t = unsorted.OrderByDescending(x => x.TournamentPoints).ThenByDescending(x => x.StrengthOfSchedule).ThenByDescending(x => x.ExtendedStrengthOfSchedule).ThenBy(x => x.Order).ToList();
			for (int i = 0; i < t.Count; i++)
				t[i].Rank = i + 1;
			return new ObservableCollection<Player>(t);
		}
	}
}
