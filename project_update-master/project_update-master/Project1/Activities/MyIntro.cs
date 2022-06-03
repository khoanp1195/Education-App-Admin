using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1
{
    [Activity(Label = "MyIntro")]
    public class MyIntro : AppIntro.AppIntro
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AddSlide(AppIntro.AppIntroFragment.NewInstance("English Quiz", "Improve Your English", Resource.Drawable.bg_quizz1, Resource.Color.followersBg));

            AddSlide(AppIntro.AppIntroFragment.NewInstance("English Dictionary", "Improve Your English", Resource.Drawable.bg_quizz1, Resource.Color.followersBg));

            AddSlide(AppIntro.AppIntroFragment.NewInstance("Test IQ", "Help you know about Your IQ", Resource.Drawable.bg_quizz1, Resource.Color.gradEnd));
            AddSlide(AppIntro.AppIntroFragment.NewInstance("Technology", "Help you know about Technologu", Resource.Drawable.bg_quizz1, Resource.Color.followersBg));
           


            ShowStatusBar(false);
            SetBarColor(Resource.Color.white);

            SetSeparatorColor(Resource.Color.white);

        }
        public override void OnDonePressed()
        {
            StartActivity(new Intent(this, typeof(WelcomeActivity)));
            Finish();
        }

        public override void OnSkipPressed()
        {
            Toast.MakeText(this, "skIPPPP", ToastLength.Short).Show();
            StartActivity(new Intent(this, typeof(WelcomeActivity)));

        }
        public override void OnSlideChanged()
        {
            Toast.MakeText(this, "Skip clicked", ToastLength.Short).Show();
        }
    }
}