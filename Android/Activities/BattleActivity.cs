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
		TextView txtTurn;
		Button btnTurnPrev;
		Button btnTurnNext;
		TextView txtPhase;
		Button btnPhasePrev;
		Button btnPhaseNext;
		Game game;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			game = LbManager.GetGame(Intent.GetIntExtra ("Battle", -1), Intent.GetIntExtra("Scenario", -1));

			// set our layout to be the home screen
			SetContentView(Resource.Layout.Battle);

			// set the title
			this.Title = "La Bataille Assistant    " + game.Battle.Name + " - " + game.Scenario.Name;

			// populate the current turn
			txtTurn = FindViewById<TextView>(Resource.Id.textTurn);
			btnTurnPrev = FindViewById<Button>(Resource.Id.btnTurnPrev);
			btnTurnPrev.Click += (sender, e) => { 
				game.PrevTurn();
				Update();
				Save(); 
			};
			btnTurnNext = FindViewById<Button>(Resource.Id.btnTurnNext);
			btnTurnNext.Click += (sender, e) => { 
				game.NextTurn();
				Update();
				Save(); 
			};
			

			// populate the current phase
			txtPhase = FindViewById<TextView>(Resource.Id.textPhase);
			btnPhasePrev = FindViewById<Button>(Resource.Id.btnPhasePrev);
			btnPhasePrev.Click += (sender, e) => { 
				game.PrevPhase();
				Update();
				Save(); 
			};
			
			btnPhaseNext = FindViewById<Button>(Resource.Id.btnPhaseNext);
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
	}
}

