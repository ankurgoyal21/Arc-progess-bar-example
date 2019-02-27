using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace LeaveInfoApp
{
    public class LeaveFragment : Fragment
    {
        private int _pageNumber;
        private RecyclerView _recyclerView;

        public static LeaveFragment NewInstance(int page)
        {
            LeaveFragment fragmentFirst = new LeaveFragment();
            Bundle args = new Bundle();
            args.PutInt("page_number", page);
            fragmentFirst.Arguments = args;
            return fragmentFirst;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _pageNumber = Arguments.GetInt("page_number", 0);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.leave_fragment, container, false);
            _recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recycler_view);
            _recyclerView.HasFixedSize = true;

            LinearLayoutManager layoutManager = new LinearLayoutManager(this.Activity);
            _recyclerView.SetLayoutManager(layoutManager);
            _recyclerView.SetItemAnimator(new DefaultItemAnimator());
            _recyclerView.SetAdapter(new LeavesDetailsAdapter(((MainActivity)Activity).GetLeaveBalanceModels(_pageNumber)));
            return view;
        }
    }
}