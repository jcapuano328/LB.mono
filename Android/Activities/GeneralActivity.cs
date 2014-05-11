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
	public class GeneralActivity : Activity
	{
		TextView txtBattleName;
		TextView txtScenarioName;
		ImageView imgBack;
		ImageView imgLb;
		
		ImageView imgGeneral2Die1;
		ImageView imgGeneral2Die2;
		Button btnGeneral2DiceRoll;

		ImageView imgGeneral1Die1;
		Button btnGeneral1DiceRoll;
		
		Game game;
		Dice dice1;
		Dice dice2;
		PlayAudio audio;
		
		protected override void OnCreate (Bundle bundle)
		{
			dice1 = new Dice(1, 1, 6);
			dice2 = new Dice(2, 1, 6);
			audio = new PlayAudio (this);
		
			base.OnCreate (bundle);

			game = LbManager.GetGame(Intent.GetIntExtra ("Battle", -1), Intent.GetIntExtra("Scenario", -1));

			// set our layout to be the home screen
			SetContentView(Resource.Layout.General);		

			imgBack = FindViewById<ImageView> (Resource.Id.titleSubLbBack);
			imgLb = FindViewById<ImageView> (Resource.Id.titleSubLb);

			// title
			txtBattleName = FindViewById<TextView>(Resource.Id.titleSubBattleName);
			txtScenarioName = FindViewById<TextView>(Resource.Id.titleSubScenarioName);
			
			imgGeneral2Die1 = FindViewById<ImageView> (Resource.Id.imgGeneral2Die1);
			imgGeneral2Die2 = FindViewById<ImageView> (Resource.Id.imgGeneral2Die2);
			btnGeneral2DiceRoll = FindViewById<Button>(Resource.Id.btnGeneral2DiceRoll);

			imgGeneral1Die1 = FindViewById<ImageView> (Resource.Id.imgGeneral1Die1);
			btnGeneral1DiceRoll = FindViewById<Button>(Resource.Id.btnGeneral1DiceRoll);
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
			
			
			btnGeneral2DiceRoll.Click += (sender, e) => {
				audio.Play();
				dice2.Roll();
				DisplayDice();
			};
			
			btnGeneral1DiceRoll.Click += (sender, e) => {
				audio.Play();
				dice1.Roll();
				DisplayDice();
			};
		}
		
		void DisplayDice()
		{
			imgGeneral2Die1.SetImageResource(DiceResources.GetWhiteBlack(dice2[0]));
			imgGeneral2Die2.SetImageResource(DiceResources.GetRedWhite(dice2[1]));
			imgGeneral1Die1.SetImageResource(DiceResources.GetBlue(dice1[0]));
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

