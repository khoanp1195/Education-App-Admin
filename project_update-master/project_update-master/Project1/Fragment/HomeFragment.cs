using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Firebase;
using Firebase.Database;
using Android.Views;
using Android.Gms.Maps;
using AndroidX.CardView.Widget;

using Android.Content;
using Project1.Activities;

using System.Timers;
using System;
using Firebase.Auth;
using Android.Gms.Common;
using Android.Util;
using Firebase.Iid;
using Project1.Model;

using System.Collections.Generic;
using Project1.Activities.Study.EnglishDictionary;
using Project1.Activities.Study.XamarinCourse;
using Project1.Activities.ManageQuestion;
using Project1.Activities.Study.Course;
using Project1.Activities.Study.UserProfile;
using Project1.Activities.Study.UserProfile.ClientRanking;

namespace Project1.Fragments
{
    public class HomeFragment : Android.Support.V4.App.Fragment
    {

        CardView cardView1, cardView2, cardView40, cardView4, cardView5, cardView39, cardView14,
            cardView15, cardView16, cardView17, cardView34, cardView44, cardView35, cardView36, cardView41, cardView42, cardView45, cardView43;
        Timer timer;

        Button tokenBtn;
        TextView timer1, txtName, txtMSG;



        ListView lstView,lstView1, lstView2, lstView3;
        //public GoogleMap mainMap;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Log.Debug("Token", "Intance Id Token : " + FirebaseInstanceId.Instance.Token);
            // Create your fragment here
        }

        [Obsolete]
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
           View view = inflater.Inflate(Resource.Layout.home_fragment, container, false);
            //SupportMapFragment mapFragment = (SupportMapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            //mapFragment.GetMapAsync(this);
            IntializeDatabase();




            cardView14 = (CardView)view.FindViewById(Resource.Id.cardView14);
            cardView15 = (CardView)view.FindViewById(Resource.Id.cardView15);
            cardView16 = (CardView)view.FindViewById(Resource.Id.cardView16);
            cardView17 = (CardView)view.FindViewById(Resource.Id.cardView17);
            cardView34 = (CardView)view.FindViewById(Resource.Id.cardView34);
            cardView44 = (CardView)view.FindViewById(Resource.Id.cardView44);
            cardView35 = (CardView)view.FindViewById(Resource.Id.cardView35);
            cardView36 = (CardView)view.FindViewById(Resource.Id.cardView36);
            cardView39 = (CardView)view.FindViewById(Resource.Id.cardView39);
            cardView40 = (CardView)view.FindViewById(Resource.Id.cardView40);
            cardView41 = (CardView)view.FindViewById(Resource.Id.cardView41);
            cardView41 = (CardView)view.FindViewById(Resource.Id.cardView41);
            cardView42 = (CardView)view.FindViewById(Resource.Id.cardView42);
            cardView45 = (CardView)view.FindViewById(Resource.Id.cardView45);
            cardView43 = (CardView)view.FindViewById(Resource.Id.cardView43);

            cardView43.Click += CardView43_Click;

            cardView45.Click += CardView45_Click;

            cardView42.Click += CardView42_Click;


            cardView41.Click += CardView41_Click;






            cardView40.Click += CardView40_Click;


            cardView39.Click += CardView39_Click;


            cardView36.Click += CardView36_Click;

            cardView35.Click += CardView35_Click;

            cardView44 = (CardView)view.FindViewById(Resource.Id.cardView44);
            cardView44.Click += CardView44_Click;


            cardView34.Click += CardView34_Click;
    


            timer1 = (TextView)view.FindViewById(Resource.Id.timer1);

            txtMSG = (TextView)view.FindViewById(Resource.Id.txtMSG);

            txtName = (TextView)view.FindViewById(Resource.Id.txtName);

            tokenBtn = (Button)view.FindViewById(Resource.Id.tokenBtn);

            txtName.Text = "Welcome back " + FirebaseAuth.Instance.CurrentUser.Email;

