using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = "aaa";
            //var b = "aab";
            //var c = "aaaa";
            //var s = a.GetHashCode();
            //var s1 = (s / 321) % 1000;
            //var s2 = c.GetHashCode();

            //Console.WriteLine((s));
            //Console.WriteLine(Convert.ToInt32("1"));
            //Console.WriteLine(Math.Abs(2-3));
            //var a = "many";
            //var b = a.GetHashCode();
            //Console.WriteLine(Math.Abs((b / 321) % 1000));
            //var c = new int[1000];
            //c[(Math.Abs((b / 321) % 1000))] = 1;
            //var dict = new MyDictionary();
            //dict.Add("many", "kop");
            //dict.Add("many1", "kop123232");
            //dict.Add("many", "kop2211");
            //dict.Add("many3", "kop3");
            //dict.Print("many");
            //dict.Print("many1");
            //dict.Print("many3");
            //Console.WriteLine(dict.AlikeWords);
            var list = new MyList<MyList<string>>();
            

        }
    }
    public class MyDictionary
    {
        public  int AlikeWords = 0;
        public  void Add(string Tkey,string word)
        {
            var list = new MyList<MyList<string>>();
            var key = 1;
            var keyspocket = new int[1000];
            var hash = Math.Abs(Tkey.GetHashCode());
            if (Convert.ToInt32(word) == 0) { list[keyspocket[(hash / 321) % 1000]] = null; }
            else if (Convert.ToInt32(word) == 1)
            {
                foreach (var item in list[keyspocket[(hash / 321) % 1000]])
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                if ((keyspocket[((hash / 321) % 1000)]) == 0)
                {
                    if (Math.Abs(Tkey.Length - word.Length) < 2) { AlikeWords++; }
                    keyspocket[(hash / 321) % 1000] = key;
                    list[key].Add(Tkey);
                    list[key].Add(word);
                    key++;
                }
                else
                {
                    list[key].Add(word);
                }
            }
        }
        public  void Print(string Tkey)
        {
            Add(Tkey, "1");
        }
        public  void Delete(string Tkey)
        {
            Add(Tkey, "0");
        }
        
    }
    public class MyList<T>:IEnumerable<T>
    {
        T[] array;
        int count = 0;
        public MyList()
        {
            array = new T[8];
        }
        void Enlarge()
        {
            var old = new T[count*2];
            for (int i = 0; i < array.Length; i++)
            {
                old[i] = array[i];
            }
            array = old;
            old = null;
        }
        public void Add(T item)
        {
            if (count == array.Length)
                Enlarge();
            array[count] = item;
            count++;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return array [i];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public int Count { get { return count; } }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count) throw new IndexOutOfRangeException();
                return array[index];
            }
            set
            {
                if (index < 0 || index >= count) throw new IndexOutOfRangeException();
                array[index] = value;
            }
        }
    }
}
