﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using TXM.Core.Models;

namespace TXM.Core
{
    [Serializable]
    public class XWing25Rules : AbstractRules
    {
        private new static string name = "Star Wars\u2122: X-Wing\u2122 Miniatures Game 2.5";

        public XWing25Rules()
        {
            IsDrawPossible = true;
            OptionalFields = new List<string>() { "MoV" };
            IsDoubleElimination = false;
            IsRandomSeeding = true;
            IsWinnerDropDownNeeded = false;
            DefaultMaxPoints = 20;
            Factions = new string[] { "First Order", "Galactic Empire", "Galactic Republic", "Rebel Alliance", "Resistance", "Scum and Villainy", "Separatist Allaince" };
            DefaultTime = 75;
            DefaultRandomMins = 3;
            movName = "MP";
            base.name = name;
            hasScenarios = true;
            Scenarios = new string[] { "Assault at the Satellite Array", "Chance Engagement", "Salvage Mission", "Scramble the Transmissions" };
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
                newResult = new Result((int)(0.9 * result.MaxPoints), 0, result.EnemyID, result.MaxPoints, result.WinnerID);
            }
            //ID == -2 => WonBye
            else if (result.EnemyID == -2)
            {
                newResult = new Result(result.MaxPoints, 0, result.EnemyID, result.MaxPoints, result.WinnerID);
            }

            var tP = newResult.WinnerID == -99 ? -1 : newResult.Destroyed - newResult.Lost;
            if (tP > 0)
            {
                tP = 3;
            }
            else if (tP == 0)
            {
                tP = 1;
            }
            else
            {
                tP = 0;
            }

            TmarginOfVictory = f.Invoke(0, newResult.Destroyed);
            //	TdestroyedPoints = f.Invoke(0, newResult.Destroyed);
            //	TlostPoints = f.Invoke(0, newResult.Lost);
            TtournamentPoints = f.Invoke(0, tP);
            switch (tP)
            {
                case 3:
                    Twins = f.Invoke(0, 1);
                    break;
                case 1:
                    Tdraws = f.Invoke(0, 1);
                    break;
                case 0:
                    Tlosses = f.Invoke(0, 1);
                    break;
            }

            return tP == 3;
        }

        public override ObservableCollection<Player> SortTable(ObservableCollection<Player> unsorted)
        {
            var t = unsorted.OrderByDescending(x => x.IsInCut).ThenByDescending(x => x.TournamentPoints).ThenByDescending(x => x.StrengthOfSchedule).ThenByDescending(x => x.MarginOfVictory).ThenBy(x => x.Order).ToList();

            for (int i = 0; i < t.Count; i++)
                t[i].Rank = i + 1;
            return new ObservableCollection<Player>(t);
        }
    }
}
