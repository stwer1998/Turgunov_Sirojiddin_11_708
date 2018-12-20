using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace Commpressor
{
    public class TextDocument
    {
        public override string ToString()
        {
            return "TextDocument";
        }
        public string Name { get; private set; }
        //public Encoding Unicod { get; private set; }
        public string Path { get; private set; }
        //public int LineLength { get; private set; }
        public TextDocument(string path)
        {
            Path = path;
            var a = path.Split('\\');
            var b = a[a.Length-1].Split('.');
            for (int i = 0; i < b.Length-1; i++)
            {
                Name += b[i];
            }
        }
    }
}