using Forms.Plugin.CardEntry.Abstractions;
using Forms.Plugin.CardEntry.UWP;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CardEntry), typeof(CardEntryRenderer))]

namespace Forms.Plugin.CardEntry.UWP
{
    /// <summary>
    /// Interface for CardEntry
    /// </summary>
    public class CardEntryRenderer : EntryRenderer
    {
    }
}
