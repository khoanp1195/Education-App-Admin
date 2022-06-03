using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Activities.Study.UserProfile.ClientRanking
{
    [Activity(Label = "ClientRanking")]
    public class ClientRanking : Activity
    {
        CardView cardView45, cardView46, cardView47;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ClientRanking);

            // Create your application here

            cardView45 = (CardView)FindViewById(Resource.Id.cardView45);
            cardView45.Click += CardView45_Click;


            cardView46 = (CardView)FindViewById(Resource.Id.cardView46);
            cardView46.Click += CardView46_Click;
            cardView47 = (CardView)FindViewById(Resource.Id.cardView47);
            cardView47.Click += CardView47_Click;
        }

        private void CardView47_Click(object sender, EventArgs e)
        {
           Intent intent = new Intent(this, typeof(ClientRankingManagement));
            StartActivity(intent);
        }

        private void CardView46_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(XamarinClientRankingManagement));
            StartActivity(intent);
        }

        private void CardView45_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FlagClientRankingManagement));
            StartActivity(intent);
        }
    }
}