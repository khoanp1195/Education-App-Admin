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

namespace Project1.EventListeners
{
    public class UserProfileListeners : Java.Lang.Object, IValueEventListener
    {
        List<UserProfile> userprofileList = new List<UserProfile>();

        public event EventHandler<AluminDataEventArgs> AluminRetrived;

        public class AluminDataEventArgs : EventArgs
        {
            public List<UserProfile> UserProfile { get; set; }
        }

        public void OnCancelled(DatabaseError error)
        {
           
        }

        public void OnDataChange(DataSnapshot snapshot)
        {
           if(snapshot.Value != null)
            {
                var child = snapshot.Children.ToEnumerable<DataSnapshot>();
                userprofileList.Clear();
               foreach (DataSnapshot userprofileData in child)
                {
                    UserProfile userProfile = new UserProfile();
                    userProfile.ID = userprofileData.Key;
                     userProfile.fullname = userprofileData.Child("fullname").Value.ToString();
                     userProfile.email = userprofileData.Child("email").Value.ToString();
                     userProfile.phone = userprofileData.Child("phone").Value.ToString();
               

      


                  
                    userprofileList.Add(userProfile);
                }
                AluminRetrived.Invoke(this, new AluminDataEventArgs {UserProfile = userprofileList });
            }
          
        }



        //Select Normal
        public void Create()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("users");
            alumiRef.AddValueEventListener(this);
        }






        public void DeleteAlumini(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("users/" + key);
            reference.RemoveValue();
        }


        public void DeleteNormal(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("Normal/" + key);
            reference.RemoveValue();
        }



        public void DeleteAdvanced(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("Advanced/" + key);
            reference.RemoveValue();
        }
    }
}