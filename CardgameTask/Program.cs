using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardgameTask
{
    enum Mast { Clubs, Diamonds, Hearts, Spades }
    enum Kaart { two, three, four, five, six, seven, eight, nine, ten, Jack, Queen, King, Ace }
    //enum Tunnus {suur = 1, punane = 2, puust=4, kolisev=8  }

    class Program
    {
        static void Main(string[] args)
        {
            //Mast m = Mast.Artu;
            ////m++;
            //Console.WriteLine((int)m);

            //Kaart k1 = Kaart.kymme;
            //k1++;
            //Console.WriteLine(k1);

            //Tunnus t = (Tunnus)7;
            //Console.WriteLine(t);

            //Random r = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine((Kaart)(r.Next() % 13));
            //}

            //int[] miski = Enumerable.Range(0, 52).ToArray();

            //String[] mastinimed = { "risti"};
            //String [] kaardinimed = { "kaks"};

            var Kaardid = Enumerable.Range(0, 52).ToList();

            foreach (var k in Kaardid)
                Console.WriteLine($"Card\t{k}\t is {(Mast)(k % 4)} {(Kaart)(k % 13)}");

            Console.WriteLine("\nwith no shuffle every player would have:\n");
            Console.WriteLine("Bob\t\t\tGene\t\t\tTina\t\t\tLouise\n");

            foreach (var k in Kaardid)
                Console.Write($"{ (Mast)((k / 13) % 4)} { (Kaart)(k % 13)}\t\t" + (k % 4 == 3 ? "\n" : ""));

            Random r = new Random();
            var Segatud = new List<int>();

            while (Kaardid.Count > 0)
            {
                int mitmes = r.Next() % Kaardid.Count;
                Segatud.Add(Kaardid[mitmes]);
                Kaardid.RemoveAt(mitmes);
            }


            Kaardid = Segatud;
            Console.WriteLine();
            Console.WriteLine("after shuffle they would have:");
            Console.WriteLine();
            Console.WriteLine("Bob\t\t\tGene\t\t\tTina\t\t\tLouise");
            Console.WriteLine(new string(' ', 100));
            for (int i = 0; i < Kaardid.Count; i++)
            {
                int k = Kaardid[i];
                Console.Write($"{ (Mast)((k / 13) % 4)} { (Kaart)(k % 13)}\t\t" + (i % 4 == 3 ? "\n" : ""));
            }

            SortedSet<int>[] Pakid = { new SortedSet<int>(), new SortedSet<int>(), new SortedSet<int>(), new SortedSet<int>() };
            for (int i = 0; i < 13; i++)
                for (int j = 0; j < 4; j++)
                {
                    int mitmes = r.Next() % Kaardid.Count;
                    Pakid[j].Add(Kaardid[mitmes]);
                    Kaardid.RemoveAt(mitmes);
                }
            Console.WriteLine(new string('-', 100));
            Console.WriteLine("Sorted packs of players would look like this\n");
            for (int i = 12; i >= 0; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    int k = Pakid[j].ToArray()[i];
                    Console.Write($"{ (Mast)((k / 13) % 4)} { (Kaart)(k % 13)}\t\t");
                }
                Console.WriteLine();
            }


            //proovi iga mängija kaardid kirjutada TUGEVUSE järjekorras MASTIDE kaupa   
        }
    }
}