            lstView = view.FindViewById<ListView>(Resource.Id.lstView);
            lstView1 = view.FindViewById<ListView>(Resource.Id.lstView1);
            lstView2 = view.FindViewById<ListView>(Resource.Id.lstView2);
            lstView3 = view.FindViewById<ListView>(Resource.Id.lstView3);

        


            cardView5 = (CardView)view.FindViewById(Resource.Id.cardView5);
            cardView5.Click += delegate
            {
                Intent intent = new Intent(Context, typeof(addcontent));

                StartActivity(intent);
            };

            cardView2 = (CardView)view.FindViewById(Resource.Id.cardView2);

            cardView2.Click += delegate
            {
                Intent intent = new Intent(Context, typeof(addnewword));
             
                StartActivity(intent);

              

            };

            IsPlayServicesAvailable();


            tokenBtn.Click += delegate
            {
                Log.Debug("Token", "Intance Id Token : " + FirebaseInstanceId.Instance.Token);
            };



            void IntializeDatabase()
            {
                var app = FirebaseApp.InitializeApp(Context);

                if (app == null)
                {
                    var options = new Firebase.FirebaseOptions.Builder()
                    .SetApplicationId("project1-4e850")
                    .SetApiKey("AIzaSyCou_P4H_wbYA3tWisjrOfq2b9nhYIzd7w")
                    .SetDatabaseUrl("https://project1-4e850-default-rtdb.firebaseio.com")
                    .SetStorageBucket("project1-4e850.appspot.com")
                    .Build();

                    app = FirebaseApp.InitializeApp(Context, options);
                 ///   mDatabase = FirebaseDatabase.GetInstance(app);
                }
                else
                {
                   // mDatabase = FirebaseDatabase.GetInstance(app);
                }
                //  DatabaseReference dbrf = mDatabase.GetReference("UserSupport");
                // dbrf.SetValue("Ticket");

                //Toast.MakeText(this, "Make Test", ToastLength.Short).Show();


             

            }





            cardView1 =  (CardView)view.FindViewById(Resource.Id.cardView1);

            cardView1.Click += delegate
            {
                Intent intent = new Intent(Context, typeof(UserProfileee));
                StartActivity(intent);
            };

            cardView4 = (CardView)view.FindViewById(Resource.Id.cardView4);
            cardView4.Click += delegate
            {
                Intent intent = new Intent(Context, typeof(UserReply));
                StartActivity(intent);
            };
            return view;
        }

        private void CardView43_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(XamarinRankingManagement));
            StartActivity(intent);
        }

        private void CardView45_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(FlagRankingManagement));
            StartActivity(intent);
        }

        private void CardView42_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(ClientRanking));
            StartActivity(intent);
        }

        private void CardView41_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(RankingManagement));

            StartActivity(intent);
        }

        private void CardView40_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(UserResponse));

            StartActivity(intent);
        }

        private void CardView39_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(TodayWord));

            StartActivity(intent);
        }

        private void CardView36_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(AllCourese)); 
            StartActivity(intent);
        }

        private void CardView35_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(HistoryUserQuestion));
            StartActivity(intent);
        }

        private void CardView44_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(TodayQuestion));

            StartActivity(intent);
        }

        private void CardView34_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(UserAsk));

            StartActivity(intent);
        }

        private bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(Context);
            if (resultCode != ConnectionResult.Success)
            {

                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    txtMSG.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                else
                {
                    txtMSG.Text = "THis device can not connet";
                }

                return false;

            }
            else
            {
               // txtMSG = (TextView)"Connect AVAILABLE";
                return true;
            }
              
       

        }
               

        

        public override void OnStart()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            base.OnStart();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            Activity.RunOnUiThread(() => { timer1.Text = dt.ToString(); }); 
        }

        //public void OnMapReady(GoogleMap googleMap)
        //{
        //    mainMap = googleMap;
        //}
    }
}