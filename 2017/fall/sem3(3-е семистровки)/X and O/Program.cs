using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_and_O
{
    class Program
    {
        static string A = "1"; static string B = "2"; static string C = "3"; static string D = "4"; static string E = "5"; static string F = "6";
        static string G = "7"; static string H = "8"; static string I = "9"; static string turn = "Player1"; static string Player1, Player2, Selection;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Game");
            //Console.WriteLine("What is Firts Player's name");
            Console.WriteLine("");
            Player1 = " X turn";//Convert.ToString(Console.ReadLine());
            //Console.WriteLine("What is Second Player's name");
            Player2 = " O turn";//Convert.ToString(Console.ReadLine());
            Console.Clear();
            Start();
            Console.WriteLine("Do you play again? Y/N");
            string again = Console.ReadLine();
            if (again == "Y"|| again == "y") { Console.Clear(); Start(); }
            else Console.WriteLine("Thanks to play!!!"); ;
        }
        static void Start()
        {
            Print();
            for (int i = 0; true; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(Player1 + " Your turn");
                    string Selection = Console.ReadLine();
                    if (Selection == "1") { if (A == "1") { A = "X"; } else { Console.WriteLine("Bussy"); i++; } }
                    if (Selection == "2") { if (B == "2") { B = "X"; } else { Console.WriteLine("Bussy"); i++; } }
                    if (Selection == "3") { if (C == "3") { C = "X"; } else { Console.WriteLine("Bussy"); i++; } }
                    if (Selection == "4") { if (D == "4") { D = "X"; } else { Console.WriteLine("Bussy"); i++; } }
                    if (Selection == "5") { if (E == "5") { E = "X"; } else { Console.WriteLine("Bussy"); i++; } }
                    if (Selection == "6") { if (F == "6") { F = "X"; } else { Console.WriteLine("Bussy"); i++; } }
                    if (Selection == "7") { if (G == "7") { G = "X"; } else { Console.WriteLine("Bussy"); i++; } }
                    if (Selection == "8") { if (H == "8") { H = "X"; } else { Console.WriteLine("Bussy"); i++; } }
                    if (Selection == "9") { if (I == "9") { I = "X"; } else { Console.WriteLine("Bussy"); i++; } }
                    Print();
                    if ((A == B & B == C) || (D == E & E == F) || (G == H & H == I) || (A == D & D == G) || (B == E & E == H) || (C == F & F == I) || (A == E & E == I) || (C == E & E == G))
                    { Console.WriteLine(Player1 + " You win"); break; }
                    else { continue; }
                }
                else
                {
                    Console.WriteLine(Player2 + " Your turn");
                    string Selection = Console.ReadLine();
                    if (Selection == "1") { if (A == "1") { A = "O"; } else { Console.WriteLine("Bussy"); i++; } }
                    if (Selection == "2") { if (B == "2") { B = "O"; } else { Console.WriteLine("Bussy"); i++; } }
                    if (Selection == "3") { if (C == "3") { C = "O"; } else { Console.WriteLine("Bussy"); i++; } }
                    if (Selection == "4") { if (D == "4") { D = "O"; } else { Console.WriteLine("Bussy"); i++; } }
                    if (Selection == "5") { if (E == "5") { E = "O"; } else { Console.WriteLine("Bussy"); i++; } }
                    if (Selection == "6") { if (F == "6") { F = "O"; } else { Console.WriteLine("Bussy"); i++; } }
                    if (Selection == "7") { if (G == "7") { G = "O"; } else { Console.WriteLine("Bussy"); i++; } }
                    if (Selection == "8") { if (H == "8") { H = "O"; } else { Console.WriteLine("Bussy"); i++; } }
                    if (Selection == "9") { if (I == "9") { I = "O"; } else { Console.WriteLine("Bussy"); i++; } }
                    Print();
                    if ((A == B & B == C) || (D == E & E == F) || (G == H & H == I) || (A == D & D == G) || (B == E & E == H) || (C == F & F == I) || (A == E & E == I) || (C == E & E == G))
                    { Console.WriteLine(Player2 + " You win"); break; }
                    else { continue; }
                }
            } 
        }
        static void Print()
        {
            Console.Clear();
            Console.WriteLine(" ___________");
            Console.WriteLine();
            Console.WriteLine("| "+A + " | " + B + " | " + C+" |");
            Console.WriteLine("| "+D + " | " + E + " | " + F+" |");
            Console.WriteLine("| "+G + " | " + H + " | " + I+" |");
            Console.WriteLine(" ___________");
            Console.WriteLine("");
        }
    }
}

