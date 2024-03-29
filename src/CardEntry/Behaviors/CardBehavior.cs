﻿using Forms.Plugin.CardForm.Shared.Helpers;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;

namespace Forms.Plugin.CardForm.Shared.Behaviors
{
    public class CardBehavior : Behavior<Entry>
    {
        private const string VISA = "Forms.Plugin.CardForm.Shared.Images.visa.png";
        private const string AMEX = "Forms.Plugin.CardForm.Shared.Images.amex.png";
        private const string DISCOVER = "Forms.Plugin.CardForm.Shared.Images.discover.png";
        private const string MASTERCARD = "Forms.Plugin.CardForm.Shared.Images.master.png";
        private const string NONE = "Forms.Plugin.CardForm.Shared.Images.none.png";

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
            var entry = sender as Entry;

            var cardValue = entry.Text;

            if (string.IsNullOrWhiteSpace(cardValue) || _positions == null)
                return;

            if (cardValue.Length > _mask.Length)
            {
                entry.Text = cardValue.Remove(cardValue.Length - 1);
                entry.Unfocus();
                return;
            }
            if (sender is Controls.CardEntry)
            {
                var cardEntry = sender as Controls.CardEntry;

                switch (CreditCardHelper.GetCardTypeFromNumber(cardValue))
                {                    
                    case CreditCardTypeType.Amex:
                        cardEntry.Image = ImageSource.FromResource(AMEX, typeof(CardBehavior).GetTypeInfo().Assembly);
                        break;
                    case CreditCardTypeType.Discover:
                        cardEntry.Image = ImageSource.FromResource(DISCOVER, typeof(CardBehavior).GetTypeInfo().Assembly);
                        break;
                    case CreditCardTypeType.MasterCard:
                        cardEntry.Image = ImageSource.FromResource(MASTERCARD, typeof(CardBehavior).GetTypeInfo().Assembly);
                        break;
                    case CreditCardTypeType.Visa:
                        cardEntry.Image = ImageSource.FromResource(VISA, typeof(CardBehavior).GetTypeInfo().Assembly);
                        break;
                    default:
                        cardEntry.Image = ImageSource.FromResource(NONE, typeof(CardBehavior).GetTypeInfo().Assembly);
                        break;
                }
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
