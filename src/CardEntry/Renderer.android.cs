using Android.Content;
using Forms.Plugin.CardEntry.Abstractions;
using Forms.Plugin.CardEntry.Droid;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CardEntry), typeof(CardEntryRenderer))]
namespace Forms.Plugin.CardEntry.Droid
{
    public class CardEntryRenderer : EntryRenderer
    {
        public CardEntryRenderer(Context context) : base(context)
        {

        }
    }
}
