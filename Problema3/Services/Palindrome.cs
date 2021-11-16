using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Services
{
    public class Palindrome : IPalindrome
    {
        //function that checks if is a palindrome or not 
        public string IsPalindrome(string input)
        {
            List<char> list = new();

            if (string.IsNullOrEmpty(input))
                return "Invalid Input";

            //removes and adds elements to a list based repetitions
            for (int i = 0; i < input.Length; i++)
            {
                if (list.Contains(input[i]))
                    list.Remove(input[i]);
                else
                    list.Add(input[i]);
            }

            //The string is a palimdrome if the input is pair and and the auxiliary list has no elements
            //or if the input is odd and the auxiliary list has one element
            if (input.Length % 2 == 0 
                    && list.Count == 0
                    || (input.Length % 2 == 1 && list.Count == 1))
                return "Yes";
            else
                return "No";
        }
    }
}
