using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Project1.Helpers;
using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Fragment
{
    public class detailrankingFragment : Android.Support.V4.App.DialogFragment
    {

        UserRanking thisuserRanking;
        TextView txtScore, usertText, timer;
        Button addRanking, addXamrinRanking, addFlagRanking;
        LinearLayout linearLayout;
        EditText searchText;


        public detailrankingFragment(UserRanking userRanking)
        {
            thisuserRanking = userRanking;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.detailRanking,container, false);

            searchText = (EditText)view.FindViewById(Resource.Id.searchText);


            addXamrinRanking = (Button)view.FindViewById(Resource.Id.addXamrinRanking);
            addXamrinRanking.Click += AddXamrinRanking_Click;


            addFlagRanking = (Button)view.FindViewById(Resource.Id.addFlagRanking);
            addFlagRanking.Click += AddFlagRanking_Click;

            txtScore = (TextView)view.FindViewById(Resource.Id.score);

            usertText = (TextView)view.FindViewById(Resource.Id.userText);


            timer = (TextView)view.FindViewById<TextView>(Resource.Id.timer);


            addRanking = (Button)view.FindViewById (Resource.Id.addRanking);

            linearLayout = (LinearLayout)view.FindViewById(Resource.Id.linearLayout);


            addRanking.Click += AddRanking_Click;


            usertText.Text =  thisuserRanking.Name;
            txtScore.Text = thisuserRanking.Score;
            timer.Text = thisuserRanking.Time;


            return view;
          
        }

        private void AddFlagRanking_Click(object sender, EventArgs e)
        {
            string Name = usertText.Text;
            string Score = txtScore.Text;
            string Timer = timer.Text;


            AlertDialog.Builder saveDataAlert = new AlertDialog.Builder(Activity);
            saveDataAlert.SetTitle("Save Change");
            saveDataAlert.SetMessage("Are you sure?");
            saveDataAlert.SetPositiveButton("Continue", (senderAlert, args) =>
            {

                AppDataHelper.GetDatabase().GetReference("FlagClientRanking/" + thisuserRanking.ID + "/Name").SetValue(Name);
                AppDataHelper.GetDatabase().GetReference("FlagClientRanking/" + thisuserRanking.ID + "/Time").SetValue(Timer);
                AppDataHelper.GetDatabase().GetReference("FlagClientRanking/" + thisuserRanking.ID + "/Score").SetValue(Score);


                Snackbar snackbar = Snackbar.Make(linearLayout, "Add Success", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Green);
                snackbar.Show();

            });
            saveDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
            {

                Snackbar snackbar = Snackbar.Make(linearLayout, "Add Failed", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
                saveDataAlert.Dispose();
            });

            saveDataAlert.Show();
        }

        private void AddXamrinRanking_Click(object sender, EventArgs e)
        {
            string Name = usertText.Text;
            string Score = txtScore.Text;
            string Timer = timer.Text;


            AlertDialog.Builder saveDataAlert = new AlertDialog.Builder(Activity);
            saveDataAlert.SetTitle("Save Change");
            saveDataAlert.SetMessage("Are you sure?");
            saveDataAlert.SetPositiveButton("Continue", (senderAlert, args) =>
            {

                AppDataHelper.GetDatabase().GetReference("XamarinClientRanking/" + thisuserRanking.ID + "/Name").SetValue(Name);
                AppDataHelper.GetDatabase().GetReference("XamarinClientRanking/" + thisuserRanking.ID + "/Time").SetValue(Timer);
                AppDataHelper.GetDatabase().GetReference("XamarinClientRanking/" + thisuserRanking.ID + "/Score").SetValue(Score);


                Snackbar snackbar = Snackbar.Make(linearLayout, "Add Success", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Green);
                snackbar.Show();

            });
            saveDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
            {

                Snackbar snackbar = Snackbar.Make(linearLayout, "Add Failed", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
                saveDataAlert.Dispose();
            });

            saveDataAlert.Show();
        }

        private void AddRanking_Click(object sender, EventArgs e)
        {
            string Name = usertText.Text;
            string Score = txtScore.Text;
            string Timer = timer.Text;


            AlertDialog.Builder saveDataAlert = new AlertDialog.Builder(Activity);
            saveDataAlert.SetTitle("Save Change");
            saveDataAlert.SetMessage("Are you sure?");
            saveDataAlert.SetPositiveButton("Continue", (senderAlert, args) =>
            {

                AppDataHelper.GetDatabase().GetReference("ClientRanking/" + thisuserRanking.ID + "/Name").SetValue(Name);
                AppDataHelper.GetDatabase().GetReference("ClientRanking/" + thisuserRanking.ID + "/Time").SetValue(Timer);
                AppDataHelper.GetDatabase().GetReference("ClientRanking/" + thisuserRanking.ID + "/Score").SetValue(Score);
         

                Snackbar snackbar = Snackbar.Make(linearLayout, "Add Success", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Green);
                snackbar.Show();

            });
            saveDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
            {

                Snackbar snackbar = Snackbar.Make(linearLayout, "Add Failed", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
                saveDataAlert.Dispose();
            });

            saveDataAlert.Show();
        }
    }
}