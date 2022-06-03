using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Resource;
using Android.Support.V7.Widget;
using Project1.Study;
using Project1.Acitivties.Study;
using Project1.Activities;
using Project1.Activities.Webview;
using Project1.Activities.Study;
using Project1.Activities.Study.XamarinCourse;

namespace Project1.Resources.Fragment
{
    public class StudyFragment : SupportFragment
    {


        CardView relativeLayout1, relativeLayout2, relativeLayout3, relativeLayout4;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here    
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.acitivity_study, container, false);


          //  relativeLayout1 = (RelativeLayout)view.FindViewById(Resource.Id.relativeLayout1);
        


            relativeLayout2 = (CardView)view.FindViewById(Resource.Id.relativeLayout2);

            relativeLayout2.Click += RelativeLayout2_Click;


            relativeLayout3 = (CardView)view.FindViewById(Resource.Id.relativeLayout3);
            relativeLayout3.Click += RelativeLayout3_Click;


            relativeLayout4 = (CardView)view.FindViewById(Resource.Id.relativeLayout4);
            relativeLayout4.Click += RelativeLayout4_Click;





            return view;
        }

        private void RelativeLayout4_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(addcontent));
            StartActivity(intent);
        }

        private void RelativeLayout3_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(Study1));
            StartActivity(intent);
        }

        private void RelativeLayout2_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(Study1));
            StartActivity(intent);
        }

  
        
        
    }
}