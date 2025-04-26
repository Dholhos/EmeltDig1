using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace utemez.Models
{
    class TaborKezelo
    {
        List<Tabor> tabor = new();
        internal List<Tabor> Tabor { get => tabor; }

        public void LoadFromTXT(string path)
        {
            tabor = File.ReadAllLines(path).Select(x => new Tabor(x)).ToList();
        }

        public int OsszesTabor()
        {
            int darab = 0;
            foreach (var item in tabor)
            {
                darab++;
            }
            return darab;
        }

        public string UtolsoTabor()
        {
            int nap = 0;
            int honap = 0;
            string utolso = "";

            foreach (var item in tabor)
            {
                if (item.VegHonap > honap)
                {
                    honap = item.VegHonap;
                }
                if (item.VegNap > nap)
                {
                    nap = item.VegNap;
                }
                if (item.VegNap == nap && item.VegHonap == honap)
                {
                   utolso = item.Temakor.ToString();
                }

            }
            return utolso;
        }
        public string ElsoTabor()
        {
            int nap = 10;
            int honap = 10;
            string elso = "";

            foreach (var item in tabor)
            {
                if (item.KezdetHonap > honap)
                {
                    honap = item.KezdetHonap;
                }
                if (item.KezdetNap > nap)
                {
                    nap = item.KezdetNap;
                }
                if (item.KezdetNap == nap && item.KezdetHonap == honap)
                {
                    elso = item.Temakor.ToString();
                }
            }
            return elso;
        }

        public void ZeneiTaborok()
        {
            bool voltE = false;
            foreach (var item in tabor)
            {
                if (item.Temakor == "zenei")
                {
                    Console.WriteLine($"Zenei tábor kezdődik {item.KezdetHonap}. hó {item.KezdetNap}. napján");
                    voltE = true;
                }
            }
                if(!voltE)
                {
                    Console.WriteLine("Nem volt zenei tábor.”");
                }
        }

        public void LegtobenJelentkezdtek()
        {
            int darabSzam = 0;
            foreach (var item in tabor)
            {
                if (item.Kod.Length > darabSzam)
                {
                    darabSzam = item.Kod.Length;
                }
            }
            foreach (var item in tabor)
            {
                if (item.Kod.Length == darabSzam)
                {
                    Console.WriteLine($"Legnépszerűbbek:\n{item.VegHonap} {item.KezdetNap}");
                }
            }
        }

        public int Sorszam(int honap, int nap)
        {
            int datum = 0;
            if (honap == 7)
            {
                datum += 30 + nap;
            }
            else if(honap == 8)
            {
                datum += 60 + nap;
            }
            return datum;
        }

        public void Kiiratasa()
        {
            Console.WriteLine("hó:");
            var honap = Console.ReadLine();
            Console.WriteLine("nap:");
            var nap = Console.ReadLine();
            int darab = 0;
            int MegadottNap = Sorszam(int.Parse(honap), int.Parse(nap));
            foreach (var item in tabor)
            {
                int aktualisNapKezd = Sorszam(item.KezdetHonap, item.KezdetNap);
                int aktualisNapVeg = Sorszam(item.VegHonap, item.VegNap);

                if (MegadottNap < aktualisNapVeg && MegadottNap >aktualisNapKezd)
                {
                    darab++;
                }
            }
            Console.WriteLine($"Ekkor éppen {darab} tábor tart");
        }

        public void Elmentes()
        {
            Console.WriteLine("Adjon meg egy tanulókódot: ");
            Console.ReadLine();
            List<string> lista = new();
            foreach (var item in tabor)
            {
                if (item.Kod.Contains(tanuloKod))
                {
                    //6.18-6.29. evezos
                    lista.Add($"{item.KezdetHonap}.{item.KezdetNap}-{item.KezdetHonap}.{item.KezdetNap}. {item.Temakor}");

                }
            }
            File.WriteAllLines("egytanulo.txt", lista);
        }
    }
}
