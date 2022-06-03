﻿using Android.App;
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
using Com.Airbnb.Lottie;
using static Project1.EventListeners.UserQuestionListeners;

namespace Project1.Activities.ManageQuestion
{
    [Activity(Label = "UserResponse")]
    public class UserResponse : AppCompatActivity
    {
        RecyclerView myRecyclerView;
        List<UserQuestion> xamarinList;

        UserQuestionListeners xamarinListeners;
        EditText search;
        ImageView btnadd;


        AddAluminFragment addAluminFragment;

        LottieAnimationView problemlottie;

        LinearLayout linearLayout;

        UserQuestionAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Answer);

            // Create your application here
            Control();
            RetriveData();
        }


        public void Control()
        {
            //  relativeLayout1 = (RelativeLayout)view.FindViewById(Resource.Id.relativeLayout1);

            search = (EditText)FindViewById(Resource.Id.searchText);
            btnadd = (ImageView)FindViewById(Resource.Id.addButton);

            btnadd.Click += Btnadd_Click;


            myRecyclerView = (RecyclerView)FindViewById(Resource.Id.recyclerView1);
            linearLayout = (LinearLayout)FindViewById(Resource.Id.linearLayout1);




            //     problemlottie = (LottieAnimationView)view.FindViewById(Resource.Id.problem);
            search.TextChanged += SearchText_TextChanged;
            RetriveData();

            Control();

        }
        private void Btnadd_Click(object sender, EventArgs e)
        {
            addAluminFragment = new AddAluminFragment();
            var trans = SupportFragmentManager.BeginTransaction();
            addAluminFragment.Show(trans, "new alumini");
        }

        private void SearchText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            List<UserQuestion> SearchResult = new List<UserQuestion>
                (from Xamarin in xamarinList
                 where Xamarin.Title.ToLower().Contains(search.Text.ToLower()) || Xamarin.Content.ToLower().Contains(search.Text.ToLower()) ||
                 Xamarin.Category.ToLower().Contains(search.Text.ToLower()) || Xamarin.Contribute.ToLower().Contains(search.Text.ToLower())
                 select Xamarin).ToList();

            if (SearchResult.ToList() == null)
            {

                //     _ = problemlottie.Visibility == Android.Views.ViewStates.Gone;
                Snackbar snackbar = Snackbar.Make(linearLayout, "No Result", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();


            }
            else if (SearchResult.ToList() != null)
            {
                adapter = new UserQuestionAdapter(SearchResult);
            }

            //    adapter.DeleteItemClick += Adapter_DeleteItemClick;


            adapter.ItemLongClick += Adapter_ItemLongClick1;
            myRecyclerView.SetAdapter(adapter);

        }

        public void RetriveData()
        {
            xamarinListeners = new UserQuestionListeners();
            xamarinListeners.Create7();
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
            //   adapter.ItemLongClick += Adapter_ItemLongClick;
            myRecyclerView.SetAdapter(adapter);
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

        //private void Adapter_ItemLongClick(object sender, XamarinAdapter.AluminiAdapterClickEventArgs e)
        //{
        //}
        //Delete 
        private void Adapter_DeleteItemClick(object sender, UserQuestionAdapterClickEventArgs e)
        {
            string key = xamarinList[e.Position].ID;
            Android.Support.V7.App.AlertDialog.Builder deleteAlumini = new Android.Support.V7.App.AlertDialog.Builder(this);
            deleteAlumini.SetTitle("Delete User Question");
            deleteAlumini.SetMessage("Are you sure?");
            deleteAlumini.SetPositiveButton("Continue", (deleteAlert, args) =>
            {
                // Deletes Alumini From the Database
                xamarinListeners.DeleteUserResponse(key);

                Snackbar snackbar = Snackbar.Make(linearLayout, "Delete Success", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Green);
                snackbar.Show();

            });

            deleteAlumini.SetNegativeButton("Cancel", (deleteAlert, args) =>
            {
                deleteAlumini.Dispose();
                Snackbar snackbar = Snackbar.Make(linearLayout, "Delete Failed !!", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
            });

            deleteAlumini.Show();
        }
    }
}