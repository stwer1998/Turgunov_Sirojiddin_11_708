using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Commpressor
{
    public class LZWCompressor : ITextCommpressor
    {     
        public string Commpres(object obj)
        {
            if (obj.ToString() == "TextDocument")
            {
                return Compressor((TextDocument)obj);
            }
            else return "sa";
        }

        public string Compressor(TextDocument textdoc)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            List<int> indices = new List<int>();
            using (StreamReader reader = new StreamReader(textdoc.Path))
            {
                while (!reader.EndOfStream)
                {
                    var text = reader.ReadLine();
                    char c = '\0';
                    int index = 1;
                    int nextKey = 1;
                    if (text != null&&text!="")
                    {
                        string s = new string(text[0], 1);
                        string sc = string.Empty;

                        for (int i = 0; i < text.Length; i++)
                        {
                            if (dictionary.ContainsValue(new string(text[i], 1)))
                            {

                            }
                            else
                            {
                                dictionary.Add(nextKey, new string(text[i], 1));
                                nextKey++;
                            }
                        }

                        while (index < text.Length)
                        {
                            c = text[index++];
                            sc = s + c;

                            if (dictionary.ContainsValue(sc))
                                s = sc;

                            else
                            {
                                foreach (KeyValuePair<int, string> kvp in dictionary)
                                {
                                    if (kvp.Value == s)
                                    {
                                        indices.Add(kvp.Key);
                                        break;
                                    }
                                }

                                dictionary.Add(nextKey++, sc);
                                s = new string(c, 1);
                            }
                        }
                    }
                }
            }
            using (var textWriter = new StreamWriter(@"d:\compres\Commpressed\"+textdoc.Name+".txt"))
            {
                foreach (var key in indices)
                {
                    if (dictionary.ContainsKey(key))
                    {
                        textWriter.WriteLine(key);
                        textWriter.WriteLine(dictionary[key]);
                        dictionary.Remove(key);
                    }

                }
                textWriter.WriteLine("словарь закончился");
                foreach (var key in indices)
                {
                    textWriter.WriteLine(key);
                }
            }
            return @"d:\compres\Commpressed\" + textdoc.Name + ".txt";
        }

        public string DeCommpress(object obj)
        {
            return Decompressor((TextDocument)obj);
        }

        public string Decompressor(TextDocument text1)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            List<int> indices = new List<int>();
            using (StreamReader reader = new StreamReader(text1.Path))
            {
                while (!reader.EndOfStream)
                {
                    var text = reader.ReadLine();
                    while (true)
                    {
                        var key = Convert.ToInt32(text);
                        text = reader.ReadLine();
                        if (text == "словарь закончился")
                        { break; }
                        var value = text;
                        dictionary.Add(key, value);
                        text = reader.ReadLine();
                        if (text == "словарь закончился")
                        { break; }
                    }
                    text = reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        indices.Add(Convert.ToInt32(text));
                        text = reader.ReadLine();

                    }
                }
            }
            using (var textWriter = new StreamWriter(@"d:\compres\Decommpressed\"+text1.Name+".txt"))
            {
                string a = string.Empty;
                for (int i = 0; i < indices.Count; i++)
                {
                    a = a + dictionary[indices[i]];
                    if (a.Length > 30)
                    {
                        textWriter.WriteLine(a);
                        a = string.Empty;
                    }
                }
                textWriter.WriteLine(a);
                Console.WriteLine("ok");
            }
            return @"d:\compres\Decommpressed\" + text1.Name + ".txt";
        }
    }
}