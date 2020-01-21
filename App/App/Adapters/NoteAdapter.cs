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
    public class NoteAdapter : BaseAdapter<string>
    {
        List<string> _items;
        Activity _context;
        public int _pos;

        public NoteAdapter(Activity context, List<string> items) : base()
        {
            this._context = context;
            this._items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override string this[int position]
        {
            get { return _items[position]; }
        }
        public override int Count
        {
            get { return _items.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item1 = "";
            var item2 = "";
            if (_pos == 0)
            {
                item1 = _items[_pos];
                _pos++;
                item2 = _items[_pos];
            } else if (_pos < _items.Count - 1)
            {
                _pos++;
                item1 = _items[_pos];
                _pos++;
                item2 = _items[_pos];
            }

            View view = convertView;
            if (view == null)
                view = _context.LayoutInflater.Inflate(Resource.Layout.list_layout, null);
            view.FindViewById<TextView>(Resource.Id.noteTitle).Text = item1.ToString();
            view.FindViewById<TextView>(Resource.Id.noteDesc).Text = item2.ToString();

            return view;
        }
    }
}