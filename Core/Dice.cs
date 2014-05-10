using System;
using System.Collections.Generic;

namespace LB.Core
{
	public class Dice
	{
		public Dice(int numdice, int low, int high)
		{
			for (int i=0; i<numdice; i++)
				AddDie(low, high);
		}
    
		public int this[int die]
		{
			get
			{
				if (die >= 0 && die < _dice.Count)
					return _dice[die].Value; 
				return 0;
			}
			set
			{
				if (die >= 0 && die < _dice.Count)
					_dice[die].Value = value;
			}
		}
		
		public int Count
		{
			get{return _dice.Count;}
		}

		public void AddDie(int rangelow, int rangehigh)
		{
			_dice.Add(new Die(rangelow, rangehigh));
		}
		public void RemoveDie(int die)
		{
			if (die >= 0 && die < _dice.Count)
				_dice.RemoveAt(die);
		}
		public void Clear()
		{
			_dice.Clear();
		}
		public Die GetDie(int die)
		{
			if (die >= 0 && die < _dice.Count)
				return _dice[die]; 
			return null;
		}

		public void Roll()
		{
			foreach (Die die in _dice)
				die.Roll();
		}
		
		private IList<Die> _dice = new List<Die>();
	}
	
	public class Die
	{
		public Die(int rangelo, int rangehi)
		{
			_rangelow = rangelo;
			_rangehigh = rangehi;
			_value = _rangelow;
		}

		public int RangeLow
		{
			get{return _rangelow;}
			set{_rangelow = value;}
		}

		public int RangeHigh
		{
			get{return _rangehigh;}
			set{_rangehigh = value;}
		}

		public int Value
		{
			get{return _value;}
			set{_value = value;}
		}
		
		public int Increment(bool rollover)
		{
        	if (++_value > _rangehigh) {
            	_value = rollover ? _rangelow : _rangehigh;
            }
			return _value;
		}
		
	    public int Decrement(bool rollover) 
		{
        	if (--_value < _rangelow) {
            	_value = rollover ? _rangehigh : _rangelow;
            }
			return _value;
        }
		
		public int Roll()
		{		
			_value = _random.Next(_rangelow, _rangehigh+1);
			
			return _value;
		}
    
		private int _rangelow = 0;
		private int _rangehigh = 0;
		private int _value = 0;
		
		private static Random _random = new Random();		
	}
}

