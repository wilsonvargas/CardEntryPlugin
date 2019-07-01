using Forms.Plugin.CardEntry.Shared.Behaviors;
using Forms.Plugin.CardEntry.Shared.Helpers;
using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace Forms.Plugin.CardEntry.Shared
{
    public class CardEntry : Entry
    {
        public CardEntry()
        {
            HeightRequest = 50;
            Behaviors.Add(new CardBehavior() { Mask = "#### #### #### ####" });
            Keyboard = Keyboard.Numeric;
            HorizontalOptions = LayoutOptions.FillAndExpand;
        }

        private static ImageSource defaultSource = ImageSource.FromResource("Forms.Plugin.CardEntry.Shared.Images.none.png", typeof(CardEntry).GetTypeInfo().Assembly);

        private static readonly BindableProperty ImageProperty =
            BindableProperty.Create(nameof(Image), typeof(ImageSource), typeof(CardEntry), defaultSource);

        public static readonly BindableProperty LineColorProperty =
            BindableProperty.Create(nameof(LineColor), typeof(Color), typeof(CardEntry), Color.White);

        public static readonly BindableProperty ImageAlignmentProperty =
            BindableProperty.Create(nameof(ImageAlignment), typeof(ImageAlignment), typeof(CardEntry), ImageAlignment.Left);

        public Color LineColor
        {
            get { return (Color)GetValue(LineColorProperty); }
            set { SetValue(LineColorProperty, value); }
        }       

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public ImageAlignment ImageAlignment
        {
            get { return (ImageAlignment)GetValue(ImageAlignmentProperty); }
            set { SetValue(ImageAlignmentProperty, value); }
        }
    }
}
