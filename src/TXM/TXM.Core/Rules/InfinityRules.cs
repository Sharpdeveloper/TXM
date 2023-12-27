﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using TXM.Core.Models;

namespace TXM.Core
{
    //TODO: Unfertig, da hier die SoS über die MoV statt die TP berechnet werden soll -.-
    [Serializable]
    public class InfinityRules : AbstractRules
	{
		private new static string name = "Corvus Belli Infinity\u2122";

		public InfinityRules()
		{
			IsDrawPossible = false;
			OptionalFields = new List<string>() { "MoV" };
			IsDoubleElimination = false;
			IsRandomSeeding = true;
			IsWinnerDropDownNeeded = true;
			DefaultMaxPoints = 400;
			Factions = new string[] { "PanOceania", "Yu Jing", "Ariadna", "Haqqislam", "Nomads", "Combined Army", "Aleph", "Tohaa", "Mercenaries" };
			DefaultTime = 135;
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
			if (result.EnemyID == -1)
			{
				newResult = new Result((int)0.35 * result.MaxPoints, 0, result.EnemyID, result.MaxPoints, result.WinnerID);
			}
			//ID == -2 => WonBye
			else if (result.EnemyID == -2)
			{
				newResult = new Result((int)0.35 * result.MaxPoints, 0, result.EnemyID, result.MaxPoints, result.WinnerID);
			}

			var tP = newResult.WinnerID == -99 ? -1 : newResult.Destroyed - newResult.Lost;
			if (tP == 0 && newResult.WinnerID != newResult.EnemyID)
			{
				tP = 6;
			}
			else if (tP <= -300)
			{
				tP = 1;
			}
			else if (tP <= -220)
			{
				tP = 2;
			}
			else if (tP <= -140)
			{
				tP = 3;
			}
			else if (tP <= -60)
			{
				tP = 4;
			}
			else if (tP <= 0)
			{
				tP = 5;
			}
			else if (tP <= 59)
			{
				tP = 6;
			}
			else if (tP <= 139)
			{
				tP = 7;
			}
			else if (tP <= 219)
			{
				tP = 8;
			}
			else if (tP <= 299)
			{
				tP = 9;
			}
			else
			{
				tP = 10;
			}

			TmarginOfVictory = f.Invoke(0, (newResult.Destroyed - newResult.Lost));
			TdestroyedPoints = f.Invoke(0, newResult.Destroyed);
			TlostPoints = f.Invoke(0, newResult.Lost);
			TtournamentPoints = f.Invoke(0, tP);
			if (tP >= 6)
				Twins = f.Invoke(0, 1);
			else
				Tlosses = f.Invoke(0, 1);

			return tP >= 6;
		}

		public override ObservableCollection<Models.Player> SortTable(ObservableCollection<Models.Player> unsorted)
		{
            var t = unsorted.OrderByDescending(x => x.IsInCut).ThenByDescending(x => x.TournamentPoints).ThenByDescending(x => x.MarginOfVictory).ThenByDescending(x => x.StrengthOfSchedule).ThenBy(x => x.Order).ToList();
			for (int i = 0; i < t.Count; i++)
				t[i].Rank = i + 1;
			return new ObservableCollection<Player>(t);
		}
	}
}
