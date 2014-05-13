using System;
using System.Collections.Generic;

namespace LB.Core
{
	public class MeleeCombat
	{
		IList<Odds> oddsTable;
	
		public MeleeCombat ()
		{
			oddsTable = new List<Odds>() {
		    	new Odds(-2, "1:2"),
		    	new Odds(1, "1:1"),
		    	new Odds(1.5, "1.5:1"),
		    	new Odds(2, "2:1"),
		    	new Odds(2.5, "2.5:1"),
		    	new Odds(3, "3:1"),
		    	new Odds(3.5, "3.5:1"),
		    	new Odds(4, "4:1"),
		    	new Odds(4.5, "4.5:1"),
		    	new Odds(5, "5:1")
			};
		}
		
		public Odds DefaultOdds
		{
			get
			{
				return oddsTable[1];
			}
		}
		
		public string[] OddsList
		{
			get
			{
				List<string> odds = new List<string>();
				foreach (Odds o in oddsTable)
					odds.Add(o.Name);
				return odds.ToArray();
			}
		}
		
		public int OddsIndex(string name)
		{
			for (int i=0; i<oddsTable.Count; i++)
			{
				if (oddsTable[i].Name == name)
					return i;
			}
			return 4;
		}
		
		
		public Odds OddsItem(int idx)
		{
			if (idx >= 0 && idx < oddsTable.Count)
				return oddsTable[idx];
			return DefaultOdds;
		}
		
		
		public Odds Calculate(double att, double def) 
		{
        	return Odds.Calculate(oddsTable, att, def, 0);
        }
		
