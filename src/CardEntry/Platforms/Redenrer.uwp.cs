﻿using Forms.Plugin.CardForm;
using Forms.Plugin.CardForm.UWP;
using System;
using System.Collections.Generic;
using System.Text;
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
