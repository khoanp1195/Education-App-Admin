using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.App;
using System.Collections.Generic;
using Java.Lang;

namespace Project1.Acitivties.Study
{
    [Activity(Label = "StudyActivity", MainLauncher = false)]
    public class Study1 : AppCompatActivity
    {
        
        RelativeLayout relativeLayout2;
        ImageView backButton;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.include_list_viewpager);






            backButton = (ImageView)FindViewById(Resource.Id.backButton);
            backButton.Click += BackButton_Click;

            TabLayout tabs = FindViewById<TabLayout>(Resource.Id.tabs);

            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);

            SetUpViewPager(viewPager);

            tabs.SetupWithViewPager(viewPager);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);

            fab.Click += (o, e) =>
            {
                View anchor = o as View;

                Snackbar.Make(anchor, "Yay Snackbar!!", Snackbar.LengthLong)
                        .SetAction("Action", v =>
                        {
                            //Do something here
                            //Intent intent = new Intent(fab.Context, typeof(BottomSheetActivity));
                            //StartActivity(intent);
                        })
                        .Show();
            };
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);
        }

        private void SetUpViewPager(ViewPager viewPager)
        {
            TabAdapter adapter = new TabAdapter(SupportFragmentManager);

            adapter.AddFragment(new Fragment1(), "Index");
            adapter.AddFragment(new Fragment2(), "InterView");
     
            viewPager.Adapter = adapter;
        }
      


        public class TabAdapter : FragmentPagerAdapter
        {
            public List<SupportFragment> Fragments { get; set; }
            public List<string> FragmentNames { get; set; }

            public TabAdapter(SupportFragmentManager sfm) : base(sfm)
            {
                Fragments = new List<SupportFragment>();
                FragmentNames = new List<string>();
            }

            public void AddFragment(SupportFragment fragment, string name)
            {
                Fragments.Add(fragment);
                FragmentNames.Add(name);
            }

            public override int Count
            {
                get
                {
                    return Fragments.Count;
                }
            }

            public override SupportFragment GetItem(int position)
            {
                return Fragments[position];
            }

            public override ICharSequence GetPageTitleFormatted(int position)
            {
                return new Java.Lang.String(FragmentNames[position]);
            }
        }
    }
}

