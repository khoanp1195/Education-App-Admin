using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Graphics;
using Project1.Model;
using Android.Content;
using Xamarin.Essentials;
using Project1.EventListeners;

namespace Project1.Adapter
{
    class UserProfileAdapter : RecyclerView.Adapter
    {
        public event EventHandler<AluminiAdapterClickEventArgs> ItemClick;
        public event EventHandler<AluminiAdapterClickEventArgs> ItemLongClick;
        public event EventHandler<AluminiAdapterClickEventArgs> DeleteItemClick; 
        List<UserProfile> Items;

        private Context context;
        public UserProfileAdapter(List<UserProfile>Data)
        {
            Items = Data;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.userRow, parent, false);
           


            var vh = new UserProfileAdapterViewHolder(itemView, OnClick, OnLongClick, OnDeleteClick);
            return vh;
        }





        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var holder = viewHolder as UserProfileAdapterViewHolder;
            //holder.TextView.Text = items[position];
            holder.fullnameText.Text = "Fullname: "+ Items[position].fullname;
           
            holder.phoneText.Text = "Phone Number: " + Items[position].phone;
            holder.emailText.Text = "Email: " + Items[position].email;
         

     



        

        }

        public override int ItemCount => Items.Count;

        public Action<object, AluminListeners.AluminDataEventArgs> AluminRetrived { get; internal set; }

        void OnClick(AluminiAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(AluminiAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);
        void OnDeleteClick(AluminiAdapterClickEventArgs args) => DeleteItemClick(this, args);
    }



   


    public class UserProfileAdapterViewHolder : RecyclerView.ViewHolder
    {
        //public TextView TextView { get; set; }
        public TextView fullnameText { get; set; }
        public TextView emailText { get; set; }
        public TextView phoneText { get; set; }
     
        public UserProfileAdapterViewHolder(View itemView, Action<AluminiAdapterClickEventArgs> clickListener,
                            Action<AluminiAdapterClickEventArgs> LongClickListener, Action<AluminiAdapterClickEventArgs> deleteClickListener) : base(itemView)
        {
            //TextView = v;
            fullnameText = (TextView)itemView.FindViewById(Resource.Id.nameText);
        
            phoneText = (TextView)itemView.FindViewById(Resource.Id.status);
            emailText = (TextView)itemView.FindViewById(Resource.Id.setText);
          
                itemView.Click += (sender, e) => clickListener(new AluminiAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.Click += (sender, e) => LongClickListener(new AluminiAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
         //   deleteButton.Click += (sender, e) => deleteClickListener(new AluminiAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }
  


    public class UserProfileClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}