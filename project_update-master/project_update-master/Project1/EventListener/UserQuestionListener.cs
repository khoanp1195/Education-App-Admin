using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using Project1.Helpers;
using Project1.Model;
using static Project1.EventListeners.UserQuestionListeners;

namespace Project1.EventListeners
{
    public class UserQuestionListeners : Java.Lang.Object, IValueEventListener
    {
        List<UserQuestion> xamarinList = new List<UserQuestion>();

        public event EventHandler<UserQuesionDataEventArgs> AluminRetrived;

        public class UserQuesionDataEventArgs : EventArgs
        {
            public List<UserQuestion> UserQuestions { get; set; }
        }

        public void OnCancelled(DatabaseError error)
        {

        }

        public void OnDataChange(DataSnapshot snapshot)
        {
            if (snapshot.Value != null)
            {
                var child = snapshot.Children.ToEnumerable<DataSnapshot>();
                xamarinList.Clear();
                foreach (DataSnapshot xamarinData in child)
                {
                    UserQuestion xamarinCourse = new UserQuestion();
                    xamarinCourse.ID = xamarinData.Key;
                    xamarinCourse.Title = xamarinData.Child("Title").Value.ToString();
                    xamarinCourse.Content = xamarinData.Child("Content").Value.ToString();
                    xamarinCourse.Contribute = xamarinData.Child("User").Value.ToString();
                    xamarinCourse.Category = xamarinData.Child("Category").Value.ToString();
                    xamarinCourse.Timer = xamarinData.Child("Timer").Value.ToString();



                    xamarinList.Add(xamarinCourse);
                }
                AluminRetrived.Invoke(this, new UserQuesionDataEventArgs { UserQuestions = xamarinList });
            }

        }



        //Select Normal
        public void Create()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("UserQuestion");
            alumiRef.AddValueEventListener(this);
        }


        //Select Normal
        public void Create1(string key)
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference(key + "/UserReply");
            alumiRef.AddValueEventListener(this);
        }


        public void Create4()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("UserReply");
            alumiRef.AddValueEventListener(this);
        }


        public void Create5()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("TodayQuesiton");
            alumiRef.AddValueEventListener(this);
        }
        public void Create6()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("HistoryUserQuestion");
            alumiRef.AddValueEventListener(this);
        }
        public void Create7()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("UserResponse");
            alumiRef.AddValueEventListener(this);
        }

        public void DeleteUserQuestion(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("UserQuestion/" + key);
            reference.RemoveValue();
        }
        public void DeleteUserReply(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("UserReply/" + key);
            reference.RemoveValue();
        }

        public void DeleteTodayQuestion(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("TodayQuesiton/" + key);
            reference.RemoveValue();
        }

        public void DeleteHistoryUserQuestion(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("HistoryUserQuestion/" + key);
            reference.RemoveValue();
        }
        public void DeleteUserResponse(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("UserResponse/" + key);
            reference.RemoveValue();
        }


    }
}