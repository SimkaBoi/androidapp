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
using App.Models;

namespace App.Adapters
{
    public class NoteAdapter : BaseAdapter<NoteDetails>
    {
        List<NoteDetails> items;
        Activity context;
        public NoteAdapter(Activity context, List<NoteDetails> items) : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override NoteDetails this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
                view = context.LayoutInflater.Inflate(Resource.Layout.list_layout, null);
            view.FindViewById<TextView>(Resource.Id.noteTitle).Text = items[position].Title.ToString();
            view.FindViewById<TextView>(Resource.Id.noteDesc).Text = items[position].Desc.ToString();
            return view;
        }
    }
}