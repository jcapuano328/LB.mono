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
		ImageView imgBack;
		ImageView imgLb;
		TextView txtBattleName;
		TextView txtScenarioName;
		Button btnReset;
		TextView txtTurn;
		Button btnTurnPrev;
		Button btnTurnNext;
		TextView txtPhase;
		Button btnPhasePrev;
		Button btnPhaseNext;
		ImageButton btnFire;
		ImageButton btnMelee;
		ImageButton btnMorale;
		ImageButton btnGeneral;
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

			btnReset = FindViewById<Button>(Resource.Id.btnReset);

			btnFire = FindViewById<ImageButton>(Resource.Id.btnFire);
			btnMelee = FindViewById<ImageButton>(Resource.Id.btnMelee);
			btnMorale = FindViewById<ImageButton>(Resource.Id.btnMorale);
			btnGeneral = FindViewById<ImageButton>(Resource.Id.btnGeneral);
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

			btnReset.Click += (sender, e) => {
				game.Reset();
				Update();
				Save();
			};
				
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

			btnFire.Click += (sender, e) => { 

				var fireDetail = new Intent (this, typeof(FireCombatActivity));
				fireDetail.PutExtra("Battle", game.Battle.Id);
				fireDetail.PutExtra ("Scenario", game.Scenario.Id);

				StartActivity (fireDetail);
			};

			btnMelee.Click += (sender, e) => { 

				var meleeDetail = new Intent (this, typeof(MeleeActivity));
				meleeDetail.PutExtra("Battle", game.Battle.Id);
				meleeDetail.PutExtra ("Scenario", game.Scenario.Id);

				StartActivity (meleeDetail);
			};
				
			btnMorale.Click += (sender, e) => { 

				var moraleDetail = new Intent (this, typeof(MoraleActivity));
				moraleDetail.PutExtra("Battle", game.Battle.Id);
				moraleDetail.PutExtra ("Scenario", game.Scenario.Id);

				StartActivity (moraleDetail);
			};
			
			btnGeneral.Click += (sender, e) => { 

				var generalDetail = new Intent (this, typeof(GeneralActivity));
				generalDetail.PutExtra("Battle", game.Battle.Id);
				generalDetail.PutExtra ("Scenario", game.Scenario.Id);

				StartActivity (generalDetail);
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

