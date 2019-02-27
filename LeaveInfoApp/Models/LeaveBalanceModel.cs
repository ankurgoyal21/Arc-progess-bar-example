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

namespace LeaveInfoApp
{
    public class LeaveBalanceModel
    {
        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public int TotalDays { get; set; }

        public string Description { get; set; }

        public string ApprovedDate { get; set; }

        public string LeaveStatus { get; set; }
    }
}