		public string Resolve(Odds odds, int dice) 
		{
			var result = "Blank";
			if (odds.Value == -2)
			{
				if (dice <= 14) {
					result = "AR";
                }
				else if (dice <= 34) {
					result = "AD";
				}
				else if (dice == 52) {
					result = "0*/0";
                }
				else if (dice == 53) {
					result = "1/1";
                }
				else if (dice == 54) {
					result = "1/2*";
                }
				else if (dice == 55) {
					result = "0/1";
                }
				else if (dice == 56) {
					result = "1*/0";
                }

				else if (dice == 61) {
					result = "0/2";
                }
				else if (dice == 62) {
					result = "2/1*";
                }
				else if (dice == 63) {
					result = "0/0";
                }
				else if (dice == 64) {
					result = "2/2";
                }

				else if (dice >= 65) {
					result = "DD";
                }
			}
			else if (odds.Value == 1)
			{
				if 		(dice <= 15) {
					result = "AD";
                }

				else if (dice == 42) {
					result = "2*/1";
                }
				else if (dice == 43) {
					result = "2/1*";
                }
				else if (dice == 44) {
					result = "2/1";
                }
				else if (dice == 45) {
					result = "1*/1";
                }
				else if (dice == 46) {
					result = "1/2";
                }

				else if (dice == 51) {
					result = "1/1";
                }
				else if (dice == 52) {
					result = "0/0*";
                }
				else if (dice == 53) {
					result = "2/1";
                }
				else if (dice == 54) {
					result = "1*/2";
                }
				else if (dice == 55) {
					result = "2/2";
                }
				else if (dice == 56) {
					result = "0/0";
                }

				else if (dice == 61) {
					result = "1/0*";
                }
					
				else if (dice >= 62) {
					result = "DD";
                }
			}
			else if (odds.Value == 1.5)
			{
				if 		(dice <= 12) {
					result = "AD";
                }

				else if (dice == 33) {
					result = "1/2";
                }
				else if (dice == 34) {
					result = "0/0";
                }
				else if (dice == 35) {
					result = "1/1";
                }
				else if (dice == 36) {
					result = "2*/0";
                }

				else if (dice == 41) {
					result = "0/1*";
                }
				else if (dice == 42) {
					result = "1/1";
                }
				else if (dice == 43) {
					result = "2/2*";
                }
				else if (dice == 44) {
					result = "3/1";
                }
				else if (dice == 45) {
					result = "0/2";
                }
				else if (dice == 46) {
					result = "2/1";
                }

				else if (dice == 51) {
					result = "1/1*";
                }
				else if (dice == 52) {
					result = "2*/1";
                }

				else if (dice >= 53) {
					result = "DD";
                }
			}
			else if (odds.Value == 2)
			{
				if 		(dice <= 11) {
					result = "AD";
                }

				else if (dice == 25) {
					result = "0/3";
                }
				else if (dice == 26) {
					result = "1/2";
                }
				else if (dice == 31) {
					result = "2*/1";
                }
				else if (dice == 32) {
					result = "0/0";
                }
				else if (dice == 33) {
					result = "0/1*";
                }
				else if (dice == 34) {
					result = "1/0";
                }
				else if (dice == 35) {
					result = "3/2*";
                }
				else if (dice == 36) {
					result = "1/1";
                }
				else if (dice == 41) {
					result = "2/2*";
                }
				else if (dice == 42) {
					result = "1*/2";
                }
				else if (dice == 43) {
					result = "1*/1";
                }
				else if (dice == 44) {
					result = "0/2*";
                }
					
				else if (dice >= 45) {
					result = "DD";
                }
			}
			else if (odds.Value == 2.5)
			{
				if 		(dice == 23) {
					result = "1/4";
                }
				else if (dice == 24) {
					result = "2/3";
                }
				else if (dice == 25) {
					result = "0*/0";
                }
				else if (dice == 26) {
					result = "1/1*";
                }
				else if (dice == 31) {
					result = "2/3*";
                }
				else if (dice == 32) {
					result = "3/3";
                }
				else if (dice == 33) {
					result = "0/1";
                }
				else if (dice == 34) {
					result = "1/0";
                }
				else if (dice == 35) {
					result = "2/2*";
                }

				else if (dice >= 36) {
					result = "DD";
                }
			}
			else if (odds.Value == 3)
			{
				if 		(dice == 16) {
					result = "0/0*";
                }
				else if (dice == 21) {
					result = "2/3";
                }
				else if (dice == 22) {
					result = "0/2";
                }
				else if (dice == 23) {
					result = "2*/0";
                }
				else if (dice == 24) {
					result = "1/2";
                }
				else if (dice == 25) {
					result = "0/1";
                }
				else if (dice == 26) {
					result = "2*/3";
                }
				else if (dice == 31) {
					result = "1/2*";
                }
					
				else if (dice >= 65) {
					result = "DR";
                }

				else if (dice >= 32) {
					result = "DD";
                }
			}
			else if (odds.Value == 3.5)
			{
				if 		(dice == 12) {
					result = "0/0";
                }
				else if (dice == 13) {
					result = "2*/2";
                }
				else if (dice == 14) {
					result = "3/3";
                }
				else if (dice == 15) {
					result = "2/4";
                }
				else if (dice == 16) {
					result = "3/1";
                }
				else if (dice == 21) {
					result = "0/1*";
                }
					
				else if (dice >= 62) {
					result = "DR";
                }

				else if (dice >= 22) {
					result = "DD";
                }
			}
			else if (odds.Value == 4)
			{
				if 		(dice == 11) {
					result = "2*/1";
                }
				else if (dice == 12) {
					result = "1/2";
                }
				else if (dice == 13) {
					result = "0/2";
                }
				else if (dice == 14) {
					result = "0/1*";
                }
				else if (dice == 15) {
					result = "1/1*";
                }
					
				else if (dice >= 56) {
					result = "DR";
                }

				else if (dice >= 16) {
					result = "DD";
                }
			}
			else if (odds.Value == 4.5)
			{
				if 		(dice == 11) {
					result = "3/2";
                }

				else if (dice >= 66) {
					result = "DS";
                }

				else if (dice >= 42) {
					result = "DR";
                }

				else if (dice >= 12) {
					result = "DD";
                }
			}
			else if (odds.Value == 5)
			{
				if (dice >= 62) {
					result = "DS";
                }

				else if (dice >= 33) {
					result = "DR";
                }

				else if (dice >= 11) {
					result = "DD";
                }
			}
			else
			{
				result = "Blank";
			}
			
	        /*
			if (dice <= 12) {
	        	result = "& " + result;
	        } 
			else if (dice >= 64) {
		        result += " &";
	        }
	        */

	        return result;
		}
		
		public LeaderLossResult ResolveLeaderLoss(int dice, int lossdie, int durationdie1, int durationdie2) 
		{
			return LeaderLoss.Resolve(dice, lossdie, durationdie1, durationdie2, true);
		}
	}
}

