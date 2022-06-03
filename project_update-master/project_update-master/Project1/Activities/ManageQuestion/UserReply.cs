using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System;

using System.Collections.Generic;

using System.Linq;
using Project1.Fragment;
using Project1.Model;
using Project1.EventListeners;
using Project1.Adapter;
using Xamarin.Essentials;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Graphics;
using Android.Content;
using Project1.Activities.Study.Question;
using static Project1.EventListeners.UserQuestionListeners;

namespace Project1.Activities.ManageQuestion
{
    [Activity(Label = "UserReply")]
    public class UserReply : AppCompatActivity
    {

        RecyclerView myRecyclerView;
        List<UserQuestion> xamarinList;




        UserQuestionAdapter adapter;
        UserQuestionListeners xamarinListeners;

        ImageView btnadd, btnBack;
        AddUserReplyFragment addUserReplyFragment;


        LinearLayout linearLayout1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Answer);

            btnadd = (ImageView)FindViewById(Resource.Id.addButton);
            btnBack = (ImageView)FindViewById(Resource.Id.backButton);

            linearLayout1 = (LinearLayout)FindViewById(Resource.Id.linearLayout1);


            btnBack.Click += BtnBack_Click;

            btnadd.Click += Btnadd_Click1;

            myRecyclerView = (RecyclerView)FindViewById(Resource.Id.recyclerView1);



            RetriveData();
            // Create your application here
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);
        }

        private void Btnadd_Click1(object sender, EventArgs e)
        {
            addUserReplyFragment = new AddUserReplyFragment();
            var trans = SupportFragmentManager.BeginTransaction();
            addUserReplyFragment.Show(trans, "new alumini");
        }

        public void RetriveData()
        {
            xamarinListeners = new UserQuestionListeners();
            xamarinListeners.Create4();
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
            adapter.DeleteItemClick += Adapter_DeleteItemClick;

            adapter.ItemLongClick += Adapter_ItemLongClick1;
           //  adapter.ItemLongClick += Adapter_ItemLongClick;
            myRecyclerView.SetAdapter(adapter);
        }

        //Delete 
        private void Adapter_DeleteItemClick(object sender, UserQuestionAdapterClickEventArgs e)
        {
            string key = xamarinList[e.Position].ID;
            Android.Support.V7.App.AlertDialog.Builder deleteAlumini = new Android.Support.V7.App.AlertDialog.Builder(this);
            deleteAlumini.SetTitle("Delete User Reply");
            deleteAlumini.SetMessage("Are you sure?");
            deleteAlumini.SetPositiveButton("Continue", (deleteAlert, args) =>
            {
                // Deletes Alumini From the Database
                xamarinListeners.DeleteUserReply(key);

                Snackbar snackbar = Snackbar.Make(linearLayout1, "Delete Success", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Green);
                snackbar.Show();

            });

            deleteAlumini.SetNegativeButton("Cancel", (deleteAlert, args) =>
            {
                deleteAlumini.Dispose();
                Snackbar snackbar = Snackbar.Make(linearLayout1, "Delete Failed !!", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
            });

            deleteAlumini.Show();
        }

        private void Adapter_ItemLongClick1(object sender, UserQuestionAdapterClickEventArgs e)
        {

            UserQuestion thisXamarin = xamarinList[e.Position];

            //Intent intent = new Intent(Context, typeof(detailxamarin));
            //detailxamarin detailxamarin = new detailxamarin(thisXamarin);
            //  intent.PutExtra("edit", (Java.IO.ISerializable)thisXamarin);
            //StartActivity(intent);
            detailQuestion editAluminiFragment = new detailQuestion(thisXamarin);
            var trans = SupportFragmentManager.BeginTransaction();

            editAluminiFragment.Show(trans, "edit");
        }
    }
}