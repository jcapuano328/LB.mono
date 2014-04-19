using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using LB.Core;

namespace LB
{
	[Activity (Label = "La Bataille Assistant", MainLauncher = true, Icon="@drawable/Icon")]
	public class MainActivity : Activity
	{
		Adapters.BattleListAdapter battleList;
		IList<Battle> battles;
		ExpandableListView battleListView;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			LbManager.Initialize (Assets.Open(LbManager.BattlesAssetsPath));

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			//Find our controls
			battleListView = FindViewById<ExpandableListView> (Resource.Id.listBattles);
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			battles = LbManager.GetBattles();

			// create our adapter
			battleList = new Adapters.BattleListAdapter(this, battles);
						
			//Hook up our adapter to our ListView
			battleListView.SetAdapter(battleList);

			battleListView.ChildClick += (object sender, ExpandableListView.ChildClickEventArgs e) => {
				var battleDetail = new Intent (this, typeof(BattleActivity));
				var battle = battles[e.GroupPosition];
				var scenario = battle.Scenarios[e.ChildPosition];
				battleDetail.PutExtra("Battle", battle.Id);
				battleDetail.PutExtra ("Scenario", scenario.Id);

				StartActivity (battleDetail);
			};
		}
	}		
}


