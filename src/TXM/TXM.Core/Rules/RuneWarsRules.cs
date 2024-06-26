﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using TXM.Core.Models;

namespace TXM.Core
{
    [Serializable]
	public class RuneWarsRules : AbstractRules
	{
        private new static string name = "Runewars Miniatures Game";

        public RuneWarsRules()
        {
            IsDrawPossible = false;
            OptionalFields = new List<string>() { "MoV" };
            IsDoubleElimination = false;
            IsRandomSeeding = true;
            IsWinnerDropDownNeeded = true;
            DefaultMaxPoints = 200;
            Factions = new string[] { "Daqan", "Latari", "Uthuk", "Waiqar" };
            DefaultTime = 90;
            base.name = name;
        }

        public static string GetRuleName()
		{
            return name;
		}

        protected override bool CalculateResult(Result result, Func<int, int, int> f)
		{
			Result newResult = result;

            if (newResult.MaxPoints == 0)
            {
                newResult.MaxPoints = DefaultMaxPoints;
            }

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
            else if (tP <= -150)
			{
				tP = 1;
			}
			else if (tP <= -110)
			{
				tP = 2;
			}
            else if (tP <= -70)
            {
                tP = 3;
            }
            else if (tP <= -30)
            {
                tP = 4;
            }
            else if (tP <= 0)
            {
                tP = 5;
            }
            else if (tP <= 29)
            {
                tP = 6;
            }
            else if (tP <= 69)
            {
                tP = 7;
            }
            else if (tP <= 109)
            {
                tP = 8;
            }
            else if (tP <= 149)
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
			if(tP >= 6)
				Twins = f.Invoke(0, 1);
			else
				Tlosses = f.Invoke(0, 1);

			return tP >=6;
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
