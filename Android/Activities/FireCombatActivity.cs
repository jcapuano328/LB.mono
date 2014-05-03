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
		Game game;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			game = LbManager.GetGame(Intent.GetIntExtra ("Battle", -1), Intent.GetIntExtra("Scenario", -1));

			// set our layout to be the home screen
			SetContentView(Resource.Layout.FireCombat);		

			imgBack = FindViewById<ImageView> (Resource.Id.titleSubLbBack);
			imgLb = FindViewById<ImageView> (Resource.Id.titleSubLb);

			// title
			txtBattleName = FindViewById<TextView>(Resource.Id.titleSubBattleName);
			txtScenarioName = FindViewById<TextView>(Resource.Id.titleSubScenarioName);
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

