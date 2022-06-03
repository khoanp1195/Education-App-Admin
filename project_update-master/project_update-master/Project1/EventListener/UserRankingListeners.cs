using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using Project1.Helpers;
using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.EventListener
{
    public class UserRankingListeners : Java.Lang.Object, IValueEventListener
    {
        List<UserRanking> userrankingList = new List<UserRanking>();

        public event EventHandler<UserRankingDataEventArgs> UserRankingRetrived;


        public class UserRankingDataEventArgs : EventArgs
        {
            public List<UserRanking> UserRanking { get; set; }
        }

        public void OnCancelled(DatabaseError error)
        {
          
        }

        public void OnDataChange(DataSnapshot snapshot)
        {
            if (snapshot.Value != null)
            {
                var child = snapshot.Children.ToEnumerable<DataSnapshot>();
                userrankingList.Clear();
                foreach (DataSnapshot userrankingData in child)
                {
                    UserRanking userRanking = new UserRanking();
                    userRanking.ID = userrankingData.Key;
                    userRanking.Name = userrankingData.Child("Name").Value.ToString();
                    userRanking.Score = userrankingData.Child("Score").Value.ToString();
                    userRanking.Time = userrankingData.Child("Time").Value.ToString();
         
               
                    userrankingList.Add(userRanking);
                }
                UserRankingRetrived.Invoke(this, new UserRankingDataEventArgs { UserRanking = userrankingList });
            }
        }


        //Select Normal
        public void Create()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("UserRanking");
            alumiRef.AddValueEventListener(this);
        }
        public void DeleteUserRanking(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("UserRanking/" + key);
            reference.RemoveValue();
        }



        public void Create2()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("ClientRanking");
            alumiRef.AddValueEventListener(this);
        }
        public void DeleteClientRanking(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("ClientRanking/" + key);
            reference.RemoveValue();
        }



        public void Create3()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("UserXamarinRanking");
            alumiRef.AddValueEventListener(this);
        }


        public void DeleteXamarinRanking(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("UserXamarinRanking/" + key);
            reference.RemoveValue();
        }







        public void Create4()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("UserFlagRanking");
            alumiRef.AddValueEventListener(this);
        }


        public void DeleteFlagRanking(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("UserFlagRanking/" + key);
            reference.RemoveValue();
        }



        
        public void Create5()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("XamarinClientRanking");
            alumiRef.AddValueEventListener(this);
        }
        public void DeleteClientXamarinRanking(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("XamarinClientRanking/" + key);
            reference.RemoveValue();
        }


        public void Create6()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("FlagClientRanking");
            alumiRef.AddValueEventListener(this);
        }
        public void DeleteClientFlagRanking(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("FlagClientRanking/" + key);
            reference.RemoveValue();
        }


    }
}