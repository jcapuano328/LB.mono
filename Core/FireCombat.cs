using System;
using System.Collections.Generic;

namespace LB.Core
{
	public class FireCombat
	{
		IList<Odds> oddsTable;
	
		public FireCombat ()
		{
			oddsTable = new List<Odds>() {
		    	new Odds(-3, "1:3"),
		    	new Odds(-2.5, "1:2.5"),
		    	new Odds(-2, "1:2"),
		    	new Odds(-1.5, "1:1.5"),
		    	new Odds(1, "1:1"),
		    	new Odds(1.5, "1.5:1"),
		    	new Odds(2, "2:1"),
		    	new Odds(2.5, "2.5:1"),
		    	new Odds(3, "3:1"),
		    	new Odds(4, "4:1"),
		    	new Odds(5, "5:1"),
		    	new Odds(6, "6:1"),
		    	new Odds(7, "7:1"),
		    	new Odds(8, "8:1"),
		    	new Odds(9, "9:1"),
		    	new Odds(10, "10:1")
			};
		}
		
		public Odds DefaultOdds
		{
			get
			{
				return oddsTable[4];
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
		
		
		public Odds Calculate(double att, double def, bool cannister) 
		{
        	return Odds.Calculate(oddsTable, att, def, (cannister ? 1 : 0));
        }
		
		public string Resolve(Odds odds, int defincr, int dice) 
		{
	    	if (defincr > 9) 
			{
	        	var b6i = new Base6Value(dice);
	        	dice = b6i.Add(defincr - 9);
	        }
	        
	        var result = "NE";
			if (odds.Value == -3)
			{	//1-3
				if (dice >= 65) {
					result = "1";
	            }
			}
			else if (odds.Value == -2.5)
			{	//1-2.5
				if (dice >= 64) {
					result = "1";
                }
			}
			else if (odds.Value == -2)
			{	//1-2
				if (dice >= 62) {
					result = "1";
                }
			}
			else if (odds.Value == -1.5)
			{	//1-1.5
				if (dice >= 55) {
					result = "1";
                }
			}
			else if (odds.Value == 1)
			{	//1-1
				if (dice >= 51) {
					result = "1";
                }
			}
			else if (odds.Value == 1.5)
			{	//1.5-1
				if (dice >= 42) {
					result = "1";
                }
			}
			else if (odds.Value == 2)
			{	//2-1
				if (dice >= 33) {
					result = "1";
                }
			}
			else if (odds.Value == 2.5)
			{	//2.5-1
				if (dice >= 64) {
					result = "2";
                }
				else if (dice >= 26) {
					result = "1";
                }
			}
			else if (odds.Value == 3)
			{	//3-1
				if 	(dice >= 56) {
					result = "2";
                }
				else if (dice >= 22) {
					result = "1";
                }
			}
			else if (odds.Value == 4)
			{	//4-1
				if (dice >= 54) {
					result = "2";
                }
				else if (dice >= 13) {
					result = "1";
                }
			}
			else if (odds.Value == 5)
			{	//5-1
				if (dice >= 66) {
					result = "3";
                }
				else if (dice >= 45) {
					result = "2";
                }
				else if (dice >= 11) {
					result = "1";
                }
			}
			else if (odds.Value == 6)
			{	//6-1
				if (dice >= 62) {
					result = "3";
                }
				else if (dice >= 33) {
					result = "2";
                }
				else if (dice >= 11) {
					result = "1";
                }
			}
			else if (odds.Value == 7)
			{	//7-1
				if (dice >= 52) {
					result = "3";
                }
				else if (dice >= 23) {
					result = "2";
                }
				else if (dice >= 11) {
					result = "1";
                }
			}
			else if (odds.Value == 8)
			{	//8-1
				if (dice >= 66) {
					result = "4";
                }
				else if (dice >= 45) {
					result = "3";
                }
				else if (dice >= 15) {
					result = "2";
                }
				else if (dice >= 11) {
					result = "1";
                }
			}
			else if (odds.Value == 9)
			{	//9-1
				if (dice >= 63) {
					result = "4";
                }
				else if (dice >= 42) {
					result = "3";
                }
				else if (dice >= 11) {
					result = "2";
                }
			}
			else if (odds.Value == 10)
			{	//10-1
				if (dice >= 65) {
					result = "5";
                }
				else if (dice >= 55) {
					result = "4";
                }
				else if (dice >= 26) {
					result = "3";
                }
				else if (dice >= 11) {
					result = "2";
                }
			}
			else 
			{
				result = "NE";
			}
			
	        /*
			if (dice >= 65) {
	        	result += " &";
			}            
			*/
	        
	        return result;
		}
		
		public LeaderLossResult ResolveLeaderLoss(int dice, int lossdie, int durationdie1, int durationdie2) 
		{
			return LeaderLoss.Resolve(dice, lossdie, durationdie1, durationdie2, false);
		}
	}
}

