using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using LB.Core;

namespace LB
{
	[Activity (Label = "La Bataille Assistant", MainLauncher = true, Icon="@drawable/lb")]
	public class MainActivity : Activity
	{
		Adapters.BattleListAdapter battleList;
		IList<Battle> battles;
		ListView battleListView;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			LbManager.Initialize (Assets.Open(LbManager.BattlesAssetsPath));

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			//Find our controls
			battleListView = FindViewById<ListView> (Resource.Id.listBattles);
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			battles = LbManager.GetBattles();

			// create our adapter
			battleList = new Adapters.BattleListAdapter(this, battles);

			//Hook up our adapter to our ListView
			battleListView.Adapter = battleList;
		}
	}		
}


