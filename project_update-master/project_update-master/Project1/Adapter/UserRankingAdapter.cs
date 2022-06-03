using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Project1.EventListener;
using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Adapter
{
    public class UserRankingAdapter : RecyclerView.Adapter
    {


        public event EventHandler<UserRankingAdapterClickEventArgs> ItemClick;
        public event EventHandler<UserRankingAdapterClickEventArgs> ItemLongClick;
        public event EventHandler<UserRankingAdapterClickEventArgs> DeleteItemClick;

        List<UserRanking> Items;

        private Context context;

        public UserRankingAdapter(List<UserRanking>Data)
        {
            Items = Data;
        }

        public override int ItemCount => Items.Count;



        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var holder = viewHolder as UserRankingAdapterViewHolder;
            //holder.TextView.Text = items[position];
            holder.nameText.Text = Items[position].Name;

            holder.scoreText.Text =  Items[position].Score;
            holder.timeText.Text = Items[position].Time;


         
          
     

        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //Setup your layout here
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.user_ranking_item, parent, false);



            var vh = new UserRankingAdapterViewHolder(itemView, OnClick, OnLongClick, OnDeleteClick);
            return vh;
        }

        public Action<object, UserRankingListeners.UserRankingDataEventArgs> UserRankingRetrived { get; internal set; }


        void OnClick(UserRankingAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(UserRankingAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

        void OnDeleteClick(UserRankingAdapterClickEventArgs args) => DeleteItemClick(this, args);


    }


    public class UserRankingAdapterViewHolder : RecyclerView.ViewHolder
    {
        //public TextView TextView { get; set; }
        public TextView nameText { get; set; }
        public TextView scoreText { get; set; }
        public TextView timeText { get; set; }

        public ImageView deleteButton { get; set; }

        public UserRankingAdapterViewHolder(View itemView, Action<UserRankingAdapterClickEventArgs> clickListener,
                            Action<UserRankingAdapterClickEventArgs> LongClickListener, Action<UserRankingAdapterClickEventArgs> deleteClickListener) : base(itemView)
        {
            //TextView = v;
            nameText = (TextView)itemView.FindViewById(Resource.Id.userText);
            timeText = (TextView)itemView.FindViewById(Resource.Id.timer);
            scoreText = (TextView)itemView.FindViewById(Resource.Id.score);
            deleteButton = (ImageView)itemView.FindViewById(Resource.Id.deleteButton);

            itemView.Click += (sender, e) => clickListener(new UserRankingAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.Click += (sender, e) => LongClickListener(new UserRankingAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            deleteButton.Click += (sender, e) => deleteClickListener(new UserRankingAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }



    public class UserRankingAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}