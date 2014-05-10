using System;
using System.Collections;

namespace LB.Core
{
	public class Base6Value
	{		
		public Base6Value(int value)
		{
			this.Value = value;
		}
		public Base6Value(int die1, int die2)
			: this(die1 * 10 + die2)
		{
		}
		public Base6Value()
			: this(0)
		{
		}
		
		public int Value
		{
			get
			{
				return value_;
			}
			set
			{
				if 		(value < 11) value_ = 11;
				else if (value > 66) value_ = 66;
				else 				 value_ = value;
			}
		}
		
		public override string ToString()
		{
			return value_.ToString();
		}

		public int  Add(int v)
		{
			this.Value = op(this.Value, v, true);
			return this.Value;
		}
		
		public int Subtract(int v)
		{
			this.Value = op(this.Value, v, false);
			return this.Value;
		}

		public static Base6Value operator+(Base6Value lhs, int rhs)
		{
			lhs.Value = op(lhs.Value, rhs, true);
			return lhs;
		}

		public static Base6Value operator-(Base6Value lhs, int rhs)
		{
			lhs.Value = op(lhs.Value, rhs, false);
			return lhs;
		}
		
		private static int op(int lhs, int rhs, bool add)
		{
			int index=-1;
			for (int i=0; i<Base6Value.Table.Count && index==-1; i++)
			{
				if (lhs == (int)Base6Value.Table[i])
					index = i;
			}
			
			if (index >= 0)
			{
				if (add)
					index += rhs;
				else
					index -= rhs;
				if 		(index < 0) 				index = 0;
				else if (index >= Base6Value.Table.Count) index = Base6Value.Table.Count - 1;
				
				return (int)Base6Value.Table[index];
			}
			else
			{
				return lhs;
			}
		}
		
		static ArrayList Table
		{
			get
			{
				if (table_ == null)
				{
					table_ = new ArrayList();
					
					for (int i=1; i<=6; i++)
						for (int j=1; j<=6; j++)
							table_.Add(i*10 + j);
				}
			
				return table_;
			}
		}
		static ArrayList table_;
		
		private int value_;
	}
}
