using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Fragment
{
    [Obsolete]
    public class dialog_support :DialogFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.introlayout, container, false);

            Activity.RunOnUiThread(() =>
            {
                ISharedPreferences getPrefs = PreferenceManager.GetDefaultSharedPreferences(Context);
                bool isFirstStart = getPrefs.GetBoolean("firstStart", true);

                if (isFirstStart)
                {
                    StartActivity(new Intent(Context, typeof(MyIntro)));
                    // Finish();
                    ISharedPreferencesEditor editor = getPrefs.Edit();
                    editor.PutBoolean("finish Start", false);
                    editor.Apply();
                }
            });

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.ActionBar);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}