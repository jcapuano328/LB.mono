using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;
using System.Threading.Tasks;

namespace LB
{
	//
	// Shows how to use the MediaPlayer class to play audio.
	public class PlayAudio
	{
		MediaPlayer player = null;
		Context context;

		public PlayAudio(Context ctx)
		{
			context = ctx;
		}
			
		public void Play ()
		{
			try {
				player = MediaPlayer.Create (context, Resource.Raw.droll);
				player.Completion += (object sender, EventArgs e) => {
					player.Stop ();
					player.Release ();
					player = null;
				};
				player.Start ();
			} catch (Exception ex) {
				Console.Out.WriteLine (ex.StackTrace);
			}
		}
	}
}