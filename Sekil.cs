using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApplication5
{
     abstract class Sekil
    {
        private int x;
        private int y;
        private int genislik;
        private int yukseklik;
       public abstract void Ciz(Graphics g);
        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }

        }


        public int Genislik
        {
            get
            {
                return genislik;
            }

            set
            {
                genislik = value;
            }

        }


        public int Yukseklik
        {
            get
            {
                return yukseklik;
            }

            set
            {
                yukseklik = value;
            }
        }
       

        public void SolaGit()
        {
            x -= 10;
        }

        public void SagaGit()
        {
            x += 10;
        }



        public void YukariGit()
        {
            y -= 1;
        }

        public void AsagiGit()
        {
            y+= 1;
        }
    }
}

    

