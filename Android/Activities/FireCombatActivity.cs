using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LB.Core;

namespace LB
{
	[Activity (Label = "La Bataille Assistant")]			
	public class FireCombatActivity : Activity
	{
		TextView txtBattleName;
		TextView txtScenarioName;
		ImageView imgBack;
		ImageView imgLb;
		
		Button btnAttackerValuePrev;
		Button btnAttackerValueNext;
		EditText editAttackerValue;
		ToggleButton btnAttackerMod13;
		ToggleButton btnAttackerMod12;
		ToggleButton btnAttackerMod32;
		ToggleButton btnAttackerModCann;
		
		Button btnDefenderValuePrev;
		Button btnDefenderValueNext;
		EditText editDefenderValue;
		
		Button btnDefenderIncrPrev;
		Button btnDefenderIncrNext;
		EditText editDefenderIncr;
		
		ImageView imgFireDie1;
		ImageView imgFireDie2;
		ImageView imgFireDie3;
		ImageView imgFireDie4;
		ImageView imgFireDie5;
		Button btnFireDiceRoll;
		
		TextView txtFireResults;
		TextView txtFireLeaderLoss;
		ImageView imgFireLeaderLossSide;
		ImageView imgFireLeaderLoss;
		
		Spinner spinFireOdds;
		
		Game game;
		
		Dice dice;
		FireCombat fc;
		Odds odds;

		double[] DefenseValues = new double[] {4,6,7,8,9,10,12,14,16,18};
		
