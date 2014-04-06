using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using LB.Core;

namespace LB.Adapters {
	/// <summary>
	/// Adapter that presents Battles in a row-view
	/// </summary>
	public class BattleListAdapter : BaseExpandableListAdapter {
		Activity context = null;
		IList<Battle> battles = new List<Battle>();

		public BattleListAdapter (Activity context, IList<Battle> battles) : base ()
		{
			this.context = context;
			this.battles = battles;
		}

		#region implemented abstract members of BaseExpandableListAdapter
		public override Java.Lang.Object GetChild (int groupPosition, int childPosition)
		{
			return battles[groupPosition].Scenarios[childPosition].ToJavaObject();
		}
		public override long GetChildId (int groupPosition, int childPosition)
		{
			return battles [groupPosition].Scenarios [childPosition].Id;
		}
		public override int GetChildrenCount (int groupPosition)
		{
			return battles [groupPosition].Scenarios.Count;
		}
		public override Java.Lang.Object GetGroup (int groupPosition)
		{
			return battles[groupPosition].ToJavaObject();
		}
		public override long GetGroupId (int groupPosition)
		{
			return battles[groupPosition].Id;
		}
		public override bool IsChildSelectable (int groupPosition, int childPosition)
		{
			return true;
		}
		public override int GroupCount {
			get {
				return battles.Count;
			}
		}
		public override bool HasStableIds {
			get {
				return true;
			}
		}

		public override View GetGroupView (int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
		{
			// Get our object for position
			var item = battles[groupPosition];			

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

		public override View GetChildView (int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
		{
			var item = battles[groupPosition].Scenarios[childPosition];

			var view = (convertView ?? 
				context.LayoutInflater.Inflate(
					Resource.Layout.ScenarioListItem, 
					parent, 
					false)) as LinearLayout;

			var txtName = view.FindViewById<TextView> (Resource.Id.textName);
			txtName.SetText (item.Name, TextView.BufferType.Normal);

			var txtDate = view.FindViewById<TextView> (Resource.Id.textDate);
			txtDate.SetText (item.DisplayDate, TextView.BufferType.Normal);

			return view;
		}

		#endregion
	}
}