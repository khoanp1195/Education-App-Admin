
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project1.EventListeners;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech.Tts;
using Android.Support.Design.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Util;
using Project1.Helpers;
using Project1.Model;
using Android.Graphics;
using static Android.Support.V7.Widget.RecyclerView;
using Project1.Helpers;
using Project1.Fragment;
using Android.Support.V7.Widget;
using Project1.Adapter;
using static Project1.EventListeners.UserQuestionListeners;
using Android.Support.V4.Widget;

namespace Project1
{
    [Activity(Label = "detailxamarin")]
    public class detailQuestion : Android.Support.V4.App.DialogFragment
    {
        TextView course, userText, content1Text, content2Text, timer;
        LinearLayout linearLayout;
        Button repply, addhome, addhistory;
        AddAluminFragment addAluminFragment;
        UserQuestion thisCourse;
        RecyclerView myRecyclerView;
        List<UserQuestion> xamarinList;
        UserQuestionAdapter adapter;

        NestedScrollView nestedScrollView1;

        UserQuestionListeners xamarinListeners;
        //public detailQuestion()
        //{
        //}

        public detailQuestion(UserQuestion xamarin)
        {
            thisCourse = xamarin;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.detailQuestion, container, false);

            repply = view.FindViewById<Button>(Resource.Id.repply);


            addhome = view.FindViewById<Button>(Resource.Id.addhome);

            addhome.Click += Addhome_Click;

            addhistory = view.FindViewById<Button>(Resource.Id.addhistory);

            addhistory.Click += Addhistory_Click;


            nestedScrollView1 = (NestedScrollView)view.FindViewById(Resource.Id.nestedScrollView1);




            repply.Click += Repply_Click;

            course = view.FindViewById<TextView>(Resource.Id.course);
            userText = view.FindViewById<TextView>(Resource.Id.userText);
            content1Text = view.FindViewById<TextView>(Resource.Id.content1Text);
            content2Text = view.FindViewById<TextView>(Resource.Id.content2Text);
            timer = view.FindViewById<TextView>(Resource.Id.timer);
            myRecyclerView = (RecyclerView)view.FindViewById(Resource.Id.recyclerView1);

            linearLayout = (LinearLayout)view.FindViewById(Resource.Id.linearLayout1);


            course.Text = thisCourse.Title;
            userText.Text = thisCourse.Contribute;
            timer.Text = thisCourse.Timer;
          

            content1Text.Text = thisCourse.Category;
            content2Text.Text = thisCourse.Content;

            RetriveData();
            return view;
        }

        private void Addhistory_Click(object sender, EventArgs e)
        {

            string title = course.Text;
            string content = content1Text.Text;
            string user = userText.Text;
            string timer1 = timer.Text;
            string category = content2Text.Text;





            Android.App.AlertDialog.Builder saveDataAlert = new AlertDialog.Builder(Activity);
            saveDataAlert.SetTitle("Add Reply");
            saveDataAlert.SetMessage("Are you sure?");
            saveDataAlert.SetPositiveButton("Continue", (senderAlert, args) =>
            {

                AppDataHelper.GetDatabase().GetReference("HistoryUserQuestion/" + thisCourse.ID + "/Title").SetValue(title);
                AppDataHelper.GetDatabase().GetReference("HistoryUserQuestion/" + thisCourse.ID + "/Content").SetValue(content);
                AppDataHelper.GetDatabase().GetReference("HistoryUserQuestion/" + thisCourse.ID + "/User").SetValue(user);
                AppDataHelper.GetDatabase().GetReference("HistoryUserQuestion/" + thisCourse.ID + "/Timer").SetValue(timer1);
                AppDataHelper.GetDatabase().GetReference("HistoryUserQuestion/" + thisCourse.ID + "/Category").SetValue(category);





                Snackbar snackbar = Snackbar.Make(nestedScrollView1, "Added History User Success", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Green);
                snackbar.Show();

            });
            saveDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
            {

                Snackbar snackbar = Snackbar.Make(nestedScrollView1, "Added Failed", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
                saveDataAlert.Dispose();
            });

            saveDataAlert.Show();
        }

