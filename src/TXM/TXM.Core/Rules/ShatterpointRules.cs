﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using TXM.Core.Models;

namespace TXM.Core
{
    [Serializable]
	public class ShatterpointRules : AbstractRules
	{
        private new static string name = "Star Wars\u2122: Shatterpoint\u2122";

        public ShatterpointRules()
        {
            IsDrawPossible = true;
            OptionalFields = new List<string>() { "MoV"};
            movName = "Struggle";
            IsDoubleElimination = false;
            IsRandomSeeding = true;
            IsWinnerDropDownNeeded = false;
            tournamentPoints = true;
            DefaultMaxPoints = 0;
            Factions = new string[] { "Fall of the Jedi", "Age of Rebellion" };
            DefaultTime = 120;
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
				newResult = new Result(2, 0, result.EnemyID, result.MaxPoints, result.WinnerID);
			}
			//ID == -2 => WonBye
			else if (result.EnemyID == -2)
			{
				newResult = new Result((int) result.MaxPoints, 0, result.EnemyID, result.MaxPoints, result.WinnerID);
			}

			var tP = newResult.WinnerID == -99 ? -1 : newResult.Destroyed - newResult.Lost;
			if (tP > 0)
			{
				tP = 1;
			}
			else if (tP == 0 && newResult.WinnerID != newResult.EnemyID)
			{
				tP = 1;
			}
			else
			{
				tP = 0;
			}

			TmarginOfVictory = f.Invoke(0, (newResult.Destroyed - newResult.Lost + newResult.MaxPoints));
			TdestroyedPoints = f.Invoke(0, newResult.Destroyed);
			TlostPoints = f.Invoke(0, newResult.Lost);
			TtournamentPoints = f.Invoke(0, tP);
			switch (tP)
			{
				case 1:
					Twins = f.Invoke(0, 1);
					break;
				case 0:
					Tlosses = f.Invoke(0, 1);
					break;
			}

			return tP == 1;
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
