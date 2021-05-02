using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApplication5
{
    class Mermi :Sekil
    {
         Image resim;
        
        public Mermi()
        {
            resim = Image.FromFile("mermi.jpg");
            Genislik = 20;
            Yukseklik = 20;
        }




       public override void Ciz(System.Drawing.Graphics g)

        {
            g.DrawImage(resim, X, Y, Genislik, Yukseklik);
        }


      

      
    }
}
