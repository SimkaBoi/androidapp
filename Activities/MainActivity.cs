using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;
using App.Activities;
using App.Models;
using System.Collections.Generic;
using Android.Views;
using System.IO;
using App.Adapters;

namespace App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var toAddActivityButton = FindViewById<Button>(Resource.Id.addButton);

            toAddActivityButton.Click += toAddActivityButton_Click;
        }

        protected override void OnStart()
        {
            base.OnStart();

            var notes = new List<NoteDetails>();
            var noteListView = FindViewById<ListView>(Resource.Id.noteListView);

            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            foreach (var file in Directory.GetFiles(path))
            {
                notes.Add(new NoteDetails
                {
                    Title = Path.GetFileNameWithoutExtension(file).ToString(),
                    Desc = File.ReadAllText(file).ToString()
                });
                noteListView.Adapter = new NoteAdapter(this, notes);
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