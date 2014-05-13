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
	public class MeleeActivity : Activity
	{
		TextView txtBattleName;
		TextView txtScenarioName;
		ImageView imgBack;
		ImageView imgLb;
		
		Button btnMeleeAttackerPrev;
		Button btnMeleeAttackerNext;
		EditText editMeleeAttackerValue;
		Button btnMeleeAttackerAdd;
		Button btnMeleeAttackerReset;
		
		Button btnMeleeDefenderPrev;
		Button btnMeleeDefenderNext;
		EditText editMeleeDefenderValue;
		Button btnMeleeDefenderAdd;
		Button btnMeleeDefenderReset;
		
		Spinner spinMeleeOdds;
		
		ImageView imgMeleeDie1;
		ImageView imgMeleeDie2;
		ImageView imgMeleeDie3;
		ImageView imgMeleeDie4;
		ImageView imgMeleeDie5;
		Button btnMeleeDiceRoll;
		
		TextView txtMeleeResults;
		TextView txtMeleeLeaderLoss;
		ImageView imgMeleeLeaderLossSide;
		ImageView imgMeleeLeaderLoss;
		
		Button btnMeleeIncrPrev;
		Button btnMeleeIncrNext;
		EditText editMeleeIncrValue;
		
		Button btnMeleeLossPrev;
		Button btnMeleeLossNext;
		EditText editMeleeLossValue;
		
		Button btnMeleeValuePrev;
		Button btnMeleeValueNext;
		EditText editMeleeValueValue;
		
		Button btnMeleeLancePrev;
		Button btnMeleeLanceNext;
		EditText editMeleeLanceValue;
		
		Button btnMeleeTotalPrev;
		Button btnMeleeTotalNext;
		EditText editMeleeTotalValue;
		
		ToggleButton btnMeleeMods13;
		ToggleButton btnMeleeMods12;
		ToggleButton btnMeleeMods32;
		ToggleButton btnMeleeMods2;
		ToggleButton btnMeleeModsLnc;
		
		Game game;
		
		Dice dice;
		MeleeCombat mc;
		Odds odds;
		PlayAudio audio;

		protected override void OnCreate (Bundle bundle)
		{
			dice = new Dice(5, 1, 6);
			mc = new MeleeCombat();
			odds = mc.DefaultOdds;
			audio = new PlayAudio (this);
		
			base.OnCreate (bundle);

			game = LbManager.GetGame(Intent.GetIntExtra ("Battle", -1), Intent.GetIntExtra("Scenario", -1));

			// set our layout to be the home screen
			SetContentView(Resource.Layout.Melee);		

			imgBack = FindViewById<ImageView> (Resource.Id.titleSubLbBack);
			imgLb = FindViewById<ImageView> (Resource.Id.titleSubLb);

			// title
			txtBattleName = FindViewById<TextView>(Resource.Id.titleSubBattleName);
			txtScenarioName = FindViewById<TextView>(Resource.Id.titleSubScenarioName);
			
			btnMeleeAttackerPrev	 = FindViewById<Button>(Resource.Id.btnMeleeAttackerPrev	);
			btnMeleeAttackerNext		 = FindViewById<Button>(Resource.Id.btnMeleeAttackerNext	);
			editMeleeAttackerValue	 = FindViewById<EditText>(Resource.Id.editMeleeAttackerValue);
			btnMeleeAttackerAdd		 = FindViewById<Button>(Resource.Id.btnMeleeAttackerAdd		);
			btnMeleeAttackerReset	 = FindViewById<Button>(Resource.Id.btnMeleeAttackerReset	);
			
			btnMeleeDefenderPrev	 = FindViewById<Button>(Resource.Id.btnMeleeDefenderPrev	);
			btnMeleeAttackerNext		 = FindViewById<Button>(Resource.Id.btnMeleeAttackerNext	);
			editMeleeDefenderValue	 = FindViewById<EditText>(Resource.Id.editMeleeDefenderValue);
			btnMeleeDefenderAdd		 = FindViewById<Button>(Resource.Id.btnMeleeDefenderAdd		);
			btnMeleeDefenderReset	 = FindViewById<Button>(Resource.Id.btnMeleeDefenderReset	);
			
			spinMeleeOdds = FindViewById<Spinner> (Resource.Id.spinMeleeOdds);
			
			imgMeleeDie1 = FindViewById<ImageView> (Resource.Id.imgMeleeDie1);
			imgMeleeDie2 = FindViewById<ImageView> (Resource.Id.imgMeleeDie2);
			imgMeleeDie3 = FindViewById<ImageView> (Resource.Id.imgMeleeDie3);
			imgMeleeDie4 = FindViewById<ImageView> (Resource.Id.imgMeleeDie4);
			imgMeleeDie5 = FindViewById<ImageView> (Resource.Id.imgMeleeDie5);
			btnMeleeDiceRoll = FindViewById<Button>(Resource.Id.btnMeleeDiceRoll);
			
			txtMeleeResults = FindViewById<TextView>(Resource.Id.txtMeleeResults);
			imgMeleeLeaderLossSide = FindViewById<ImageView>(Resource.Id.imgMeleeLeaderLossSide);
			txtMeleeLeaderLoss = FindViewById<TextView>(Resource.Id.txtMeleeLeaderLoss);
			imgMeleeLeaderLoss = FindViewById<ImageView>(Resource.Id.imgMeleeLeaderLoss);
			
			btnMeleeIncrPrev	 = FindViewById<Button>(Resource.Id.btnMeleeIncrPrev	);
			btnMeleeIncrNext	 = FindViewById<Button>(Resource.Id.btnMeleeIncrNext	);
			editMeleeIncrValue	 = FindViewById<EditText>(Resource.Id.editMeleeIncrValue);
								
			btnMeleeLossPrev	 = FindViewById<Button>(Resource.Id.btnMeleeLossPrev	);
			btnMeleeLossNext	 = FindViewById<Button>(Resource.Id.btnMeleeLossNext	);
			editMeleeLossValue	 = FindViewById<EditText>(Resource.Id.editMeleeLossValue);
			
			btnMeleeValuePrev	 = FindViewById<Button>(Resource.Id.btnMeleeValuePrev	);
			btnMeleeValueNext	 = FindViewById<Button>(Resource.Id.btnMeleeValueNext	);
			editMeleeValueValue	 = FindViewById<EditText>(Resource.Id.editMeleeValueValue);
			
			btnMeleeLancePrev	 = FindViewById<Button>(Resource.Id.btnMeleeLancePrev	);
			btnMeleeLanceNext	 = FindViewById<Button>(Resource.Id.btnMeleeLanceNext	);
			editMeleeLanceValue	 = FindViewById<EditText>(Resource.Id.editMeleeLanceValue);
			
			btnMeleeTotalPrev	 = FindViewById<Button>(Resource.Id.btnMeleeTotalPrev	);
			btnMeleeTotalNext	 = FindViewById<Button>(Resource.Id.btnMeleeTotalNext	);
			editMeleeTotalValue	 = FindViewById<EditText>(Resource.Id.editMeleeTotalValue);
			
			btnMeleeMods13  = FindViewById<ToggleButton>(Resource.Id.btnMeleeMods13 );
			btnMeleeMods12  = FindViewById<ToggleButton>(Resource.Id.btnMeleeMods12 );
			btnMeleeMods32  = FindViewById<ToggleButton>(Resource.Id.btnMeleeMods32 );
			btnMeleeMods2   = FindViewById<ToggleButton>(Resource.Id.btnMeleeMods2  );
			btnMeleeModsLnc = FindViewById<ToggleButton>(Resource.Id.btnMeleeModsLnc);
			
			editMeleeAttackerValue.Text = "1";
			editMeleeDefenderValue.Text = "1";
			editMeleeIncrValue.Text = "1";
			editMeleeLossValue.Text = "1";
			editMeleeValueValue.Text = "1";
			editMeleeLanceValue.Text = "1";
			editMeleeTotalValue.Text = "1";
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
			btnMeleeAttackerPrev.Click += (sender, e) => {
				var value = GetAttackerValue();
				if (--value < 1) value = 1;
				editMeleeAttackerValue.Text = value.ToString();
				CalcOdds();
				UpdateResults();
			};
			btnMeleeAttackerNext.Click += (sender, e) => {
				var value = GetAttackerValue();
				editMeleeAttackerValue.Text = (++value).ToString();
				CalcOdds();
				UpdateResults();
			};
			editMeleeAttackerValue.AfterTextChanged += (object sender, Android.Text.AfterTextChangedEventArgs e) => {
				CalcOdds();
				UpdateResults();
			};
			// defender
			btnMeleeDefenderPrev.Click += (sender, e) => {
				double value = GetDefenderValue();
				if (--value < 1) value = 1;
				editMeleeDefenderValue.Text = value.ToString();
				CalcOdds();
				UpdateResults();
			};
			btnMeleeDefenderNext.Click += (sender, e) => {
				double value = GetDefenderValue();
				editMeleeDefenderValue.Text = (++value).ToString();
				CalcOdds();
				UpdateResults();
			};
			editMeleeDefenderValue.AfterTextChanged += (object sender, Android.Text.AfterTextChangedEventArgs e) => {
				CalcOdds();
				UpdateResults();
			};
			
			spinMeleeOdds.ItemSelected +=  (object sender, AdapterView.ItemSelectedEventArgs e) => {
				odds = mc.OddsItem(e.Position);
				UpdateResults();
			};
				
			ArrayAdapter<String> adapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleSpinnerDropDownItem, mc.OddsList);
			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinMeleeOdds.Adapter = adapter;
			
			
			imgMeleeDie1.Click += (sender, e) => {
				IncrementDie(1);
				DisplayDice();
				UpdateResults();
			};
			imgMeleeDie2.Click += (sender, e) => {
				IncrementDie(2);
				DisplayDice();
				UpdateResults();
			};
			imgMeleeDie3.Click += (sender, e) => {
				IncrementDie(3);
				DisplayDice();
				UpdateResults();
			};
			imgMeleeDie4.Click += (sender, e) => {
				IncrementDie(4);
				DisplayDice();
				UpdateResults();
			};
			imgMeleeDie5.Click += (sender, e) => {
				IncrementDie(5);
				DisplayDice();
				UpdateResults();
			};
			
			btnMeleeDiceRoll.Click += (sender, e) => {
				audio.Play();
				dice.Roll();
				DisplayDice();
				UpdateResults();
			};
			
			
			btnMeleeIncrPrev.Click += (sender, e) => {
				var value = GetMeleeIncrements();
				if (--value < 1) value = 1;
				editMeleeIncrValue.Text = value.ToString();
				UpdateUnit();
			};
			btnMeleeIncrNext.Click += (sender, e) => {
				var value = GetMeleeIncrements();
				editMeleeIncrValue.Text = (++value).ToString();
				UpdateResults();
			};
			editMeleeIncrValue.AfterTextChanged += (object sender, Android.Text.AfterTextChangedEventArgs e) => {
				UpdateUnit();
			};
			
			btnMeleeLossPrev.Click += (sender, e) => {
				var value = GetMeleeLoss();
				if (--value < 1) value = 1;
				editMeleeLossValue.Text = value.ToString();
				UpdateUnit();
			};
			btnMeleeLossNext.Click += (sender, e) => {
				var value = GetMeleeLoss();
				editMeleeLossValue.Text = (++value).ToString();
				UpdateUnit();
			};
			editMeleeLossValue.AfterTextChanged += (object sender, Android.Text.AfterTextChangedEventArgs e) => {
				UpdateUnit();
			};
			
			btnMeleeValuePrev.Click += (sender, e) => {
				var value = GetMeleeValue();
				if (--value < 1) value = 1;
				editMeleeValueValue.Text = value.ToString();
				UpdateUnit();
			};
			btnMeleeValueNext.Click += (sender, e) => {
				var value = GetMeleeValue();
				editMeleeValueValue.Text = (++value).ToString();
				UpdateUnit();
			};
			editMeleeValueValue.AfterTextChanged += (object sender, Android.Text.AfterTextChangedEventArgs e) => {
				UpdateUnit();
			};
			
			btnMeleeLancePrev.Click += (sender, e) => {
				var value = GetMeleeLance();
				if (--value < 1) value = 1;
				editMeleeLanceValue.Text = value.ToString();
				UpdateUnit();
			};
			btnMeleeLanceNext.Click += (sender, e) => {
				var value = GetMeleeLance();
				editMeleeLanceValue.Text = (++value).ToString();
				UpdateUnit();
			};
			editMeleeLanceValue.AfterTextChanged += (object sender, Android.Text.AfterTextChangedEventArgs e) => {
				UpdateUnit();
			};
			
			btnMeleeTotalPrev.Click += (sender, e) => {
				var value = GetMeleeTotal();
				if (--value < 1) value = 1;
				editMeleeTotalValue.Text = value.ToString();
			};
			btnMeleeTotalNext.Click += (sender, e) => {
				var value = GetMeleeTotal();
				editMeleeTotalValue.Text = (++value).ToString();
			};
			editMeleeTotalValue.AfterTextChanged += (object sender, Android.Text.AfterTextChangedEventArgs e) => {
			};
			
			
			btnMeleeMods13.Click += (sender, e) => {
				var value = GetMeleeTotal();
				if (btnMeleeMods13.Checked) 
				{
					value /= 3;
				}
				else
				{
					value *= 3;
				}
				editMeleeTotalValue.Text = value.ToString();
			};
			btnMeleeMods12.Click += (sender, e) => {
				var value = GetMeleeTotal();
				if (btnMeleeMods12.Checked) 
				{
					value /= 2;
				}
				else
				{
					value *= 2;
				}
				editMeleeTotalValue.Text = value.ToString();
			};
			btnMeleeMods32.Click += (sender, e) => {
				var value = GetMeleeTotal();
				if (btnMeleeMods32.Checked) 
				{
					value *= 1.5;
				}
				else
				{
					value /= 1.5;
				}
				editMeleeTotalValue.Text = value.ToString();
			};
			btnMeleeMods2.Click += (sender, e) => {
				var value = GetMeleeTotal();
				if (btnMeleeMods2.Checked) 
				{
					value *= 2;
				}
				else
				{
					value /= 2;
				}
				editMeleeTotalValue.Text = value.ToString();
			};
			
			btnMeleeModsLnc.Click += (sender, e) => {
				var value = GetMeleeLance();
				if (btnMeleeModsLnc.Checked) 
				{
					value *= 2;
				}
				else
				{
					value /= 2;
				}
				editMeleeLanceValue.Text = value.ToString();
				UpdateUnit();
			};

			
			DisplayOdds();
			DisplayDice();
		}
		
		void CalcOdds() 
		{
			odds = mc.Calculate(GetAttackerValue(), GetDefenderValue());
			if (odds == null)
				odds = mc.DefaultOdds;
			DisplayOdds();
		}
		
		void UpdateUnit()
		{
            var incr = GetMeleeIncrements();
	        var loss = GetMeleeLoss();
			double melee = GetMeleeValue();
			double lance = GetMeleeLance();
            
			double val = melee * ((double)(incr - loss) / (double)incr);
			if (btnMeleeMods13.Checked) 
	        	val /= 3.0;
			if (btnMeleeMods12.Checked) 
	        	val /= 2.0;
			if (btnMeleeMods32.Checked) 
	        	val *= 1.5;
			if (btnMeleeMods2.Checked) 
	        	val *= 2.0;
            
			if (btnMeleeModsLnc.Checked) 
            	lance *= 2.0;
            
			editMeleeTotalValue.Text = (val + lance).ToString();
		}
		
		void UpdateResults()
		{
			int d = (dice[0]*10) + dice[1];
			string result = mc.Resolve(odds, d);
			txtMeleeResults.SetText(result, TextView.BufferType.Normal);
						
			LeaderLossResult ll = mc.ResolveLeaderLoss(d, dice[2], dice[3], dice[4]);			
			imgMeleeLeaderLossSide.Visibility = (ll.Killed || ll.Wounded || ll.Captured) ? ViewStates.Visible : ViewStates.Invisible;
			imgMeleeLeaderLossSide.SetImageResource (ll.Attacker ? Resource.Drawable.attacker : Resource.Drawable.defender);
			txtMeleeLeaderLoss.Visibility = (ll.Killed || ll.Wounded || ll.Captured) ? ViewStates.Visible : ViewStates.Invisible;
			string loss = ll.Injury + (ll.Wounded ? (" " + ll.Duration.ToString () + " hours") : "");
			txtMeleeLeaderLoss.SetText(loss, TextView.BufferType.Normal);

			imgMeleeLeaderLoss.Visibility = (ll.Killed || ll.Wounded || ll.Captured) ? ViewStates.Visible : ViewStates.Invisible;
			imgMeleeLeaderLoss.SetImageResource(ll.Captured ? Resource.Drawable.capture : (ll.Wounded ? Resource.Drawable.ambulance : Resource.Drawable.tombstone));
		}
		
		void DisplayOdds()
		{
			spinMeleeOdds.SetSelection(mc.OddsIndex(odds.Name));
		}

		void DisplayDice()
		{
			imgMeleeDie1.SetImageResource(DiceResources.GetWhiteBlack(dice[0]));
			imgMeleeDie2.SetImageResource(DiceResources.GetRedWhite(dice[1]));
			imgMeleeDie3.SetImageResource(DiceResources.GetBlue(dice[2]));
			imgMeleeDie4.SetImageResource(DiceResources.GetBlackWhite(dice[3]));
			imgMeleeDie5.SetImageResource(DiceResources.GetBlackRed(dice[4]));
		}

		double GetAttackerValue()
		{
			double value = 1;
			Double.TryParse(editMeleeAttackerValue.Text, out value);
			return value;
		}
		double GetDefenderValue()
		{
			double value = 1;
			Double.TryParse(editMeleeDefenderValue.Text, out value);
			return value;
		}
		int GetMeleeIncrements()
		{
			int value = 1;
			Int32.TryParse(editMeleeIncrValue.Text, out value);
			return value;
		}
		int GetMeleeLoss()
		{
			int value = 1;
			Int32.TryParse(editMeleeLossValue.Text, out value);
			return value;
		}
		int GetMeleeValue()
		{
			int value = 1;
			Int32.TryParse(editMeleeValueValue.Text, out value);
			return value;
		}
		int GetMeleeLance()
		{
			int value = 1;
			Int32.TryParse(editMeleeLanceValue.Text, out value);
			return value;
		}
		double GetMeleeTotal()
		{
			double value = 1;
			Double.TryParse(editMeleeTotalValue.Text, out value);
			return value;
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

