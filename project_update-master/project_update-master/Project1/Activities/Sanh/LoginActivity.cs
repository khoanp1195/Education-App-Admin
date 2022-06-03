using Android.App;
using Android.Content;
using Android.Gms.Auth.Api;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common.Apis;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using Firebase;
using Firebase.Auth;
using Google.Android.Material.Snackbar;
using Project1.EventListener;
using Project1.Fragment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace Project1
{
    [Activity(Label = "LoginActivity", MainLauncher =false)]
    public class LoginActivity : Activity, IOnSuccessListener, IOnFailureListener
    {
        TextView forgotPass, 
            signingoogle, btnRegister;
        EditText edtEmail, edtPassword;
        Button btnLogin ;
        ImageView imgGoogle, imgFacebook, finger;
        ImageView back;
        ConstraintLayout constraintLayout1;
        TaskCompletionListener taskCompletionListener = new TaskCompletionListener();
        FirebaseAuth googlemAuth,mAuth;
        string email, password;

        //Sigin In Google
        GoogleSignInOptions gso;
        GoogleApiClient googleApiClient;

        [Obsolete]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);
            // Create your application here
          
            Control();
            IntializeDatabase();

            //Sign In With Google
            gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
                .RequestIdToken("188256006296-udl4ch755crsl6bpbak4tgpusfjk200c.apps.googleusercontent.com")
                .RequestEmail()
                .Build();
            googleApiClient = new GoogleApiClient.Builder(this)
                .AddApi(Auth.GOOGLE_SIGN_IN_API, gso).Build();

            googleApiClient.Connect();


         //  mAuth = IntializeDatabase();
        }


   

        //Setting Control
        void Control()
        {

         //   imgFacebook = FindViewById<ImageView>(Resource.Id.imgFacebook);
            imgGoogle = FindViewById<ImageView>(Resource.Id.imgGoogle);

     

            btnRegister = FindViewById<TextView>(Resource.Id.createNewBtn);
            edtEmail = FindViewById<EditText>(Resource.Id.emailBox);
            edtPassword = FindViewById<EditText>(Resource.Id.passwordBox);
            btnLogin = FindViewById<Button>(Resource.Id.submitBtn);
            btnLogin.Click += BtnLogin_Click;
            constraintLayout1 = (ConstraintLayout)FindViewById(Resource.Id.constraintLayout1);
            forgotPass = (TextView)FindViewById(Resource.Id.textView3);
            back = (ImageView)FindViewById(Resource.Id.back);

            back.Click += Back_Click;


            forgotPass.Click += ForgotPass_Click;


            btnRegister.Click += RegisterTxt_Click;

            imgGoogle.Click += Signingoogle_Click;
            
        }

        private void Back_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(WelcomeActivity)));
        }

        private void Signingoogle_Click(object sender, EventArgs e)
        {
            var intent = Auth.GoogleSignInApi.GetSignInIntent(googleApiClient);
            StartActivityForResult(intent, 1);
        }

        private void RegisterTxt_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(RegisterActivity)));
        }

        [Obsolete]
        private void ForgotPass_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_forgot dialog_Support = new dialog_forgot();
            dialog_Support.Show(transaction, "Support Here");
        }


        public void Vibrate()
        {
            // Use default vibration length
            Vibration.Vibrate();

            // Or use specified time
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
        }


        //
        void IntializeDatabase()
        {
            var app = FirebaseApp.InitializeApp(this);


            
            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                .SetApplicationId("project1-4e850")
                .SetApiKey("AIzaSyCou_P4H_wbYA3tWisjrOfq2b9nhYIzd7w")
                .SetDatabaseUrl("https://project1-4e850-default-rtdb.firebaseio.com")
                .SetStorageBucket("project1-4e850.appspot.com")
                .Build();

                app = FirebaseApp.InitializeApp(this, options);
                mAuth = FirebaseAuth.Instance;

            }
            else
            {

                mAuth = FirebaseAuth.Instance;
            }
           

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            string email, password;

            email = edtEmail.Text;
            password = edtPassword.Text;

            if (!email.Contains("@"))
            {
                Snackbar.Make(constraintLayout1, "Please provide a valid email", Snackbar.LengthShort).Show();
                Vibrate();
                return;
            }
            else if (password.Length < 6)
            {
                Snackbar.Make(constraintLayout1, "Please provide a valid password", Snackbar.LengthShort).Show();
                Vibrate();
                return;
            }

            TaskCompletionListener taskCompletionListener = new TaskCompletionListener();
            taskCompletionListener.Success += taskCompletionListener_Success;
            taskCompletionListener.Failure += taskCompletionListener_Failure;
            mAuth.SignInWithEmailAndPassword(email, password)
                .AddOnSuccessListener(taskCompletionListener)
                .AddOnFailureListener(taskCompletionListener);

           // loginUser(email,password);
        }


        //void loginUser(string email, string password)
        //{
        //    taskCompletionListener.Success += taskCompletionListener_Success;
        //    taskCompletionListener.Failure += taskCompletionListener_Failure;
        //    mAuth.SignInWithEmailAndPassword(email, password)
        //            .AddOnSuccessListener(taskCompletionListener)
        //            .AddOnFailureListener(taskCompletionListener);
        //}

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if(requestCode == 1)
            {
                GoogleSignInResult result = Auth.GoogleSignInApi.GetSignInResultFromIntent(data);
                if (result.IsSuccess)
                {
                    GoogleSignInAccount account = result.SignInAccount;
                    LoginWithFirebase(account);
                }

            }
        }

        private void LoginWithFirebase(GoogleSignInAccount account)
        {
            var credentials = GoogleAuthProvider.GetCredential(account.IdToken, null);
            mAuth.SignInWithCredential(credentials).AddOnSuccessListener(this)
            .AddOnFailureListener(this);

        }

        private void taskCompletionListener_Failure(object sender, EventArgs e)
        {
            Snackbar.Make(constraintLayout1, "SignIn Failed !! Please Again", Snackbar.LengthShort).Show();
        }

        private void taskCompletionListener_Success(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);

         
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);
        }

        public void OnFailure(Java.Lang.Exception e)
        {
            Vibrate();
            Snackbar.Make(constraintLayout1, "SignIn Failed !! Please Again", Snackbar.LengthShort).Show();

        }
    }
}