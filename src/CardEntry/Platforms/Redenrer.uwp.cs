using Forms.Plugin.CardForm.Controls;
using Forms.Plugin.CardForm.UWP;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CardEntry), typeof(CardEntryRenderer))]

namespace Forms.Plugin.CardForm.UWP
{
    /// <summary>
    /// Interface for CardEntry
    /// </summary>
    public class CardEntryRenderer : EntryRenderer
    {
    }
}
