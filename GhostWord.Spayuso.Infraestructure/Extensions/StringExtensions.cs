using System;
using System.Collections.Generic;
using System.Text;

namespace GhostWord.Spayuso.Infraestructure
{
    public static class StringExtensions
    {
        public static string GetLetterFromStringPosition(this string stringToAnalyze, int position)
        {
            if(string.IsNullOrEmpty(stringToAnalyze))
            {
                throw new ArgumentNullException();
            }

            return stringToAnalyze[position].ToString();
        }
    }
}
