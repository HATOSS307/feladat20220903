using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization; 

namespace Helsinki2017
{
    class Program
    {
        static void Összpontszám(string nev)
        {
            double sum = 0;
            for (int i = 0; i < pont.donto.GetLength(1); i++)
            {
                if (pont.donto[0,i] == nev )
                {
                    sum += double.Parse(pont.donto[2, i],CultureInfo.InvariantCulture) + double.Parse(pont.donto[3, i], CultureInfo.InvariantCulture) - double.Parse(pont.donto[4, i], CultureInfo.InvariantCulture);
                }
         
            }
            for (int i = 0; i < pont.rovidprogram.GetLength(1); i++)
            {
                if (pont.rovidprogram[0, i] == nev)
                {
                    sum += double.Parse(pont.rovidprogram[2, i], CultureInfo.InvariantCulture) + double.Parse(pont.rovidprogram[3, i], CultureInfo.InvariantCulture) - double.Parse(pont.rovidprogram[4, i], CultureInfo.InvariantCulture);
                }

            }
            Console.WriteLine(sum);
        }
        static class pont {
            public static string[,] rovidprogram;
            public static string[,] donto;
        }
        static void Main(string[] args)
        {
            //1.feladat
            string[] lines =File.ReadAllLines("donto.csv");
            string[,] linesAdat = new string[5, lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] split = lines[i].Split(';');
                for (int j = 0; j < 5; j++)
                {
                    linesAdat[j,i] = split[j];
                }
            }

            string[] lines1 = System.IO.File.ReadAllLines("rovidprogram.csv");
            string[,] lines1Adat = new string[5, lines1.Length];
            for (int i = 0; i < lines1.Length; i++)
            {
                string[] split = lines1[i].Split(';');
                for (int j = 0; j < 5; j++)
                {
                    lines1Adat[j, i] = split[j];
                }
            }
            pont.donto = linesAdat;
            pont.rovidprogram = lines1Adat;

            Console.WriteLine("2.feladat");
            Console.WriteLine("\tA rövidprogramvan {0} induló volt",lines1.Length-1);
            Console.WriteLine("3.feladat");
            bool magyar = false;
            for (int i = 1; i < lines1.Length; i++)
            {
                if (lines1Adat[1,i] == "HUN")
                {
                    magyar = true;
                }
            }
            if (magyar == true)
            {
                Console.WriteLine("\tA magyar versenyő bejutott a kűrbe");
            }
            else
            {
                Console.WriteLine("\tA magyar versenyő nem bejutott a kűrbe");
            }
            //4.feladat
            
          Console.WriteLine("5. feladat");
            Console.WriteLine("\tAdja meg a versenyző nevét:");
            string nev  = Console.ReadLine();
            bool van = false;
            for (int i = 0; i < lines1Adat.GetLength(1); i++)
            {
                if (nev == lines1Adat[0,i])
                {
                    van = true;
                }
            }
            if (van == false)
            {
                Console.WriteLine("Ilyen nevű induló nem volt");
            }
            Console.WriteLine("6.feladat");
            Console.WriteLine("\tA versenyző pontszáma:");
            Összpontszám(nev);
            Console.WriteLine("7.feladat");
            //nincs
            Console.ReadKey();
        }
    }
}
