﻿using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Forms.Plugin.CardForm.Droid;
using Forms.Plugin.CardForm.Platforms.Helpers;
using Forms.Plugin.CardForm.Controls;
using Forms.Plugin.CardForm.Shared.Helpers;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Card = Forms.Plugin.CardForm.Controls.CardEntry;

[assembly: ExportRenderer(typeof(Card), typeof(CardEntryRenderer))]
namespace Forms.Plugin.CardForm.Droid
{
    public class CardEntryRenderer : EntryRenderer
    {
        Card element;
        public CardEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control.InputType = Android.Text.InputTypes.ClassNumber;
        }

        protected override async void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                base.OnElementPropertyChanged(sender, e);

                element = (Card)Element;

                var editText = Control;
                if (element.Image != null)
                {
                    switch (element.ImageAlignment)
                    {
                        case ImageAlignment.Left:
                            editText.SetCompoundDrawablesWithIntrinsicBounds(await GetDrawable(element.Image), null, null, null);
                            break;
                        case ImageAlignment.Right:
                            editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, await GetDrawable(element.Image), null);
                            break;
                    }
                }
                editText.CompoundDrawablePadding = 25;
                Control.Background.SetColorFilter(element.LineColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


        private async Task<BitmapDrawable> GetDrawable(ImageSource imageEntryImage)
        {
            Bitmap _bitmapImageconverted = await ImageHelper.GetBitmapFromImageSourceAsync(element.Image, Context);
            return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(_bitmapImageconverted, 50 * 2, 40 * 2, true));
        }
    }
}
