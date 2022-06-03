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


namespace Project1.Activities
{
    [Activity(Label = "UserContribute")]
    public class UserProfileee : Activity
    {


        ImageView addButton;
        ImageView searchButton, backButton;
        EditText searchText;
        RecyclerView myRecyclerView;
        List<UserProfile> UserProfileList;

        AddAluminFragment addAluminFragment;
        UserProfileListeners userprofileListener;



        EditText search;
        Button btnSearch;
        LinearLayout linearLayout;

        UserProfileAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here


            SetContentView(Resource.Layout.firebase);
            myRecyclerView = (RecyclerView)FindViewById(Resource.Id.recyclerView1);
            searchButton = (ImageView)FindViewById(Resource.Id.searchButton);
            addButton = (ImageView)FindViewById(Resource.Id.addNewButton);
            searchText = (EditText)FindViewById(Resource.Id.searchText);

            linearLayout = (LinearLayout)FindViewById(Resource.Id.linearLayout1);

            backButton = (ImageView)FindViewById(Resource.Id.backButton);

            backButton.Click += BackButton_Click;

            searchText.TextChanged += SearchText_TextChanged;
            searchButton.Click += SearchButton_Click;
            /// addButton.Click += AddButton_Click;





            RetriveData();
        }


        private void BackButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);
        }

        private void SearchText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            List<UserProfile> SearchResult = new List<UserProfile>
                (from alumini in UserProfileList
                 where alumini.fullname.ToLower().Contains(searchText.Text.ToLower()) || alumini.phone.ToLower().Contains(searchText.Text.ToLower()) ||
                 alumini.email.ToLower().Contains(searchText.Text.ToLower())
                 select alumini).ToList();


            adapter = new UserProfileAdapter(SearchResult);
            adapter.DeleteItemClick += Adapter_DeleteItemClick;


            //            adapter.ItemLongClick += Adapter_ItemLongClick1;
            myRecyclerView.SetAdapter(adapter);

        }
        public void RetriveData()
        {
            userprofileListener = new UserProfileListeners();
            userprofileListener.Create();
       
            userprofileListener.AluminRetrived += UserprofileListener_AluminRetrived;
        }

        private void UserprofileListener_AluminRetrived(object sender, UserProfileListeners.AluminDataEventArgs e)
        {
            UserProfileList = e.UserProfile;
            SetupRecyClerView();
        }

       

        //private void AddButton_Click(object sender, EventArgs e)
        //{
        //    addAluminFragment = new AddAluminFragment();
        //    var trans = SupportFragmentManager.BeginTransaction();
        //    addAluminFragment.Show(trans, "new alumini");
        //}

        private void SetupRecyClerView()
        {
            myRecyclerView.SetLayoutManager(new Android.Support.V7.Widget.LinearLayoutManager(myRecyclerView.Context));
            adapter = new UserProfileAdapter(UserProfileList);
            adapter.DeleteItemClick += Adapter_DeleteItemClick;


            //  adapter.ItemLongClick += Adapter_ItemLongClick1;
            myRecyclerView.SetAdapter(adapter);
        }

        //private void Adapter_ItemLongClick1(object sender, AluminiAdapterClickEventArgs e)
        //{
        //    Alumini thisAlumini = AluminiList[e.Position];
        //    EditAluminiFragment editAluminiFragment = new EditAluminiFragment(thisAlumini);
        //    var trans = SupportFragmentManager.BeginTransaction();
        //    editAluminiFragment.Show(trans, "edit");
        //}





        //Delete 
        private void Adapter_DeleteItemClick(object sender, AluminiAdapterClickEventArgs e)
        {
            string key = UserProfileList[e.Position].ID;
            Android.Support.V7.App.AlertDialog.Builder deleteAlumini = new Android.Support.V7.App.AlertDialog.Builder(this);
            deleteAlumini.SetTitle("Delete Alumini");
            deleteAlumini.SetMessage("Are you sure?");
            deleteAlumini.SetPositiveButton("Continue", (deleteAlert, args) =>
            {
                // Deletes Alumini From the Database
                userprofileListener.DeleteNormal(key);

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

        //public void CreateData()
        //{
        //    AluminiList = new List<Alumini>();
        //    AluminiList.Add(new Alumini { Department = "Department of Computer Science", FullName = "Mark Edwardds", ID = "1", Set = "2011", Status = "Graduated" });
        //    AluminiList.Add(new Alumini { Department = "Department of Civil Engineering", FullName = "Jonh Doe", ID = "2", Set = "2014", Status = "Graduated" });

        //    AluminiList.Add(new Alumini { Department = "Department of King Studies", FullName = "John Snow", ID = "3", Set = "2012", Status = "Drop Out" });
        //    AluminiList.Add(new Alumini { Department = "Department of History", FullName = "Uchenna Nnodim", ID = "4", Set = "2016", Status = "Graduated" });
        //    AluminiList.Add(new Alumini { Department = "Department of Computer Science", FullName = "Gregg Williams", ID = "5", Set = "2014", Status = "Failed" });

        //}


        //Recieve DATA


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
    }
}