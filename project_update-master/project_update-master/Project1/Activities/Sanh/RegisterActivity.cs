using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Auth;
using Firebase.Database;
using Firebase;
using System.Text.RegularExpressions;
using Android.Util;
using Google.Android.Material.Snackbar;
using AndroidX.ConstraintLayout.Widget;
using Android.Gms.Tasks;
using Project1.EventListener;
using Java.Util;
using Xamarin.Essentials;

namespace Project1
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        EditText fullname, email, password, phone;
        Button btnRegister;
        TextView signin;
        FirebaseAuth mAuth;
        FirebaseDatabase mDatabase;
        ConstraintLayout registerLayout;
        TaskCompletionListener taskCompletionListener = new TaskCompletionListener();
        string fullName, Email, Password, Phone;

        ISharedPreferences preferences = Application.Context.GetSharedPreferences("userInfo", FileCreationMode.Private);
        ISharedPreferencesEditor editor;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Register);
            ConnectControl();

            IntializeDatabase();
            RetriveData();
            SaveToShareReference();
            mAuth = FirebaseAuth.Instance;

            // Create your application here
        }


        void IntializeDatabase()
        {
            var app = FirebaseApp.InitializeApp(this);

            if (app == null)
            {
                var options = new Firebase.FirebaseOptions.Builder()
                .SetApplicationId("project1-4e850")
                .SetApiKey("AIzaSyCou_P4H_wbYA3tWisjrOfq2b9nhYIzd7w")
                .SetDatabaseUrl("https://project1-4e850-default-rtdb.firebaseio.com")
                .SetStorageBucket("project1-4e850.appspot.com")
                .Build();

                app = FirebaseApp.InitializeApp(this, options);
                mDatabase = FirebaseDatabase.GetInstance(app);
            }
            else
            {
                mDatabase = FirebaseDatabase.GetInstance(app);
            }
          //  DatabaseReference dbrf = mDatabase.GetReference("UserSupport");
           // dbrf.SetValue("Ticket");

            //Toast.MakeText(this, "Make Test", ToastLength.Short).Show();
        }


        void ConnectControl()
        {
            fullname = (EditText)FindViewById(Resource.Id.editName);
            email = (EditText)FindViewById(Resource.Id.edt_email);
            signin = (TextView)FindViewById(Resource.Id.signin);
            signin.Click += Signin_Click;
            password = (EditText)FindViewById(Resource.Id.edt_password);
            phone = (EditText)FindViewById(Resource.Id.edt_phone);
            registerLayout = (ConstraintLayout)FindViewById(Resource.Id.constraintLayout1);
            btnRegister = (Button)FindViewById(Resource.Id.button);
            btnRegister.Click += btnRegisterClick;
        }

        private void Signin_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(LoginActivity));
            //Vibrator vibrator = (Vibrator)GetSystemService(Context.VibratorService);
            //vibrator.Vibrate(100);

         ;
            StartActivity(intent);
        }

        public void Vibrate()
        {
            // Use default vibration length
            Vibration.Vibrate();

            // Or use specified time
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
        }

        private void btnRegisterClick(object sender, EventArgs e)
        {
          
            fullName = fullname.Text;
            Email = email.Text;
            Password = password.Text;
            Phone = phone.Text;

            if(fullName.Length <6)
            {
                Snackbar.Make(registerLayout, "Please Enter FullName >6 ", Snackbar.LengthShort).Show();
                Vibrate();
                return;
            }

            else if (Phone.Length < 6)
            {
                Snackbar.Make(registerLayout, "Sorry Please Again ", Snackbar.LengthShort).Show();
                Vibrate();
                return;
            }
            else if(!Email.Contains('@'))
            {
                Snackbar.Make(registerLayout, "Sorry Please Enter Email Have @ ", Snackbar.LengthShort).Show();
                Vibrate();
                return;
            }
            else if(Password.Length < 6)
            {
                Snackbar.Make(registerLayout, "Sorry Please Again ", Snackbar.LengthShort).Show();
                Vibrate();
                return;
            }
      ;
            RegisterUser(fullName, Phone, Email, Password);
        }

        void RegisterUser(string fullname, string phone, string email, string password)
        {
            taskCompletionListener.Success += taskCompletionListener_Success;
            taskCompletionListener.Failure += taskCompletionListener_Failure;

            mAuth.CreateUserWithEmailAndPassword(email, password)
                .AddOnSuccessListener(this, taskCompletionListener)
                .AddOnFailureListener(this, taskCompletionListener);
        }

        private void taskCompletionListener_Failure(object sender, EventArgs e)
        {
            Snackbar.Make(registerLayout, "Register Fail", Snackbar.LengthShort).Show();
        }

        private void taskCompletionListener_Success(object sender, EventArgs e)
        {
            Snackbar.Make(registerLayout, "Register Success", Snackbar.LengthShort).Show();
            HashMap userMap = new HashMap();

            userMap.Put("email", Email);
            userMap.Put("fullname", fullName);
            userMap.Put("phone", Phone);

            DatabaseReference userReference = mDatabase.GetReference("users/" + mAuth.CurrentUser.Uid);
            userReference.SetValue(userMap);
        }

        void SaveToShareReference()
        {
            ISharedPreferences preferences = Application.Context.GetSharedPreferences("userInfo", FileCreationMode.Private);//FileCreationMode tệp thông tin người dùng chế độ private
            ISharedPreferencesEditor editor;
            editor = preferences.Edit();
            editor.PutString("email", (string)email);
            editor.PutString("fulname", (string)fullname);
            editor.PutString("phone", (string)phone);

            editor.Apply();


        }

        void RetriveData()
        {
            string email = preferences.GetString("email", "");
        }

    }
    }
