using System;

namespace LB.Core
{
	public static class LeaderLoss
	{
		public static LeaderLossResult Resolve(int dice, int lossdie, int durationdie1, int durationdie2, bool melee) {
	    	var loss = melee ? (dice <= 12 || dice >= 64) : (dice >= 64);
	        var result = new LeaderLossResult();
	    
	        if (loss == true) {
	        	if (melee) {
                    result.Attacker = (dice <= 12);
                    result.Defender = !result.Attacker;
	            }
                else {
                    result.Defender = true;
                }
	            if (lossdie == 1) {
                    result.Killed = true;
                    result.Injury = "Head";
	            }
	            else if (lossdie == 2) {
                    result.Killed = true;
                    result.Injury = "Chest";
	            }
	            else if (lossdie == 3) {
                    result.Wounded = true;
                    result.Injury = "Leg";
                    result.Duration = durationdie1 + durationdie2;
	            }
	            else if (lossdie == 4) {
                    result.Wounded = true;
                    result.Injury = "Arm";
                    result.Duration = durationdie1;
	            }
	            else if (lossdie == 5) {
                    result.Captured = true;
                    result.Injury = "Capture";
	            }
	            else {//if (lossdie == 6) {
                    result.Injury = "Flesh Wound";
	            }
	        }
	        return result;
		}
	}
	
	public class LeaderLossResult
	{
		public LeaderLossResult(bool attacker = false, bool defender = false, bool wounded = false, bool killed = false, bool captured = false, string injury = "", int duration = 0)
		{
			Attacker = attacker;
			Defender = defender;
			Wounded = wounded;
			Killed = killed;
			Captured = captured;
			Injury = injury;
			Duration = duration;
		}
		
		public bool Attacker {get;set;}
		public bool Defender {get;set;}
		public bool Wounded {get;set;}
		public bool Killed {get;set;}
		public bool Captured {get;set;}
		public string Injury {get;set;}
		public int Duration {get;set;}
		
	}
}

