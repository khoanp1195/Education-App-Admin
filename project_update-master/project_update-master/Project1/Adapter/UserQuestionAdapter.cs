using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Project1.EventListeners;
using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Project1.EventListeners.UserQuestionListeners;

namespace Project1.Adapter
{
    class UserQuestionAdapter : RecyclerView.Adapter
    {
        public event EventHandler<UserQuestionAdapterClickEventArgs> ItemClick;
        public event EventHandler<UserQuestionAdapterClickEventArgs> ItemLongClick;
        public event EventHandler<UserQuestionAdapterClickEventArgs> DeleteItemClick;
        List<UserQuestion> Items;

        private Context context;
        public UserQuestionAdapter(List<UserQuestion> Data)
        {
            Items = Data;
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //Setup your layout here
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.UserQuestionRow, parent, false);



            var vh = new UserQuestionAdapterViewHolder(itemView, OnClick, OnLongClick, OnDeleteClick);
            return vh;
        }



       

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var holder = viewHolder as UserQuestionAdapterViewHolder;
            //holder.TextView.Text = items[position];
            holder.titleText.Text = Items[position].Title;

            holder.contentText.Text = Items[position].Content;
        //    holder.categoryText.Text = Items[position].Category;
            holder.usercontributeText.Text = Items[position].Contribute;
            holder.timer1.Text = Items[position].Timer;




            holder.categoryText.Text = Items[position].Category;
            if (Items[position].Category == "Xamarin")
            {
                holder.categoryText.SetTextColor(Color.Rgb(9, 155, 11));
            }
            else if (Items[position].Category == "Interview")
            {
                holder.categoryText.SetTextColor(Color.Rgb(238, 134, 31));
            }


        }





        public override int ItemCount => Items.Count;

        public Action<object, UserQuesionDataEventArgs> AluminRetrived { get; internal set; }

        void OnClick(UserQuestionAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(UserQuestionAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);
        void OnDeleteClick(UserQuestionAdapterClickEventArgs args) => DeleteItemClick(this, args);

    }


        public class UserQuestionAdapterViewHolder : RecyclerView.ViewHolder
        {
            //public TextView TextView { get; set; }
            public TextView titleText { get; set; }
            public TextView contentText { get; set; }
            public TextView categoryText { get; set; }
            public TextView usercontributeText { get; set; }
            public TextView timer1 { get; set; }
            public ImageView deleteButton { get; set; }
            public UserQuestionAdapterViewHolder(View itemView, Action<UserQuestionAdapterClickEventArgs> clickListener,
                                Action<UserQuestionAdapterClickEventArgs> LongClickListener, Action<UserQuestionAdapterClickEventArgs> deleteClickListener) : base(itemView)
            {
                //TextView = v;
                titleText = (TextView)itemView.FindViewById(Resource.Id.course);
                contentText = (TextView)itemView.FindViewById(Resource.Id.content1Text);
                categoryText = (TextView)itemView.FindViewById(Resource.Id.content2Text);
                usercontributeText = (TextView)itemView.FindViewById(Resource.Id.userText);
                timer1 = (TextView)itemView.FindViewById(Resource.Id.timer);
                    

                deleteButton = (ImageView)itemView.FindViewById(Resource.Id.deleteButton);


                itemView.Click += (sender, e) => clickListener(new UserQuestionAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
                itemView.Click += (sender, e) => LongClickListener(new UserQuestionAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
                    deleteButton.Click += (sender, e) => deleteClickListener(new UserQuestionAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            }
        }



        public class UserQuestionAdapterClickEventArgs : EventArgs
        {
            public View View { get; set; }
            public int Position { get; set; }
        }
    }



