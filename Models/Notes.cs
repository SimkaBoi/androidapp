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

namespace App.Models
{
    public partial class Notes
    {
        public long Count { get; set; }
        public object Next { get; set; }
        public object Previous { get; set; }
        public List<NoteDetails> Results { get; set; }
    }

    public partial class NoteDetails
    {
        public string Title { get; set; }
        public string Desc { get; set; }
    }
}