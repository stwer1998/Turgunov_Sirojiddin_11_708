using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            //Тесты
            var a = new Graph();
            a.MakeGraph(4);
            a.Connect(0, 1, 1);
            a.Connect(0, 2, 2);
            a.Connect(0, 3, 6);
            a.Connect(1, 3, 4);
            a.Connect(2, 3, 2);
            a.Print();
            var c=a.Dijkstra(0);
            foreach (var item in c)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(  );
            Console.WriteLine();
            var b = new Graph();
            b.MakeGraph(4);
            b.Connect(0, 1, 1);
            b.Connect(0, 2, 2);
            b.Connect(0, 3, 6);
            b.Connect(1, 3, 4);
            b.Connect(2, 3, 2);
            b.Print();
            Console.WriteLine();
            Console.WriteLine();
            var d = b.FordBellman(0);
            foreach (var item in d)
            {
                Console.WriteLine(item);
            }
        }
    }
    public class Graph//класс графа
    {
        static int[][] graph;//сохраним граф в виде масрицы
        static List<Tuple<int, int, int>> Edges = new List<Tuple<int, int, int>>();
        //лист ребер где item1  это начало ребра item2 конец ребра  item3 вес ребра
        //здесь создаем массив и по умолчанию заполним большим числом
        public void MakeGraph(int numberNode)
        {
            graph = new int[numberNode][];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new int[numberNode];
                for (int j = 0; j < graph.Length; j++)
                {
                    if (i == j) { graph[i][j] = 0; }
                    else
                        graph[i][j] = 100;
                }
            }
        }
        public void Connect(int v1, int v2, int weight)//соединяем две вершины
        {
            graph[v1][v2] = weight;
            Edges.Add(Tuple.Create(v1, v2, weight));//
            //заполняем лист ребер для BelmanaForda
        }
        #region
        public void Print()//просто для вывода на консоль
        {
            for (int i = 0; i < graph.Length; i++)
            {
                for (int j = 0; j < graph.Length; j++)
                {
                    Console.Write(graph[i][j] + "  ");
                }
                Console.WriteLine();
            }
        }
        public int[] Dijkstra(int start)
        {
            var result = new int[graph.Length];
            for (int i = 0; i < graph.Length; i++)
            {
                //  берем вершину и посешаем все вершины соединеным с ним
                var weight = graph[start][i];
                for (int j = 0; j < graph.Length; j++)
                {
                    if (graph[i][j] + weight < graph[start][j])
                    {
                        graph[start][j] = graph[i][j] + weight;//если через какуюта вершину путь короче то обновим
                    }
                }
            }
            for (int n = 0; n < graph.Length; n++)
            {
                result[n] = graph[start][n];
            }
            return result;
        }
        #endregion
        public int[] FordBellman(int start)
        {
            var result = new int[graph.Length];
            for (int i = 0; i < graph.Length; i++)
            {
                result[i] = graph[start][i];//
            }
            //
            //берем начало ребра если до вершины есть путь
            //если путь короче остальных то обновляем
            //
            for (int i = 0; i < graph.Length - 1; i++)
            {
                for (int j = 0; j < Edges.Count; j++)
                {
                    if (result[Edges[j].Item1] != -1 && result[Edges[j].Item2] > result[Edges[j].Item1] + Edges[j].Item3)
                    { result[Edges[j].Item2] = result[Edges[j].Item1] + Edges[j].Item3; }
                }
            }
            return result;
        }
    }

}
