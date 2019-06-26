﻿using Forms.Plugin.CardEntry.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Forms.Plugin.CardEntry.Shared.Behaviors
{
    public class CardBehavior : Behavior<Entry>
    {
        private string _mask = "";
        public string Mask
        {
            get => _mask;
            set
            {
                _mask = value;
                SetPositions();
            }
        }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        IDictionary<int, char> _positions;

        void SetPositions()
        {
            if (string.IsNullOrEmpty(Mask))
            {
                _positions = null;
                return;
            }

            var list = new Dictionary<int, char>();
            for (var i = 0; i < Mask.Length; i++)
                if (Mask[i] != '#')
                    list.Add(i, Mask[i]);

            _positions = list;
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = sender as Shared.CardEntry;

            var cardValue = entry.Text;

            if (string.IsNullOrWhiteSpace(cardValue) || _positions == null)
                return;

            if (cardValue.Length > _mask.Length)
            {
                //entry.Text = text.Remove(text.Length - 1);
                entry.Unfocus();
                return;
            }

            switch (CreditCardHelper.GetCardTypeFromNumber(cardValue))
            {
                case CreditCardTypeType.Amex:
                    entry.Image = "amex.png";
                    break;
                case CreditCardTypeType.Discover:
                    entry.Image = "discover.png";
                    break;
                case CreditCardTypeType.MasterCard:
                    entry.Image = "master.png";
                    break;
                case CreditCardTypeType.Visa:
                    entry.Image = "visa.png";
                    break;
                default:
                    entry.Image = "none.png";
                    break;
            }
            

            foreach (var position in _positions)
                if (cardValue.Length >= position.Key + 1)
                {
                    var value = position.Value.ToString();
                    if (cardValue.Substring(position.Key, 1) != value)
                        cardValue = cardValue.Insert(position.Key, value);
                }

            if (entry.Text != cardValue)
                entry.Text = cardValue;
        }
    }
}