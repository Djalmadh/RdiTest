using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Services
{
    public class NumberToWordsConverter : INumberToWordsConverter
    {
        //Mapping used to convert numbers
        private static readonly string[] PortugueseUnitsMap = { "zero", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
        private static readonly string[] PortugueseTensMap = { "zero", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
        private static readonly string[] PortugueseHundredsMap = { "zero", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };

        //Function to convert numbers into currency
        public string ConvertAmount2Words(int m, int n)
        {
            string reais = ConvertNumberToWords(m);
            string centavos = ConvertNumberToWords(n);
            string result = string.Empty;

            if (IsInvalid(m, n))
                return "Invalid Number";

            if(!string.IsNullOrEmpty(reais))
            {
                result = string.Format("{0} {1}", reais, (m > 1 || m==0) ? "reais" : "real");
            }
            if(!string.IsNullOrEmpty(centavos))
            {
                if (!string.IsNullOrEmpty(result))
                    result += " e ";
                result += string.Format("{0} {1}", centavos, (n > 1 || n==0) ? "centavos" : "centavo");
            }

            return result;
        }

        //Function to validate the input
        private static bool IsInvalid(int m, int n) =>
            (m > 1000000000 || n > 100 || n < 0 || m < 0);
        
        //Function to convert numbers in words
        private static string ConvertNumberToWords(int number)
        {
            var parts = new List<string>();

            //Added zero due to it being part of the interval that the parameters could receive
            //This check sould be removed in case the expected output of a zero input is empty
            if (number == 0)
                parts.Add(PortugueseUnitsMap[number]);

            if ((number / 1000000000) > 0)
            {
                parts.Add(number / 1000000000 >= 2
                    ? string.Format("{0} bilhões", ConvertNumberToWords(number / 1000000000))
                    : string.Format("{0} bilhão", ConvertNumberToWords(number / 1000000000)));

                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                parts.Add(number / 1000000 >= 2
                    ? string.Format("{0} milhões", ConvertNumberToWords(number / 1000000))
                    : string.Format("{0} milhão", ConvertNumberToWords(number / 1000000)));

                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                parts.Add(number / 1000 == 1 ? "mil" : string.Format("{0} mil", ConvertNumberToWords(number / 1000)));
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                if (number == 100)
                {
                    parts.Add(parts.Count > 0 ? "e cem" : "cem");
                }
                else
                {
                    parts.Add(PortugueseHundredsMap[(number / 100)]);
                }

                number %= 100;
            }

            if (number > 0)
            {
                if (parts.Count != 0)
                {
                    parts.Add("e");
                }

                if (number < 20)
                {
                    parts.Add(PortugueseUnitsMap[number]);
                }
                else
                {
                    var lastPart = PortugueseTensMap[number / 10];
                    if ((number % 10) > 0)
                    {
                        lastPart += string.Format(" e {0}", PortugueseUnitsMap[number % 10]);
                    }

                    parts.Add(lastPart);
                }
            }

            return string.Join(" ", parts.ToArray());
        }
    }
}
