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
using App.Models;
using Newtonsoft.Json;

namespace App.Activities
{
    [Activity(Label = "NoteDetailActivity")]
    public class NoteDetailActivity : Activity
    {
       
        public NoteDetails _noteDetails;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.note_detail_layout);
           


            var title = FindViewById<TextView>(Resource.Id.title);
            var desc = FindViewById<TextView>(Resource.Id.desc);
            var delete = FindViewById<Button>(Resource.Id.deleteButton);
            var edit = FindViewById<Button>(Resource.Id.EditButton);
            var date = FindViewById<TextView>(Resource.Id.Date);
            _noteDetails = JsonConvert.DeserializeObject<Models.NoteDetails>(Intent.GetStringExtra("noteDetails"));
            title.Text = _noteDetails.Title;
            desc.Text = _noteDetails.Desc;
            var oldpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + $"/{_noteDetails.Title}.txt";
            date.Text = File.GetCreationTime(oldpath).ToString();
            edit.Click +=  delegate
            {
               
                Edit(title.Text, desc.Text,oldpath);
            };

            delete.Click +=  delegate
            {
                Delete();
            };
            
        }
        public  void Edit(string title, string desc,string oldpath)
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), title + ".txt");
            File.WriteAllText(path, desc);
           File.Move(oldpath, System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + $"/{title}.txt");
           var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
        public void Delete()
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + $"/{_noteDetails.Title}.txt";
            File.Delete(path);
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
       


        //private void toDeleteButton_Click(object sender, EventArgs e)
        //{
        //    var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + $"/{_noteDetails.Title}.txt";
        //    File.Delete(path);
        //    var intent = new Intent(this, typeof(MainActivity));
        //    StartActivity(intent);
        //}
    }
}