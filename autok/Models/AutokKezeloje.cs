using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace autok.Models
{
    class AutokKezeloje
    {
        List<Autok> kezelo = new();
        public List<Autok> Kezelo { get => kezelo; set => kezelo = value; }

        public void LoadFromTXT(string path)
        {
            kezelo = File.ReadAllLines(path).Select(x => new Autok(x)).ToList();
        }
        public void Utolso()
        {
            var utolso = kezelo.Last();
            Console.WriteLine($"2. feladat:\nAz utolsó jeladás időpontja {utolso.Ora}:{utolso.Perc}, a jármű rendszáma {utolso.Rendszam}");
        }
        public void Elso()
        {
            List<string> jelzesek = new();
            var elso = kezelo.First();
            foreach (var item in kezelo)
            {
                if (item.Rendszam == elso.Rendszam)
                {
                    jelzesek.Add($"{item.Ora}:{item.Perc}");
                }
            }
            Console.WriteLine($"3.feladat\nAz első jármű: {elso.Rendszam}\nJeladásainak időpontjai:");
            foreach (var item in jelzesek)
            {
                Console.Write($" {item} ");
            }
            Console.WriteLine("\n4.feladat");
        }
        public void Jeladasok()
        {
            //Kérem, adja meg az órát: 6
            //Kérem, adja meg a percet: 54
            //A jeladások száma: 3
            Console.WriteLine("Kérem, adja meg az órát: ");
            var ora = Console.ReadLine();
            Console.WriteLine("Kérem, adja meg az percet: ");
            var perc =  Console.ReadLine();
            int jeladasokSzama = 0;
            foreach (var item in kezelo)
            {
                if (item.Ora == int.Parse(ora) && item.Perc == int.Parse(perc))
                {
                    jeladasokSzama++;
                }
            }
             Console.WriteLine($"A jeladások száma: {jeladasokSzama}");
        }
        public void MaxSEbesseg()
        {
            List<string> gyorsAutok = new();
            int legnagyobbSebesseg = 0;
            foreach (var item in kezelo)
            {
                if (item.Sebesseg > legnagyobbSebesseg)
                {
                    legnagyobbSebesseg = item.Sebesseg;
                }
            }
            foreach (var item in kezelo)
            {
                if (item.Sebesseg == legnagyobbSebesseg)
                {
                    gyorsAutok.Add(item.Rendszam);
                }  
            }
            //5.feladat:
            //A legnagyobb sebesség km/ h: 154
            //A járművek: XQE - 678 PAL - 958
            Console.WriteLine($"5.feladat:\nA legnagyobb sebesség km/ h: {legnagyobbSebesseg}\n A járművek:");
            foreach (var item in gyorsAutok)
            {
                Console.Write($"{item} ");
            }
        }
        public void Tavolsag()
        {
            Console.WriteLine("6. feladat:\nKérem, adja meg a rendszámot:");
            var BekertRendszam = Console.ReadLine();
            List<string> sebesseg = new();
            foreach (var item in kezelo)
            {
                if (item.Rendszam == BekertRendszam)
                {
                    sebesseg.Add($"{item.Ora},{item.Perc},{item.Sebesseg}");
                } 
            }
            foreach (var item in sebesseg)
            {
                var sor = item.Split(",");
                int aktIdo = int.Parse(sor[0]) * 60 + int.Parse(sor[1]);

            }
        }
        public void WriteTXT()
        {
            List<string> marVanBenne = new();
            foreach (var item in kezelo)
            {
                if (!marVanBenne.Contains(item.Rendszam))
                {
                    marVanBenne.Add($"{item.Rendszam} {kezelo.Select(x => x.Ora).First()} {kezelo.Select(x => x.Perc).Last()} {kezelo.Select(x => x.Ora).Last()}");
                }
            }
            File.WriteAllLines("ido.txt", marVanBenne);
        }
    }
}
