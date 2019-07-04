using Forms.Plugin.CardForm.Shared.Behaviors;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Forms.Plugin.CardForm.Controls
{
    public class CVVEntry : Entry
    {
        public CVVEntry()
        {
            HeightRequest = 50;
            Behaviors.Add(new CardBehavior() { Mask = "###" });
            Keyboard = Keyboard.Numeric;
            HorizontalOptions = LayoutOptions.FillAndExpand;
        }
    }
}
