﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CardEntry), typeof(CardEntryRenderer))]
namespace Forms.Plugin.CardForm.iOS
{
    public class CardEntryRenderer : EntryRenderer
    {
    }
}
