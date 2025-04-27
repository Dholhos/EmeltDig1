using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autok.Models
{
    class Autok
    {
        string rendszam;
        int ora;
        int perc;
        int sebesseg;

        public Autok(string path)
        {
            var sor = path.Split("\t");
            rendszam = sor[0];
            ora =int.Parse(sor[1]);
            perc =int.Parse(sor[2]);
            sebesseg =int.Parse(sor[3]);
        }
        public string Rendszam { get => rendszam; set => rendszam = value; }
        public int Ora { get => ora; set => ora = value; }
        public int Perc { get => perc; set => perc = value; }
        public int Sebesseg { get => sebesseg; set => sebesseg = value; }
    }
}
