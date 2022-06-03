using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Project1.Adapter;
using Project1.EventListener;
using Project1.Fragment;
using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Activities.Study.UserProfile
{
    [Activity(Label = "RankingManagement")]
    public class XamarinRankingManagement : AppCompatActivity
    {

        RecyclerView myRecyclerView;
        List<UserRanking> userrankingList;
        UserRankingAdapter adapter;

        ImageView searchButton, backButton;
        EditText searchText;


        NestedScrollView linearLayout1;
        UserRankingListeners userrankingListeners;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ranking_fragment);
            // Create your application here

            searchText = (EditText)FindViewById(Resource.Id.searchText);
            backButton = FindViewById<ImageView>(Resource.Id.backButton);
            backButton.Click += BackButton_Click;


            searchButton = (ImageView)FindViewById(Resource.Id.searchButton);
            searchButton.Click += SearchButton_Click;


            linearLayout1 = FindViewById<NestedScrollView>(Resource.Id.linearLayout1);

            myRecyclerView = (RecyclerView)FindViewById(Resource.Id.recyclerView1);
            RetriveData();
            searchText.TextChanged += SearchText_TextChanged;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);
        }

        //Search
        private void SearchButton_Click(object sender, System.EventArgs e)
        {
            if (searchText.Visibility == Android.Views.ViewStates.Gone)
            {
                searchText.Visibility = Android.Views.ViewStates.Visible;
            }
            else
            {
                searchText.ClearFocus();
                searchText.Visibility = Android.Views.ViewStates.Gone;
            }
        }

        private void SearchText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            List<UserRanking> SearchResult = new List<UserRanking>
                (from  UserRanking in userrankingList
                 where UserRanking.Name.ToLower().Contains(searchText.Text.ToLower()) || UserRanking.Score.ToLower().Contains(searchText.Text.ToLower()) 
                 select UserRanking).ToList();


            adapter = new UserRankingAdapter(SearchResult);
            adapter.DeleteItemClick += Adapter_DeleteItemClick;


            adapter.ItemLongClick += Adapter_ItemLongClick1;
            myRecyclerView.SetAdapter(adapter);

        }
        public void RetriveData()
        {
            userrankingListeners = new UserRankingListeners();
            userrankingListeners.Create3();
            userrankingListeners.UserRankingRetrived += UserrankingListeners_UserRankingRetrived;
        }

        private void UserrankingListeners_UserRankingRetrived(object sender, UserRankingListeners.UserRankingDataEventArgs e)
        {
            userrankingList = e.UserRanking;
            SetupRecyClerView();
        }
        private void SetupRecyClerView()
        {
            myRecyclerView.SetLayoutManager(new Android.Support.V7.Widget.LinearLayoutManager(myRecyclerView.Context));
            adapter = new UserRankingAdapter(userrankingList);
               adapter.DeleteItemClick += Adapter_DeleteItemClick;

            adapter.ItemLongClick += Adapter_ItemLongClick1 ;
            //  adapter.ItemLongClick += Adapter_ItemLongClick;
            myRecyclerView.SetAdapter(adapter);
        }
        private void Adapter_ItemLongClick1(object sender, UserRankingAdapterClickEventArgs e)
        {
            UserRanking thisUserRanking = userrankingList[e.Position];
            detailrankingFragment editAluminiFragment = new detailrankingFragment(thisUserRanking);
            var trans = SupportFragmentManager.BeginTransaction();
            editAluminiFragment.Show(trans, "edit");
        }


        //Delete 
        private void Adapter_DeleteItemClick(object sender, UserRankingAdapterClickEventArgs e)
        {
            string key = userrankingList[e.Position].ID;
            Android.Support.V7.App.AlertDialog.Builder deleteAlumini = new Android.Support.V7.App.AlertDialog.Builder(this);
            deleteAlumini.SetTitle("Delete User Ranking");
            deleteAlumini.SetMessage("Are you sure?");
            deleteAlumini.SetPositiveButton("Continue", (deleteAlert, args) =>
            {

                // Deletes Alumini From the Database
                userrankingListeners.DeleteXamarinRanking(key);

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

    }
}