		protected override void OnCreate (Bundle bundle)
		{
			dice = new Dice(5, 1, 6);
			fc = new FireCombat();
			odds = fc.DefaultOdds;
		
			base.OnCreate (bundle);

			game = LbManager.GetGame(Intent.GetIntExtra ("Battle", -1), Intent.GetIntExtra("Scenario", -1));

			// set our layout to be the home screen
			SetContentView(Resource.Layout.FireCombat);		

			imgBack = FindViewById<ImageView> (Resource.Id.titleSubLbBack);
			imgLb = FindViewById<ImageView> (Resource.Id.titleSubLb);

			// title
			txtBattleName = FindViewById<TextView>(Resource.Id.titleSubBattleName);
			txtScenarioName = FindViewById<TextView>(Resource.Id.titleSubScenarioName);
			
			// attacker
			btnAttackerValuePrev = FindViewById<Button>(Resource.Id.btnFireAttackerPrev);
			btnAttackerValueNext = FindViewById<Button>(Resource.Id.btnFireAttackerNext);
			editAttackerValue = FindViewById<EditText>(Resource.Id.textFireAttackerValue);
			btnAttackerMod13 = FindViewById<ToggleButton>(Resource.Id.btnFireAttacker13);
			btnAttackerMod12 = FindViewById<ToggleButton>(Resource.Id.btnFireAttacker12);
			btnAttackerMod32 = FindViewById<ToggleButton>(Resource.Id.btnFireAttacker32);
			btnAttackerModCann = FindViewById<ToggleButton>(Resource.Id.btnFireAttackerCann);
			
			// defender
			btnDefenderValuePrev = FindViewById<Button>(Resource.Id.btnFireDefenderPrev);
			btnDefenderValueNext = FindViewById<Button>(Resource.Id.btnFireDefenderNext);
			editDefenderValue = FindViewById<EditText>(Resource.Id.textFireDefenderValue);
			
			btnDefenderIncrPrev = FindViewById<Button>(Resource.Id.btnFireDefenderIncrPrev);
			btnDefenderIncrNext = FindViewById<Button>(Resource.Id.btnFireDefenderIncrNext);
			editDefenderIncr = FindViewById<EditText>(Resource.Id.textFireDefenderIncr);
			
			editAttackerValue.Text = "1";
			editDefenderValue.Text = "1";
			editDefenderIncr.Text = "1";
			
			spinFireOdds = FindViewById<Spinner> (Resource.Id.spinFireOdds);
			
			imgFireDie1 = FindViewById<ImageView> (Resource.Id.imgFireDie1);
			imgFireDie2 = FindViewById<ImageView> (Resource.Id.imgFireDie2);
			imgFireDie3 = FindViewById<ImageView> (Resource.Id.imgFireDie3);
			imgFireDie4 = FindViewById<ImageView> (Resource.Id.imgFireDie4);
			imgFireDie5 = FindViewById<ImageView> (Resource.Id.imgFireDie5);
			btnFireDiceRoll = FindViewById<Button>(Resource.Id.btnFireDiceRoll);
			
			// results
			txtFireResults = FindViewById<TextView>(Resource.Id.txtFireResults);
			//txtFireResults.SetText(txtFireResults.Text, TextView.BufferType.Editable);
			imgFireLeaderLossSide = FindViewById<ImageView>(Resource.Id.imgFireLeaderLossSide);
			txtFireLeaderLoss = FindViewById<TextView>(Resource.Id.txtFireLeaderLoss);
			//txtFireLeaderLoss.SetText(txtFireLeaderLoss.Text, TextView.BufferType.Editable);
			imgFireLeaderLoss = FindViewById<ImageView>(Resource.Id.imgFireLeaderLoss);
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			imgBack.Click += (sender, e) => {
				NavigateUp();
			};

			imgLb.Click += (sender, e) => {
				NavigateUp();
			};

			txtBattleName.Text = game.Battle.Name;
			txtScenarioName.Text = game.Scenario.Name;
			
			// attacker
			btnAttackerValuePrev.Click += (sender, e) => {
				var value = GetAttackerValue();
				if (--value < 1) value = 1;
				editAttackerValue.Text = value.ToString();
				CalcOdds();
				UpdateResults();
			};
			btnAttackerValueNext.Click += (sender, e) => {
				var value = GetAttackerValue();
				editAttackerValue.Text = (++value).ToString();
				CalcOdds();
				UpdateResults();
			};
			editAttackerValue.AfterTextChanged += (object sender, Android.Text.AfterTextChangedEventArgs e) => {
				CalcOdds();
				UpdateResults();
			};
			btnAttackerMod13.Click += (sender, e) => {
				var value = GetAttackerValue();
				if (btnAttackerMod13.Checked) 
				{
					value /= 3;
				}
				else
				{
					value *= 3;
				}
				editAttackerValue.Text = value.ToString();
				CalcOdds();
				UpdateResults();
			};
			btnAttackerMod12.Click += (sender, e) => {
				var value = GetAttackerValue();
				if (btnAttackerMod12.Checked) 
				{
					value /= 2;
				}
				else
				{
					value *= 2;
				}
				editAttackerValue.Text = value.ToString();
				CalcOdds();
				UpdateResults();
			};
			btnAttackerMod32.Click += (sender, e) => {
				var value = GetAttackerValue();
				if (btnAttackerMod32.Checked) 
				{
					value *= 1.5;
				}
				else
				{
					value /= 1.5;
				}
				editAttackerValue.Text = value.ToString();
				CalcOdds();
				UpdateResults();
			};
			btnAttackerModCann.Click += (sender, e) => {
				UpdateResults();
			};

			// defender
			btnDefenderValuePrev.Click += (sender, e) => {
				double value = GetDefenderValue();
				value = FindNearestDefenseValue(value - 1, true);
				editDefenderValue.Text = value.ToString();
				CalcOdds();
				UpdateResults();
			};
			btnDefenderValueNext.Click += (sender, e) => {
				double value = GetDefenderValue();
				value = FindNearestDefenseValue(value + 1, false);
				editDefenderValue.Text = value.ToString();
				CalcOdds();
				UpdateResults();
			};
			editDefenderValue.AfterTextChanged += (object sender, Android.Text.AfterTextChangedEventArgs e) => {
				CalcOdds();
				UpdateResults();
			};
			
			btnDefenderIncrPrev.Click += (sender, e) => {
				var value = GetDefenderIncrements();
				if (--value < 1) value = 1;
				editDefenderIncr.Text = value.ToString();
				UpdateResults();
			};
			btnDefenderIncrNext.Click += (sender, e) => {
				var value = GetDefenderIncrements();
				editDefenderIncr.Text = (++value).ToString();
				UpdateResults();
			};
			editDefenderIncr.AfterTextChanged += (object sender, Android.Text.AfterTextChangedEventArgs e) => {
				UpdateResults();
			};
			
			spinFireOdds.ItemSelected +=  (object sender, AdapterView.ItemSelectedEventArgs e) => {
				odds = fc.OddsItem(e.Position);
				UpdateResults();
			};
				
			ArrayAdapter<String> adapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleSpinnerDropDownItem, fc.OddsList);
			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinFireOdds.Adapter = adapter;
			
			
			imgFireDie1.Click += (sender, e) => {
				IncrementDie(1);
				DisplayDice();
				UpdateResults();
			};
			imgFireDie2.Click += (sender, e) => {
				IncrementDie(2);
				DisplayDice();
				UpdateResults();
			};
			imgFireDie3.Click += (sender, e) => {
				IncrementDie(3);
				DisplayDice();
				UpdateResults();
			};
			imgFireDie4.Click += (sender, e) => {
				IncrementDie(4);
				DisplayDice();
				UpdateResults();
			};
			imgFireDie5.Click += (sender, e) => {
				IncrementDie(5);
				DisplayDice();
				UpdateResults();
			};
			
