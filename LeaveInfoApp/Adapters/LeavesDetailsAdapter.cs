using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;

namespace LeaveInfoApp
{
    public class LeavesDetailsAdapter : RecyclerView.Adapter
    {
        public List<LeaveBalanceModel> LeaveBalanceModels;
        public override int ItemCount => LeaveBalanceModels.Count;

        public class LeavesViewHolder : RecyclerView.ViewHolder
        {
            public TextView StartDate;
            public TextView EndDate;
            public TextView TotalDay;
            public TextView Description;
            public TextView Status;
            public TextView ApprovedDate;

            public LeavesViewHolder(View itemView) : base(itemView)
            {
                StartDate = itemView.FindViewById<TextView>(Resource.Id.txtStartDay);
                EndDate = itemView.FindViewById<TextView>(Resource.Id.txtEndDay);
                TotalDay = itemView.FindViewById<TextView>(Resource.Id.txtTotalDay);
                Description = itemView.FindViewById<TextView>(Resource.Id.txtDescription);
                Status = itemView.FindViewById<TextView>(Resource.Id.txtStatus);
                ApprovedDate = itemView.FindViewById<TextView>(Resource.Id.txtApprovedDate);
            }
        }

        public LeavesDetailsAdapter(List<LeaveBalanceModel> leaveBalanceModels)
        {
            LeaveBalanceModels = leaveBalanceModels;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            LeavesViewHolder vh = holder as LeavesViewHolder;
            vh.StartDate.Text = LeaveBalanceModels[position].StartDate;
            vh.EndDate.Text = LeaveBalanceModels[position].EndDate;
            vh.TotalDay.Text = LeaveBalanceModels[position].TotalDays + " days next week";
            vh.Description.Text = LeaveBalanceModels[position].Description;
            vh.Status.Text = LeaveBalanceModels[position].LeaveStatus;
            if (LeaveBalanceModels[position].LeaveStatus.Equals("Approved"))
            {
                vh.ApprovedDate.Visibility = ViewStates.Visible;
                vh.ApprovedDate.Text = LeaveBalanceModels[position].ApprovedDate;
            }
            else
            {
                vh.ApprovedDate.Visibility = ViewStates.Gone;
                vh.ApprovedDate.Text = string.Empty;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.leave_details_list, parent, false);
            LeavesViewHolder vh = new LeavesViewHolder(itemView);
            return vh;
        }
    }
}