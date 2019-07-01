using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using Forms.Plugin.CardEntry.Droid;
using Forms.Plugin.CardEntry.Platforms.Helpers;
using Forms.Plugin.CardEntry.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Card = Forms.Plugin.CardEntry.Shared.CardEntry;

[assembly: ExportRenderer(typeof(Card), typeof(CardEntryRenderer))]
namespace Forms.Plugin.CardEntry.Droid
{
    public class CardEntryRenderer : EntryRenderer
    {
        Card element;
        public CardEntryRenderer(Context context) : base(context)
        {

        }

        protected override async void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            element = (Card)this.Element;


            var editText = this.Control;
            if (element.Image != null)
            {
                switch (element.ImageAlignment)
                {
                    case ImageAlignment.Left:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(await GetDrawable(element.Image), null, null, null);
                        break;
                    case ImageAlignment.Right:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(null, null,await  GetDrawable(element.Image), null);
                        break;
                }
            }
            editText.CompoundDrawablePadding = 25;
            Control.Background.SetColorFilter(element.LineColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
        }

        private async Task<BitmapDrawable> GetDrawable(ImageSource imageEntryImage)
        {
            Bitmap _bitmapImageconverted = await ImageHelper.GetBitmapFromImageSourceAsync(element.Image, Context);

            return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(_bitmapImageconverted, 40 * 2, 40 * 2, true));
        }
    }
}
