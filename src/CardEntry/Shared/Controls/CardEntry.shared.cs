﻿using Forms.Plugin.CardForm.Shared.Behaviors;
using Forms.Plugin.CardForm.Shared.Helpers;
using System.Reflection;
using Xamarin.Forms;

namespace Forms.Plugin.CardForm.Controls
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

        private static ImageSource defaultSource = ImageSource.FromResource("Forms.Plugin.CardForm.Shared.Images.none.png", typeof(CardEntry).GetTypeInfo().Assembly);

        public static readonly BindableProperty ImageProperty =
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
