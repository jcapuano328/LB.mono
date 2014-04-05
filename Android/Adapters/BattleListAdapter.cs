using System.Collections.Generic;
using Android.App;
using Android.Widget;
using LB.Core;

namespace LB.Adapters {
	/// <summary>
	/// Adapter that presents Battles in a row-view
	/// </summary>
	public class BattleListAdapter : BaseAdapter<Battle> {
		Activity context = null;
		IList<Battle> battles = new List<Battle>();

		public BattleListAdapter (Activity context, IList<Battle> battles) : base ()
		{
			this.context = context;
			this.battles = battles;
		}

		public override Battle this[int position]
		{
			get { return battles[position]; }
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count
		{
			get { return battles.Count; }
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			// Get our object for position
			var item = battles[position];			

			//Try to reuse convertView if it's not  null, otherwise inflate it from our item layout
			// gives us some performance gains by not always inflating a new view
			// will sound familiar to MonoTouch developers with UITableViewCell.DequeueReusableCell()
			var view = (convertView ?? 
				context.LayoutInflater.Inflate(
					Resource.Layout.BattleListItem, 
					parent, 
					false)) as LinearLayout;

			// Find references to each subview in the list item's view
			var txtName = view.FindViewById<TextView>(Resource.Id.textName);
			var txtPublisher = view.FindViewById<TextView>(Resource.Id.textPublisher);

			//Assign item's values to the various subviews
			txtName.SetText (item.Name, TextView.BufferType.Normal);
			txtPublisher.SetText (item.Publisher, TextView.BufferType.Normal);

			//Finally return the view
			return view;
		}
	}
}