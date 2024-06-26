﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using TXM.Core.Models;

namespace TXM.Core
{
    [Serializable]
	public class W40KWLRules : AbstractRules
	{
        private new static string name = "Warhammer\u2122 40.000 (Sorted by Wins)";

        public W40KWLRules()
        {
            IsDrawPossible = true;
            OptionalFields = new List<string>() { "MoV" };
            IsDoubleElimination = false;
            IsRandomSeeding = false;
            IsWinnerDropDownNeeded = false;
            DefaultMaxPoints = 1850;
            Factions = new string[] { "Adeptus Custodes", "Adeptus Mechanicus", "Adeptus Ministorum",
                                      "Astra Militarum", "Blood Angels", "Chaos Daemons",
                                      "Chaos Space Marines", "Craftworlds", "Dark Angels",
                                      "Dark Edlar", "Death Guard", "Deathwatch",
                                      "Drukhari", "Eldar", "Genestealer Cults",
                                      "Grey Knights", "Harlequins", "Imperial Knights",
                                      "Inquistion", "Necrons", "Officio Assassinorum",
                                      "Orks", "Renegade Knights", "Sisters Silence",
                                      "Space Marines", "Space Wolves", "Tau Empire",
                                      "Thousand Sons", "Tyranids", "Ultramarines"};
            DefaultTime = 180;
            base.name = name;
            movName = "KP";
            tournamentPoints = true;
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
            if (result.EnemyID <= -1)
			{
				newResult = new Result((int)0.5 * result.MaxPoints, 0, result.EnemyID, result.MaxPoints, result.WinnerID, 15);
			}

            var tP = newResult.WinnerID == -99 ? 0 : newResult.TournamentPoints;

			TmarginOfVictory = f.Invoke(0, (newResult.Destroyed - newResult.Lost));
			TdestroyedPoints = f.Invoke(0, newResult.Destroyed);
			TlostPoints = f.Invoke(0, newResult.Lost);
			TtournamentPoints = f.Invoke(0, tP);
            if (tP > 10)
                Twins = f.Invoke(0, 1);
            else if (tP == 10)
                Tdraws = f.Invoke(0, 1);
            else
                Tlosses = f.Invoke(0, 1);

			return tP >10;
		}

        public override ObservableCollection<Models.Player> SortTable(ObservableCollection<Models.Player> unsorted)
        {
            var t = unsorted.OrderByDescending(x => x.IsInCut).ThenByDescending(x => x.TournamentPoints).ThenByDescending(x => x.Wins).ThenBy(x => x.Order).ToList();
            for (int i = 0; i < t.Count; i++)
                t[i].Rank = i + 1;
            return new ObservableCollection<Player>(t);
        }
    }
}
