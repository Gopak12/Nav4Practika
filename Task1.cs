using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    public class Task1
    {
        public static bool CheckAnagram(String word1, String word2)
        {
            if (ReferenceEquals(word1, null)) return false;
            if (ReferenceEquals(word2, null)) return false;
            if (ReferenceEquals(word1, word2)) return true;

            if (word1.Length != word2.Length) return false;


            List<Char> letters = new List<char>();

            for (int i = 0; i < word1.Length; i++)
            {
                if (letters.Contains(word1[i]))
                {
                    letters.Remove(word1[i]);
                }
                else
                {
                    letters.Add(word1[i]);
                }

                if (letters.Contains(word2[i]))
                {
                    letters.Remove(word2[i]);
                }
                else
                {
                    letters.Add(word2[i]);
                }
            }

            return letters.Count == 0;
        }
        
    }
}