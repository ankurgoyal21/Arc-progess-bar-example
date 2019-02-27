using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace LeaveInfoApp
{
    public class ViewPagerAdapter : FragmentPagerAdapter
    {
        public ViewPagerAdapter(FragmentManager fm) : base(fm)
        {

        }

        public override int Count => 3;

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            return LeaveFragment.NewInstance(position + 1);
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            string title = null;
            if (position == 0)
            {
                title = "Approved leaves";
            }
            else if (position == 1)
            {
                title = "Pending for Approval";
            }
            else if (position == 2)
            {
                title = "Denied leaves";
            }
            return new Java.Lang.String(title);
        }
    }
}