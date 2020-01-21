using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App.Activities
{
    [Activity(Label = "AddActivity")]
    public class AddActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.add_layout);

            var titleField = FindViewById<EditText>(Resource.Id.titleText);
            var descField = FindViewById<EditText>(Resource.Id.descText);
            var saveButton = FindViewById<Button>(Resource.Id.saveButton);

            saveButton.Click += async delegate
            {
                var title = titleField.Text;
                var desc = descField.Text;

                await SaveAsync(title, desc);
            };
        }

        public async Task SaveAsync(string title, string desc)
        {
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), title + ".txt");
            using (var writer = File.CreateText(backingFile))
            {
                await writer.WriteLineAsync(desc.ToString());
            }
        }
    }
}