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
	public class MoraleActivity : Activity
	{
		TextView txtBattleName;
		TextView txtScenarioName;
		ImageView imgBack;
		ImageView imgLb;
		
		Button btnMoralePrev;
		Button btnMoraleNext;
		EditText editMoraleValue;
		
		ImageView imgMoraleDie1;
		ImageView imgMoraleDie2;
		Button btnMoraleDiceRoll;

		Button btnMoraleMinus6;
		Button btnMoraleMinus3;
		Button btnMoraleMinus1;
		Button btnMoralePlus1;
		Button btnMoralePlus3;
		Button btnMoralePlus6;
		
		TextView txtMoraleResults;
		
		Game game;
		Dice dice;
		Morale morale;
		PlayAudio audio;
		
		protected override void OnCreate (Bundle bundle)
		{
			dice = new Dice(2, 1, 6);
			morale = new Morale();
			audio = new PlayAudio (this);
		
			base.OnCreate (bundle);

			game = LbManager.GetGame(Intent.GetIntExtra ("Battle", -1), Intent.GetIntExtra("Scenario", -1));

			// set our layout to be the home screen
			SetContentView(Resource.Layout.Morale);		

			imgBack = FindViewById<ImageView> (Resource.Id.titleSubLbBack);
			imgLb = FindViewById<ImageView> (Resource.Id.titleSubLb);

			// title
			txtBattleName = FindViewById<TextView>(Resource.Id.titleSubBattleName);
			txtScenarioName = FindViewById<TextView>(Resource.Id.titleSubScenarioName);
			
			btnMoralePrev = FindViewById<Button>(Resource.Id.btnMoralePrev);
			btnMoraleNext = FindViewById<Button>(Resource.Id.btnMoraleNext);
			editMoraleValue = FindViewById<EditText>(Resource.Id.editMoraleValue);
			
			editMoraleValue.Text = "11";
			
			imgMoraleDie1 = FindViewById<ImageView> (Resource.Id.imgMoraleDie1);
			imgMoraleDie2 = FindViewById<ImageView> (Resource.Id.imgMoraleDie2);
			btnMoraleDiceRoll = FindViewById<Button>(Resource.Id.btnMoraleDiceRoll);
			
			btnMoraleMinus6 = FindViewById<Button>(Resource.Id.btnMoraleMinus6);
			btnMoraleMinus3 = FindViewById<Button>(Resource.Id.btnMoraleMinus3);
			btnMoraleMinus1 = FindViewById<Button>(Resource.Id.btnMoraleMinus1);
			btnMoralePlus1 = FindViewById<Button>(Resource.Id.btnMoralePlus1);
			btnMoralePlus3 = FindViewById<Button>(Resource.Id.btnMoralePlus3);
			btnMoralePlus6 = FindViewById<Button>(Resource.Id.btnMoralePlus6);
			
			txtMoraleResults = FindViewById<TextView>(Resource.Id.txtMoraleResults);
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
			
			
			btnMoralePrev.Click += (sender, e) => {
				var b6i = new Base6Value(GetMoraleValue());
				var value = b6i.Subtract(1);
				editMoraleValue.Text = value.ToString();
				UpdateResults();
			};
			btnMoraleNext.Click += (sender, e) => {
				var b6i = new Base6Value(GetMoraleValue());
				var value = b6i.Add(1);
				editMoraleValue.Text = value.ToString();
				UpdateResults();
			};
			editMoraleValue.AfterTextChanged += (object sender, Android.Text.AfterTextChangedEventArgs e) => {
				UpdateResults();
			};
			
			imgMoraleDie1.Click += (sender, e) => {
				IncrementDie(1);
				DisplayDice();
				UpdateResults();
			};
			imgMoraleDie2.Click += (sender, e) => {
				IncrementDie(2);
				DisplayDice();
				UpdateResults();
			};
			
			btnMoraleDiceRoll.Click += (sender, e) => {
				audio.Play();
				dice.Roll();
				DisplayDice();
				UpdateResults();
			};
			
			btnMoraleMinus6.Click += (sender, e) => {
				ModifyDice(-6);
				DisplayDice();
				UpdateResults();
			};
			btnMoraleMinus3.Click += (sender, e) => {
				ModifyDice(-3);
				DisplayDice();
				UpdateResults();
			};
			btnMoraleMinus1.Click += (sender, e) => {
				ModifyDice(-1);
				DisplayDice();
				UpdateResults();
			};
			
			btnMoralePlus6.Click += (sender, e) => {
				ModifyDice(6);
				DisplayDice();
				UpdateResults();
			};
			btnMoralePlus3.Click += (sender, e) => {
				ModifyDice(3);
				DisplayDice();
				UpdateResults();
			};
			btnMoralePlus1.Click += (sender, e) => {
				ModifyDice(1);
				DisplayDice();
				UpdateResults();
			};
		}
		
		void UpdateResults()
		{
			int d = (dice[0]*10) + dice[1];
			string result = morale.Resolve(GetMoraleValue(), d);
			txtMoraleResults.SetText(result, TextView.BufferType.Normal);
		}
		
		void DisplayDice()
		{
			imgMoraleDie1.SetImageResource(DiceResources.GetWhiteBlack(dice[0]));
			imgMoraleDie2.SetImageResource(DiceResources.GetRedWhite(dice[1]));
		}

		int GetMoraleValue()
		{
			int value = 1;
			Int32.TryParse(editMoraleValue.Text, out value);
			return value;
		}
		
		void ModifyDice(int mod)
		{
			var b6i = new Base6Value((dice[0]*10) + dice[1]);
			int value = b6i.Add(mod);
			dice[0] = value / 10;
			dice[1] = value % 10;
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

