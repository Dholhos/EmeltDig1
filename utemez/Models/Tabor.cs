using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utemez.Models
{
    class Tabor
    {
        int kezdetHonap;
        int kezdetNap;
        int vegHonap;
        int vegNap;
        string kod;
        string temakor;

        public Tabor(string path)
        {
            var sor = path.Split("\t");
            kezdetHonap = int.Parse(sor[0]);
            kezdetNap = int.Parse(sor[1]);
            vegHonap = int.Parse(sor[2]);
            vegHonap = int.Parse(sor[3]);
            kod = sor[4];
            temakor = sor[5];
        }
        public int KezdetHonap { get => kezdetHonap; set => kezdetHonap = value; }
        public int KezdetNap { get => kezdetNap; set => kezdetNap = value; }
        public int VegHonap { get => vegHonap; set => vegHonap = value; }
        public int VegNap { get => vegNap; set => vegNap = value; }
        public string Kod { get => kod; set => kod = value; }
        public string Temakor { get => temakor; set => temakor = value; }
    }
}
