using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using App.Adapters;
using System.Collections.Generic;
using Android.Views;

namespace App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        View _view;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var searchEditText = FindViewById<EditText>(Resource.Id.searchEditText);
            var searchButton = FindViewById<Button>(Resource.Id.searchButton);
            var searchListView = FindViewById<ListView>(Resource.Id.searchListView);
            var toAddActivityButton = FindViewById<Button>(Resource.Id.addButton);

            toAddActivityButton.Click += toAddActivityButton_Click;
            await ReadAsync(this);
        }

        public async Task ReadAsync(Activity context)
        {
            List<string> data = new List<string>();
            var searchListView = FindViewById<ListView>(Resource.Id.searchListView);
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            if (_view == null)
            {
                _view = context.LayoutInflater.Inflate(Resource.Layout.list_layout, null);
            }
            foreach (var file in Directory.GetFiles(path))
            {
                data.Add(Path.GetFileNameWithoutExtension(file));
                data.Add(File.ReadAllText(file));
                searchListView.Adapter = new NoteAdapter(this, data);
            }
            return;
        }

        private void toAddActivityButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AddActivity));
            StartActivity(intent);
        }
    }
}