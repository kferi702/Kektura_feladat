using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kektura
{
    class Program
    {
        public static int kezdo_magassag;
        public static List<Szakaszok> szakasz = new List<Szakaszok>();
        public static void beolv(string f_neve)
        {
            FileStream f = new FileStream(@f_neve, FileMode.Open);
            StreamReader r = new StreamReader(f, Encoding.Default);
            kezdo_magassag = int.Parse(r.ReadLine());
            while (!r.EndOfStream)
            {
                string[] t = r.ReadLine().Split(';');
                szakasz.Add(new Szakaszok(t[0], t[1], t[2], t[3], t[4], t[5]));
            }
        }
        public static void f5()
        {
            string[] t = { szakasz.ElementAt(0).indul, szakasz.ElementAt(0).vege, szakasz.ElementAt(0).hossz.ToString() };
            foreach (Szakaszok sz in szakasz)
                if (int.Parse(t[2]) > sz.hossz)
                {
                    t[0] = sz.indul;
                    t[1] = sz.vege;
                    t[2] = sz.hossz.ToString();
                }
            Console.WriteLine("5. feladat: A legrövidebb szakasz adatai: \n\tKezdete: " + t[0] + "\n\tVége: " + t[1] + "\n\tTávolság: " + t[2] + " km");
        }
        public static bool HiayosNev(Szakaszok sz)
        {
            if (sz.pecset == "i" && !sz.vege.Contains("pecsetelohely"))
                return true;
            return false;
        }
        public static void f7()
        {
            Console.WriteLine("7. feladat: Hiányos állomásnevek: ");
            string hiany = "";
            foreach (Szakaszok sz in szakasz)
                if (HiayosNev(sz))
                    hiany += "\t" + sz.vege + "\n";
            if (hiany != "")
                Console.WriteLine(hiany);
            else
                Console.WriteLine("Nincs Hiányos állomásnév");

        }
        public static void f8()
        {
            int max = kezdo_magassag;
            int magassag = max;
            string maxPont = "";
            foreach (Szakaszok sz in szakasz)
            {
                magassag += sz.emel - sz.lejt;
                if ((magassag) > max)
                {
                    max =magassag;
                    maxPont = sz.vege;
                }
            }
            Console.WriteLine("8. feladat: A túra legmagasabban fekvő végpontja:\n\tA végpont neve: " + maxPont + "\n\tA végpont tengerszint feletti magassága: " + max + " m");
        }
        public static void f9()
        {
            FileStream f = new FileStream("kektura2.csv", FileMode.Create);
            StreamWriter w = new StreamWriter(f, Encoding.Default);
            w.WriteLine(kezdo_magassag);
            foreach(Szakaszok sz in szakasz)
            {
                if (HiayosNev(sz))
                    w.WriteLine(sz.indul + ";" + sz.vege +", pecsetelohely;" + sz.hossz + ";" + sz.emel + ";" + sz.lejt + ";" + sz.pecset);
                else
                    w.WriteLine(sz.ToString());
            }
            w.Close();
            f.Close();
        }
        static void Main(string[] args)
        {
            beolv("kektura.csv");
            //foreach (Szakaszok s in szakasz) Console.WriteLine(s.ToString());
            Console.WriteLine("3. feladat: Szakaszok száma: " + szakasz.Count + " db");
            Console.WriteLine("4. feladat: " + szakasz.Sum(x => x.hossz) + " km");
            f5();
            f7();
            f8();
            f9();
            Console.ReadKey();
        }
    }
}
