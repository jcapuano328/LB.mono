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
	public class BattleActivity : Activity
	{
		TextView txtBattleName;
		TextView txtScenarioName;
		TextView txtTurn;
		Button btnTurnPrev;
		Button btnTurnNext;
		TextView txtPhase;
		Button btnPhasePrev;
		Button btnPhaseNext;
		ImageView imgBack;
		ImageView imgLb;
		Game game;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			game = LbManager.GetGame(Intent.GetIntExtra ("Battle", -1), Intent.GetIntExtra("Scenario", -1));

			// set our layout to be the home screen
			SetContentView(Resource.Layout.Battle);		

			imgBack = FindViewById<ImageView> (Resource.Id.titleSubLbBack);
			imgLb = FindViewById<ImageView> (Resource.Id.titleSubLb);

			// title
			txtBattleName = FindViewById<TextView>(Resource.Id.titleSubBattleName);
			txtScenarioName = FindViewById<TextView>(Resource.Id.titleSubScenarioName);

			// current turn
			txtTurn = FindViewById<TextView>(Resource.Id.textTurn);
			btnTurnPrev = FindViewById<Button>(Resource.Id.btnTurnPrev);
			btnTurnNext = FindViewById<Button>(Resource.Id.btnTurnNext);

			// current phase
			txtPhase = FindViewById<TextView>(Resource.Id.textPhase);
			btnPhasePrev = FindViewById<Button>(Resource.Id.btnPhasePrev);
			btnPhaseNext = FindViewById<Button>(Resource.Id.btnPhaseNext);
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

			btnTurnPrev.Click += (sender, e) => { 
				game.PrevTurn();
				Update();
				Save(); 
			};
			btnTurnNext.Click += (sender, e) => { 
				game.NextTurn();
				Update();
				Save(); 
			};

			btnPhasePrev.Click += (sender, e) => { 
				game.PrevPhase();
				Update();
				Save(); 
			};
			btnPhaseNext.Click += (sender, e) => { 
				game.NextPhase();
				Update();
				Save(); 
			};				

			Update();
		}
		
		void Update()
		{
			txtTurn.Text = game.CurrentTurn;
			txtPhase.Text = game.CurrentPhase;
		}
		
		void Save()
		{
			LbManager.SaveGame(game);
		}

		void NavigateUp()
		{
			StartActivity (new Intent (this, typeof(MainActivity)));
		}
	}
}

