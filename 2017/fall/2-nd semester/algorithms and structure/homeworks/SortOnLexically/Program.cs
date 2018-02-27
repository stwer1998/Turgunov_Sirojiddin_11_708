using System;
using System.Collections.Generic;

namespace SortOnLexically
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
    public class SortOnLexically
    {
        public static int numberOfWords = 0;
        public static int maximumIndex = 0;
        public static List<string>[] pocke = new List<string>[27];
        public static List<string> words = new List<string>();    
        public static void Sort()
        {
            Max();
            for (int i = maximumIndex - 1; i > -1; i--)
            {
                pocke = new List<string>[27];
                for (int n = 0; n < pocke.Length; n++)
                {
                    pocke[n] = new List<string>();
                }
                for (int j = 0; j < numberOfWords; j++)
                {
                    pocke[(Convert.ToInt32((words[j][i])) - 96)].Add(words[j]);

                }
                CastPocketToList(pocke);
            }
        }
        static void CastPocketToList(List<string>[] pocket)
        {
            words = new List<string>();
            for (int i = 0; i < pocket.Length; i++)
            {
                words.AddRange(pocket[i]);
            }
        }
        static void Max()
        {
            maximumIndex = 0;
            foreach (var word in words)
            {
                if (word.Length > maximumIndex) { maximumIndex = word.Length; }
                else continue;
            }
        }
    }
}
