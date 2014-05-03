using System;

namespace LB.Core
{
	public class Game
	{
		Lb _saved;
		string[] _phases = new string[] {
			"Command",
			"Imperial: Charge a Cheval",
			"Imperial: Movement",
			"Imperial: Defensive Fire",
			"Imperial: Offensive Fire",
			"Imperial: Melee Assault",
			"Imperial: Rally",
			"Imperial: Rout",
			"Imperial: Readiness Recovery",
			"Sovereign: Charge a Cheval",
			"Sovereign: Movement",
			"Sovereign: Defensive Fire",
			"Sovereign: Offensive Fire",
			"Sovereign: Melee Assault",
			"Sovereign: Rally",
			"Sovereign: Rout",
			"Sovereign: Readiness Recovery"
		};
		
		public Game(Battle battle, Scenario scenario, Lb saved)
		{
			this.Battle = battle;
			this.Scenario = scenario;
			_saved = saved;
			if (_saved.Battle != battle.Id || _saved.Scenario != scenario.Id)
				_saved.Reset(battle, scenario);
		}
		
		public Battle Battle {get; private set;}
	
		public Scenario Scenario {get; private set;}
		
		public Lb Saved {get; private set;}
	
		public string CurrentTurn
		{
			get
			{
				DateTime sd = new DateTime(this.Scenario.StartYear,this.Scenario.StartMonth,this.Scenario.StartDay,this.Scenario.StartHour,this.Scenario.StartMinute, 0);
				DateTime ed = new DateTime(this.Scenario.EndYear,this.Scenario.EndMonth,this.Scenario.EndDay,this.Scenario.EndHour,this.Scenario.EndMinute, 0);
			
				DateTime dt = new DateTime(this.Scenario.StartYear,this.Scenario.StartMonth,this.Scenario.StartDay,this.Scenario.StartHour,this.Scenario.StartMinute, 0);
				int offset = turnOffset(_saved.Turn);
				dt = dt.AddMinutes(offset);
				
		        if (dt < sd) {
		        	dt = sd;
					_saved.Turn = 1;
		        }
		        else if (dt > ed) {
		        	dt = ed;
					_saved.Turn -= 1;
		        }
				
                return dt.ToString("MMMM d, yyyy  hh:mm tt");
			}
		}
	
		public string CurrentPhase
		{
			get
			{
				if (_saved.Phase < 0) 
				{
					_saved.Phase = 0;
				}
            	else if (_saved.Phase >= _phases.Length) 
				{
					_saved.Phase = _phases.Length-1;
				}
                return _phases[_saved.Phase];
			}
		}

		public void Reset()
		{
			_saved.Reset (this.Battle, this.Scenario);
		}
		
		public void NextTurn()
		{
			_saved.Turn++;
		}
		
		public void PrevTurn()
		{
			_saved.Turn--;
		}
		
		public void NextPhase()
		{
			
			if (++_saved.Phase >= _phases.Length)
			{
				NextTurn();
				_saved.Phase = 0;
			}
		}
		
		public void PrevPhase()
		{
			
			if (--_saved.Phase < 0)
			{
				PrevTurn();
				_saved.Phase = _phases.Length - 1;
			}
		}
				
		int turnOffset(int turn) 
		{
        	return (turn - 1) * 20;
        }
	}
}

