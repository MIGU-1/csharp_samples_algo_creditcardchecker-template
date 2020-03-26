using System;

namespace CreditCardChecker
{
    public class CreditCardChecker
    {
        /// <summary>
        /// Diese Methode überprüft eine Kreditkartenummer, ob diese gültig ist.
        /// Regeln entsprechend der Angabe.
        /// </summary>
        public static bool IsCreditCardValid(string creditCardNumber)
        {
            if (creditCardNumber.Length == 16)
            {
                int sum1 = 0;
                int sum2 = 0;
                int diff = 0;

                for (int i = 0; i < creditCardNumber.Length - 1; i++)
                {
                    if (Char.IsDigit(creditCardNumber[i]))
                    {
                        int nr = ConvertToInt(creditCardNumber[i]);

                        if (i % 2 == 0)
                        {
                            nr *= 2;

                            if (nr >= 10)
                            {
                                sum1 += CalculateDigitSum(nr);
                            }
                            else
                            {
                                sum1 += nr;
                            }
                        }
                        else
                        {
                            sum2 += nr;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                if (sum1 > 0 && sum2 > 0)
                {

                    sum1 = CalculateCheckDigit(sum1, sum2);
                    diff = 10 - (sum1 % 10);

                    return (diff == ConvertToInt(creditCardNumber[creditCardNumber.Length - 1]));
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Berechnet aus der Summe der geraden Stellen (bereits verdoppelt) und
        /// der Summe der ungeraden Stellen die Checkziffer.
        /// </summary>
        private static int CalculateCheckDigit(int oddSum, int evenSum) => oddSum + evenSum;

        /// <summary>
        /// Berechnet die Ziffernsumme einer Zahl.
        /// </summary>
        private static int CalculateDigitSum(int nr)
        {
            int sum = 0;

            while (nr > 0)
            {
                sum += nr % 10;
                nr /= 10;
            }

            return sum;
        }

        private static int ConvertToInt(char ch) => Convert.ToInt32(ch - 48);
    }
}
