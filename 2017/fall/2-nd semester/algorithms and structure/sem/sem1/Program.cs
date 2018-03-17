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
            /*
             * –	кодирования:  создание списка 
             * слов по содержимому словаря, заданного некоторым текстовым файлом;
             * –	вставки элемента в список:  вставки некоторой новой пары слов 
             * в словарь (предусмотреть возможность программного задания новых слов);
             * –	удаления элемента из списка: удаление элемента словаря;
             * –	В предположении, что словарь содержит большое количество слов, 
             * которые имеют одинаковый перевод в другом языке, за один проход основного списка,
             * сформировать новый список слов, которые имеют единственный перевод
             * –	Подсчета числа элементов списка, которые при переводе изменяют длину 
             * слова не более чем на единицу.
               –	Используя исходный список перевести текст на другой язык
             */
        }
    }
    public class MyDictionary
    {  
        public static int[] keyspocket = new int[1000];//чтобы не занимать много памяти я исползовал
        // int в это массиве содержится ключи к элементам по hash. без массива можно пройтись но нужно создать пустые list 
        // из-за этого я считаю хранить ключи в массиве
        public static int key = 1;// ключи элементов
        public int alikeWords = 0;//количество слов которые при переводе изменяют длину 
        //слова не более чем на единицу.
        public static MyList<MyList<string>> list = new MyList<MyList<string>>();//создаем list listov для хранение элементов
        public MyList<string> wordswithonevalue = new MyList<string>();//list  в котором лежит слова слова имеющие 1 значение
        public void Add(string Tkey, string word)
        {
            while (key + 1 > list.Count)//чтобы можно было по индексу обращатся к листу создадим k+1 listov
            {
                list.Add(new MyList<string>());
            }
            int hash = GetHash(Tkey);
            if (keyspocket[hash] == 0)//по hash кладем элемент и записываем в массив(ключей) куда положили
            {
                if (Math.Abs(Tkey.Length - word.Length) < 2) { alikeWords++; }
                keyspocket[hash] = key;
                list[key].Add(Tkey);//1-ый элемент ключ
                list[key].Add(word);//остальнае элементы значении
                key++;// чтобы не класть ещё раз сюда увеличиваем
            }
            else//а если по list не пуст d предположении, что словарь содержит большое количество слов, 
               //которые имеют одинаковый перевод в другом языке,мы проверяем ключ и добавим новое значение
            {
                var a = keyspocket[GetHash(Tkey)];
                if (Equal(Tkey, a))
                {
                    list[a].Add(word);
                }
            }
        }
        public static int GetHash(string keys)//создаем hash
        {
            var a = Math.Abs(keys.GetHashCode());
            return ((a / 321) % 1000);//если использовать BigInteger и в претположеннии колизей мало
        }//можно намного оптимизировать придумав новый hash 
        public static bool Equal(string key, int a)
        {//если по hash уже есть элементы то срывниваем ключ
            var st = list[a][0];
            if (st.Length == key.Length) { return true; }//если ключ один и тот же предположении, 
            //что словарь содержит большое количество слов, 
           //которые имеют одинаковый перевод в другом языке,мы проверяем ключ и добавим новое значение
            return false;//если ключи не совпадут используем другой hash которое даем меньше коллизий
        }
        public void Print(string Tkey)//этот метод по ключи выводит на экран ключ значение
        {
            int key = GetHash(Tkey);
            var st = list[keyspocket[key]];
            if (st.Count == 0)
            {
                Console.WriteLine("Key not found!!!");
            }
            else foreach (var item in st)
                {
                    Console.Write("{0}    ", item);
                }
            Console.WriteLine();
        }
       
        public void Collector()//собираем слова которые имеют 1 значение
        {
            foreach (var item in list)
            {
                if (item.Count == 2)
                {
                    wordswithonevalue.Add(item[0]);
                }
            }
        }
        public void Delete(string Tkey)//по ключу удаляем элумент
        {
            int a = keyspocket[GetHash(Tkey)];
            if (Math.Abs(list[a][0].Length - list[a][1].Length) < 2)
            { alikeWords--; }
            list[a] = null;
        }
        public void Translate(string text)//метод для перевода текста
        {
            string word = "";
            foreach (var item in text)//текс разбиваем по словам и ишем значении
            {
                if (Exp(item)) { word += item; }
                else { Print1(word); word = ""; }
            }

        }
        public static void Print1(string Tkey)//вывод для текста
        {
            int key = GetHash(Tkey);
            var st = list[keyspocket[key]];
            Console.Write(st[1] + "  ");
        }
        static bool Exp(char a)// вспомогательнай метод для разбиение
        {
            var b = 0;
            string exp = ",.!?()";
            foreach (var item in exp)
            {
                if (a == item) { b++; }
            }
            if (b == 0) { return true; }
            return false;
        }
    }
    public class MyList<T> : IEnumerable<T>//униветсальный лист
    {
        T[] array;
        int count = 0;
        public MyList()
        {
            array = new T[8];//создаем массив
        }
        void Enlarge()//если нужен массив по больше то увеличиваем массив и перезаписываем элементы
        {
            var old = new T[count * 2];
            for (int i = 0; i < array.Length; i++)
            {
                old[i] = array[i];
            }
            array = old;
            old = null;
        }
        public void Add(T item)//добавляем элемент 
        {
            if (count == array.Length)
                Enlarge();
            array[count] = item;
            count++;
        }
        public IEnumerator<T> GetEnumerator()//чтобы можно было пройти с foreach 
        {
            for (int i = 0; i < count; i++)
                yield return array[i];
        }
        IEnumerator IEnumerable.GetEnumerator()//
        {
            return GetEnumerator();
        }
        public int Count { get { return count; } }
        public T this[int index]//проверяем есть ли по индексу элеменс и вернем значение
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
