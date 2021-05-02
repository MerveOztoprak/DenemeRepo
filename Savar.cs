using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication5
{
    class Savar :Sekil
    {
        Image resim;

        public Savar()
        {
            resim = Image.FromFile("savar.png");
            Genislik = 64;
            Yukseklik = 64;
        }

        public override void Ciz(System.Drawing.Graphics g)
        {
            g.DrawImage(resim, X, Y, Genislik, Yukseklik);

        }

      
    }
}
