using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.ViewPager.Widget;
using Com.Airbnb.Lottie;
using Firebase.Auth;
using Project1.Helpers;
using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AndroidX.AppCompat.App;

namespace Project1
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory =true,ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class SplashScreenActivity : AppCompatActivity
    {
        private ViewPager pager;
        LottieAnimationView lottieAnimationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
       //    SetContentView(Resource.Layout.activity_splash_screen);

            Thread.Sleep(2000);
            //   lottieAnimationView = (LottieAnimationView)FindViewById(Resource.Id.lottie);
            //  lottieAnimationView.Animate().TranslationY(1400).SetDuration(1000).SetStartDelay(4000);


          



            // Create your application here
        }

        protected override void OnResume()
        {
            base.OnResume();
            // StartActivity(typeof(MainActivity)); //resume Mainactivity

            FirebaseUser currentUser = AppDataHelper.GetCurrentUser();


            if(currentUser != null)
            {
                StartActivity(typeof(MainActivity2));
            }
            else
            {
                StartActivity(typeof(MyIntro));
            }
          


        }


    }
    }