			btnFireDiceRoll.Click += (sender, e) => {
				dice.Roll();
				DisplayDice();
				UpdateResults();
			};
			
			DisplayOdds();
			DisplayDice();
		}
		
		void CalcOdds() 
		{
			odds = fc.Calculate(GetAttackerValue(), GetDefenderValue(), btnAttackerModCann.Checked);
			if (odds == null)
				odds = fc.DefaultOdds;
			DisplayOdds();
		}
		
		void UpdateResults()
		{
			int d = (dice[0]*10) + dice[1];
			string result = fc.Resolve(odds, GetDefenderIncrements(), d);
			txtFireResults.SetText(result, TextView.BufferType.Normal);
						
			LeaderLossResult ll = fc.ResolveLeaderLoss(d, dice[2], dice[3], dice[4]);			
			imgFireLeaderLossSide.Visibility = (ll.Killed || ll.Wounded || ll.Captured) ? ViewStates.Visible : ViewStates.Invisible;
			imgFireLeaderLossSide.SetImageResource (ll.Attacker ? Resource.Drawable.attacker : Resource.Drawable.defender);
			txtFireLeaderLoss.Visibility = (ll.Killed || ll.Wounded || ll.Captured) ? ViewStates.Visible : ViewStates.Invisible;
			string loss = ll.Injury + (ll.Wounded ? (" " + ll.Duration.ToString () + " hours") : "");
			txtFireLeaderLoss.SetText(loss, TextView.BufferType.Normal);

			imgFireLeaderLoss.Visibility = (ll.Killed || ll.Wounded || ll.Captured) ? ViewStates.Visible : ViewStates.Invisible;
			imgFireLeaderLoss.SetImageResource(ll.Captured ? Resource.Drawable.capture : (ll.Wounded ? Resource.Drawable.ambulance : Resource.Drawable.tombstone));
		}
		
		void DisplayOdds()
		{
			spinFireOdds.SetSelection(fc.OddsIndex(odds.Name));
		}

		void DisplayDice()
		{
			imgFireDie1.SetImageResource(DiceResources.GetWhiteBlack(dice[0]));
			imgFireDie2.SetImageResource(DiceResources.GetRedWhite(dice[1]));
			imgFireDie3.SetImageResource(DiceResources.GetBlue(dice[2]));
			imgFireDie4.SetImageResource(DiceResources.GetBlackWhite(dice[3]));
			imgFireDie5.SetImageResource(DiceResources.GetBlackRed(dice[4]));
		}

		double GetAttackerValue()
		{
			double value = 1;
			Double.TryParse(editAttackerValue.Text, out value);
			return value;
		}
		double GetDefenderValue()
		{
			double value = 1;
			Double.TryParse(editDefenderValue.Text, out value);
			return value;
		}
		int GetDefenderIncrements()
		{
			int value = 1;
			Int32.TryParse(editDefenderIncr.Text, out value);
			return value;
		}
		
		double FindNearestDefenseValue(double value, bool neg)
		{
			if (neg) 
			{
            	for (var i=DefenseValues.Length-1; i>=0; i--) {
                	if (DefenseValues[i] <= value) {
                    	return DefenseValues[i];
                    }
                }
            	return DefenseValues[0];
			}
			
        	for (var i=0; i<DefenseValues.Length; i++) {
            	if (DefenseValues[i] >= value) {
                	return DefenseValues[i];
                }
            }
        	return DefenseValues[DefenseValues.Length-1];
		}
			
		void IncrementDie(int die)
		{
			int value = dice[die-1];
			if (++value > 6) value = 1;
			dice[die-1] = value;
		}
			
		void NavigateUp()
		{
			var battleDetail = new Intent (this, typeof(BattleActivity));
			battleDetail.PutExtra("Battle", game.Battle.Id);
			battleDetail.PutExtra ("Scenario", game.Scenario.Id);

			StartActivity (battleDetail);
		}
	}
}