        private void Addhome_Click(object sender, EventArgs e)
        {

            string title = course.Text;
            string content = content1Text.Text;
            string user = userText.Text;
            string timer1 = timer.Text;
            string category = content2Text.Text;





            Android.App.AlertDialog.Builder saveDataAlert = new AlertDialog.Builder(Activity);
            saveDataAlert.SetTitle("Add Reply");
            saveDataAlert.SetMessage("Are you sure?");
            saveDataAlert.SetPositiveButton("Continue", (senderAlert, args) =>
            {

                AppDataHelper.GetDatabase().GetReference("TodayQuesiton/" + thisCourse.ID + "/Title").SetValue(title);
                AppDataHelper.GetDatabase().GetReference("TodayQuesiton/" + thisCourse.ID + "/Content").SetValue(content);
                AppDataHelper.GetDatabase().GetReference("TodayQuesiton/" + thisCourse.ID + "/User").SetValue(user);
                AppDataHelper.GetDatabase().GetReference("TodayQuesiton/" + thisCourse.ID + "/Timer").SetValue(timer1);
                AppDataHelper.GetDatabase().GetReference("TodayQuesiton/" + thisCourse.ID + "/Category").SetValue(category);





                Snackbar snackbar = Snackbar.Make(nestedScrollView1, "Added TodayQuestion Success", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Green);
                snackbar.Show();

            });
            saveDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
            {

                Snackbar snackbar = Snackbar.Make(nestedScrollView1, "Added Failed", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
                saveDataAlert.Dispose();
            });

            saveDataAlert.Show();



        }

        private void Repply_Click(object sender, EventArgs e)
        {


            string title = course.Text;
            string content = content1Text.Text;
            string user = userText.Text;
            string timer1 = timer.Text;
            string category = content2Text.Text;





            AlertDialog.Builder saveDataAlert = new AlertDialog.Builder(Activity);
            saveDataAlert.SetTitle("Add Reply");
            saveDataAlert.SetMessage("Are you sure?");
            saveDataAlert.SetPositiveButton("Continue", (senderAlert, args) =>
            {

                AppDataHelper.GetDatabase().GetReference("UserReply/" + thisCourse.ID + "/Title").SetValue(title);
                AppDataHelper.GetDatabase().GetReference("UserReply/" + thisCourse.ID + "/Content").SetValue(content);
                AppDataHelper.GetDatabase().GetReference("UserReply/" + thisCourse.ID + "/User").SetValue(user);
                AppDataHelper.GetDatabase().GetReference("UserReply/" + thisCourse.ID + "/Timer").SetValue(timer1);
                AppDataHelper.GetDatabase().GetReference("UserReply/" + thisCourse.ID + "/Category").SetValue(category);





                Snackbar snackbar = Snackbar.Make(nestedScrollView1, "Added UserReply Success", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Green);
                snackbar.Show();

            });
            saveDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
            {

                Snackbar snackbar = Snackbar.Make(nestedScrollView1, "Added UserReply Failed", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
                saveDataAlert.Dispose();
            });

            saveDataAlert.Show();
        }
        public void RetriveData()
        {
 
     
            xamarinListeners = new UserQuestionListeners();
            xamarinListeners.Create();
            xamarinListeners.AluminRetrived += XamarinListeners_AluminRetrived1;
        }
        private void XamarinListeners_AluminRetrived1(object sender, UserQuesionDataEventArgs e)
        {
            xamarinList = e.UserQuestions;
            SetupRecyClerView();
        }
        private void SetupRecyClerView()
        {
            myRecyclerView.SetLayoutManager(new Android.Support.V7.Widget.LinearLayoutManager(myRecyclerView.Context));
            adapter = new UserQuestionAdapter(xamarinList);
            //    adapter.DeleteItemClick += Adapter_DeleteItemClick;

           // adapter.ItemLongClick += Adapter_ItemLongClick1;
            //   adapter.ItemLongClick += Adapter_ItemLongClick;
            myRecyclerView.SetAdapter(adapter);
        }
    }
}