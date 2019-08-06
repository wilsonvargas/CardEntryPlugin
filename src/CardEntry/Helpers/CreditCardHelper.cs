using System;
using System.Text.RegularExpressions;

namespace Forms.Plugin.CardForm.Shared.Helpers
{
    public class CreditCardHelper
    {
        private const string cardRegex = "^(?:(?<Visa>4[0-9]{1,12}(?:[0-9]{3})?)|(?<mastercard>5[1-5] [0-9]{14})|(?<discover>6(?:011|5[0-9]{2})[0-9]{12})|(?<amex>3[47] [0-9]{13})|(?<diners>3(?:0[0-5]|[68] [0-9])[0-9]{11})|(?<jcb>(?:2131|1800|35[0-9]{3})[0-9]{11}))$";
        private const string amexRegex = @" ^ 3[47][0 - 9]{1,13}$";
        private const string masterCardRegex = @"^(?:5[1-5][0-9]{1,2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{1,2}|27[01][0-9]|2720)[0-9]{1,12}$";
        private const string visaRegex = @"^4[0-9]{1,12}(?:[0-9]{1,3})?$";
        private const string discoverRegex = @"^6(?:011|5[0-9]{2})[0-9]{1,12}$";

        public static bool IsValidNumber(string cardNum)
        {
            Regex cardTest = new Regex(cardRegex);

            CreditCardTypeType? cardType = GetCardTypeFromNumber(cardNum);

            if (IsValidNumber(cardNum, cardType))
                return true;
            else
                return false;
        }

        public static bool IsValidNumber(string cardNum, CreditCardTypeType? cardType)
        {
            Regex cardTest = new Regex(cardRegex);

            if (cardTest.Match(cardNum).Groups[cardType.ToString()].Success)
            {
                if (PassesLuhnTest(cardNum))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static CreditCardTypeType? GetCardTypeFromNumber(string cardNum)
        {
            Regex cardTest = new Regex(cardRegex);

            GroupCollection gc = cardTest.Match(cardNum).Groups;
            cardNum = cardNum.Replace(" ", "").Replace("-", "");

            if (Regex.Match(cardNum, amexRegex).Success)
            {
                return CreditCardTypeType.Amex;
            }
            else if (Regex.Match(cardNum, masterCardRegex).Success)
            {
                return CreditCardTypeType.MasterCard;
            }
            else if (Regex.Match(cardNum, visaRegex).Success)
            {
                return CreditCardTypeType.Visa;
            }
            else if (Regex.Match(cardNum, discoverRegex).Success)
            {
                return CreditCardTypeType.Discover;
            }
            else
            {
                return CreditCardTypeType.None;
            }
        }

        public static bool PassesLuhnTest(string cardNumber)
        {
            cardNumber = cardNumber.Replace("-", "").Replace(" ", "");

            int[] digits = new int[cardNumber.Length];
            for (int len = 0; len < cardNumber.Length; len++)
            {
                digits[len] = Int32.Parse(cardNumber.Substring(len, 1));
            }

            int sum = 0;
            bool alt = false;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int curDigit = digits[i];
                if (alt)
                {
                    curDigit *= 2;
                    if (curDigit > 9)
                    {
                        curDigit -= 9;
                    }
                }
                sum += curDigit;
                alt = !alt;
            }

            return sum % 10 == 0;
        }
    }
}
