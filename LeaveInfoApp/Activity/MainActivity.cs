using System;
using System.Collections.Generic;
using Android;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace LeaveInfoApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        private TabLayout _tabLayout;
        private ViewPager _viewPager;
        private ViewPagerAdapter _viewPagerAdapter;
        public List<LeaveBalanceModel> LeaveBalanceModels = new List<LeaveBalanceModel>();
        public ArcProgress _progressBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            InitializeViews(toolbar);
        }

        private void InitializeViews(Android.Support.V7.Widget.Toolbar toolbar)
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();
            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);
            //CreateDummyData();
            InitializeProgress();
            //InitializeTabLayout();
        }

        private void InitializeTabLayout()
        {
            _viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            _viewPagerAdapter = new ViewPagerAdapter(SupportFragmentManager);
            _viewPager.Adapter = _viewPagerAdapter;
            _tabLayout = FindViewById<TabLayout>(Resource.Id.sliding_tabs);
            _tabLayout.SetupWithViewPager(_viewPager);
        }

        private void InitializeProgress()
        {
            _progressBar = FindViewById<ArcProgress>(Resource.Id.arc_progress);
            _progressBar.SetMax(40);
            _progressBar.SetProgress(10);
            _progressBar.SetFinishedStrokeColor(Color.Orange);
            _progressBar.SetUnfinishedStrokeColor(Color.White);
            _progressBar.SetTextColor(Color.White);
            _progressBar.SetSuffixText("");
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if (drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_camera)
            {
                // Handle the camera action
            }
            else if (id == Resource.Id.nav_gallery)
            {

            }
            else if (id == Resource.Id.nav_slideshow)
            {

            }
            else if (id == Resource.Id.nav_manage)
            {

            }
            else if (id == Resource.Id.nav_share)
            {

            }
            else if (id == Resource.Id.nav_send)
            {

            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }

        /// <summary>
        /// create dummy data
        /// </summary>
        public void CreateDummyData()
        {
            LeaveBalanceModels.Add(new LeaveBalanceModel() { StartDate = "AUG 15", EndDate = "AUG 18", ApprovedDate = "On Aug 11", Description = "Hey i need to take of my personal pending work so i would like to take a break from work", TotalDays = 4, LeaveStatus = "Approved" });
            LeaveBalanceModels.Add(new LeaveBalanceModel() { StartDate = "JUL 08", EndDate = "JUL 12", ApprovedDate = "On Jul 01", Description = "Hey i am out for a vacation with family out of india so request you to approve the leaves", TotalDays = 5, LeaveStatus = "Approved" });
            LeaveBalanceModels.Add(new LeaveBalanceModel() { StartDate = "MAY 02", EndDate = "AUG 08", ApprovedDate = "On MAY 01", Description = "Relocation leaves as i have joined here 3 months back i need to shift by family from banglore to hydrabad and set the house", TotalDays = 7, LeaveStatus = "Approved" });
            LeaveBalanceModels.Add(new LeaveBalanceModel() { StartDate = "Sep 15", EndDate = "Sep 18", ApprovedDate = "On Sep 11", Description = "Hey i need to take of my personal pending work so i would like to take a break from work", TotalDays = 4, LeaveStatus = "Pending" });
            LeaveBalanceModels.Add(new LeaveBalanceModel() { StartDate = "Oct 15", EndDate = "Oct 18", ApprovedDate = "On Oct 11", Description = "Hey i need to take of my personal pending work so i would like to take a break from work", TotalDays = 4, LeaveStatus = "Pending" });
            LeaveBalanceModels.Add(new LeaveBalanceModel() { StartDate = "Nov 15", EndDate = "Nov 18", ApprovedDate = "On Nov 11", Description = "Hey i need to take of my personal pending work so i would like to take a break from work", TotalDays = 4, LeaveStatus = "Denied" });
        }

        /// <summary>
        /// get balanced leaves
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public List<LeaveBalanceModel> GetLeaveBalanceModels(int pageNumber)
        {
            if (pageNumber == 1)
            {
                var approvedDetails = LeaveBalanceModels.FindAll(x => x.LeaveStatus.Equals("Approved"));
                var progress = 0;
                foreach (var item in approvedDetails)
                {
                    progress += item.TotalDays;
                }
                _progressBar.SetProgress(progress);
                return approvedDetails;
            }
            if (pageNumber == 2)
            {
                return LeaveBalanceModels.FindAll(x => x.LeaveStatus.Equals("Pending"));
            }
            return LeaveBalanceModels.FindAll(x => x.LeaveStatus.Equals("Denied"));
        }
    }
}

