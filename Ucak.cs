using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication5
{
    class Ucak :Sekil
    {
        Image resim;
        public Ucak()
        {
            resim = Image.FromFile("ucak.png");
            resim.RotateFlip(RotateFlipType.Rotate180FlipX);
            Genislik = 50;
            Yukseklik = 50;
        }




        public override void Ciz(Graphics g)
        {
          g.DrawImage(resim, X, Y, Genislik, Yukseklik);
          
        }


      
       


    }
}
