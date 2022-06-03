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

namespace Project1.Fragment
{
    [Activity(Label = "EditAdvancedEnglish")]
    public class EditAdvancedEnglish : Android.Support.V4.App.DialogFragment, TextToSpeech.IOnInitListener
    {
        EditText fullnameText, departmentText, setText, example, status, tuloai, example2;

        LinearLayout linearLayout;

        Alumini thisAlunini;


        Button savechangesButton;
        ImageView speakbtn;

        private TextToSpeech tts;

        public EditAdvancedEnglish(Alumini alumini)
        {
            thisAlunini = alumini;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.edit_english, container, false);

            tts = new TextToSpeech(Context, this);
            speakbtn = (ImageView)view.FindViewById(Resource.Id.speakbtn);
            speakbtn.Click += delegate
            {
                SpeakOut();
            };

            fullnameText = (EditText)view.FindViewById(Resource.Id.fullnameText);
            example = (EditText)view.FindViewById(Resource.Id.example);
            departmentText = (EditText)view.FindViewById(Resource.Id.departmentText);
            setText = (EditText)view.FindViewById(Resource.Id.setText);
            status = (EditText)view.FindViewById(Resource.Id.statusTxt);
            tuloai = (EditText)view.FindViewById(Resource.Id.tuloai);
            example2 = (EditText)view.FindViewById(Resource.Id.example2);

            linearLayout = (LinearLayout)view.FindViewById(Resource.Id.linearLayout1);
            savechangesButton = (Button)view.FindViewById(Resource.Id.submitButton);
            savechangesButton.Click += SavechangesButton_Click;

            fullnameText.Text = thisAlunini.NewWord;
            departmentText.Text = thisAlunini.Mean;
            setText.Text = thisAlunini.Spelling;
            status.Text = thisAlunini.Level;
            tuloai.Text = thisAlunini.type;
            example.Text = "Example: " + thisAlunini.Example;
            example2.Text = "Mean English: " + thisAlunini.MeanEnglish;


            return view;
        }

        public void OnInit([GeneratedEnum] OperationResult status)
        {
            if (status == OperationResult.Success)
            {
                tts.SetLanguage(Locale.Us);
                tts.SetPitch(0.5f);
                tts.SetSpeechRate(2.0f);
                SpeakOut();
            }
        }


        private void SpeakOut()
        {
            string fullname = fullnameText.Text;

            //    AppDataHelper.GetDatabase().GetReference("Normal/" + thisAlunini.ID + "/NewWord").SetValue(fullname);
            if (!String.IsNullOrEmpty(fullname))
                tts.Speak(fullname, QueueMode.Flush, null);
        }




        private void SavechangesButton_Click(object sender, EventArgs e)
        {
            string newWord = fullnameText.Text;
            string mean = departmentText.Text;
            string spelling = setText.Text;
            string examplee = example.Text;
            string level = status.Text;
            string meanenglish = example2.Text;
            string type = tuloai.Text;




            AlertDialog.Builder saveDataAlert = new AlertDialog.Builder(Activity);
            saveDataAlert.SetTitle("Save Change");
            saveDataAlert.SetMessage("Are you sure?");
            saveDataAlert.SetPositiveButton("Continue", (senderAlert, args) =>
            {

                AppDataHelper.GetDatabase().GetReference("Advanced/" + thisAlunini.ID + "/NewWord").SetValue(newWord);
                AppDataHelper.GetDatabase().GetReference("Advanced/" + thisAlunini.ID + "/Mean").SetValue(mean);
                AppDataHelper.GetDatabase().GetReference("Advanced/" + thisAlunini.ID + "/Spelling").SetValue(spelling);
                AppDataHelper.GetDatabase().GetReference("Advanced/" + thisAlunini.ID + "/Type").SetValue(type);
                AppDataHelper.GetDatabase().GetReference("Advanced/" + thisAlunini.ID + "/Level").SetValue(level);
                AppDataHelper.GetDatabase().GetReference("Advanced/" + thisAlunini.ID + "/Example").SetValue(examplee);
                AppDataHelper.GetDatabase().GetReference("Advanced/" + thisAlunini.ID + "/MeanEnglish").SetValue(meanenglish);



                Snackbar snackbar = Snackbar.Make(linearLayout, "Update Success", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Green);
                snackbar.Show();

            });
            saveDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
            {

                Snackbar snackbar = Snackbar.Make(linearLayout, "Update Failed", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
                saveDataAlert.Dispose();
            });

            saveDataAlert.Show();

            //  this.Dismiss();
        }
    }
}