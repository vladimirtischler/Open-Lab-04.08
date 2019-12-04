using System;
using System.Collections.Generic;

namespace Open_Lab_04._08
{
    public class StringTools
    {
        public string[] IsFourLetters(string[] strings)
        {
            List<string> word = new List<string>();
            foreach(var c in strings)
            {
                if(c.Length == 4)
                {
                    word.Add(c);
                }

            }
            return word.ToArray();
        }
    }
}
