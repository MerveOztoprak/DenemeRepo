/*****************************************************************************************
**                      SAKARYA UNIVERSITESI
**              BILGISAYAR MUHENDISLIGI BOLUMU
**               NESNEYE  DAYALI PROGRAMLAMA
**
**     OGRENCI ADI......: MERVE OZTOPRAK
**     OGRENCI NOSU.....:G161210023
**     DERS GRUBU........: 2A grubu
******************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication5
{
    class AnaPencere:Form
    {

        Ucak u = new Ucak();
        Mermi m = new Mermi();
        Savar s = new Savar();
        Random rnd = new Random();
        
        List<Ucak> ucaklar = new List<Ucak>();
        List<Mermi> mermiler = new List<Mermi>();
        List<Savar> savarlar = new List<Savar>();

        public int tickSayisi = 0;
        public bool BittiMi = true;


        Timer t = new Timer();

       
    
         public AnaPencere(int genislik,int yukseklik)
        {
            Width = genislik;
            Height = yukseklik;

             KeyDown+=AnaPencere_KeyDown;
             Paint+=AnaPencere_Paint;


             DoubleBuffered = true;
             t.Interval = 1;
             t.Tick+=t_Tick;

             s = new Savar();
             s.X = 350;
             s.Y = 500;
             
             Text = "Oyuna başlamak için ENTER tuşuna basınız. <br>  Uçaksavarı hareket ettirmek için SAĞ/SOL yön tuşlarına basınız </br>. /n Ateş etmek için SPACE tuşuna basınız.";
            
    }

         private void t_Tick(object sender, EventArgs e)
         { 





             if(tickSayisi==100)
             {
                 u = new Ucak();
                 u.X = rnd.Next(1, 700);
                 u.Y = 0;
                 ucaklar.Add(u);
                 tickSayisi = 0;
             }
             tickSayisi++;


             foreach (var siradaki in ucaklar)
                 siradaki.AsagiGit();


             foreach (var siradaki in mermiler)
                 siradaki.YukariGit();


             for (int i = 0; i < ucaklar.Count;i++)
             {
                 if(ucaklar[i].Y+ucaklar[i].Genislik>550)
                 {
                     BittiMi = true;
                     t.Stop();
                 }
             }

             for (int i = 0; i < mermiler.Count; i++)
             {

                 int mX = mermiler[i].X;
                 int mY = mermiler[i].Y;
                 int mGenislik = mermiler[i].Genislik;
                 for (int j = 0; j < ucaklar.Count; j++)
                 {
                     int uX = ucaklar[j].X;
                     int uY = ucaklar[j].Y;
                     int uGenislik = ucaklar[j].Genislik;


                     //Mermi ile ucak çarpışma testi.
                     //kare ile kare çarpışması. 

                     
                     if(mX < uX+ uGenislik &&
                          mX+mGenislik > uX &&
                         mY < uY + uGenislik &&
                         mY+mGenislik > uY)
                     {
                         ucaklar.RemoveAt(j);
                         mermiler.RemoveAt(i);
                         i--;
                         break;

                     }
     

                 }
            







             }

             // ucaj ve ucak sacar için yukarının aynısı

             for (int i = 0; i < ucaklar.Count; i++)
             {

                 int uX = ucaklar[i].X;
                 int uY = ucaklar[i].Y;
                 int uGenislik = ucaklar[i].Genislik;
                 for (int j = 0; j < savarlar.Count; j++)
                 {
                     int sX = savarlar[j].X;
                     int sY = savarlar[j].Y;
                     int sGenislik = savarlar[j].Genislik;

                     

                     //ucaksavar ile ucak çarpışma testi.
                     //kare ile kare çarpışması. 


                     if (uX < sX + sGenislik &&
                          uX + uGenislik > sX &&
                         uY < sY + sGenislik &&
                         uY + uGenislik > sY)
                     {
                         ucaklar.RemoveAt(i);
                        
                   
                         break;

                     }

                 }

             }



                 
                 Invalidate();
         }

         private void AnaPencere_Paint(object sender, PaintEventArgs e)
         {
             e.Graphics.DrawRectangle(Pens.Black, 0,0,790, 550);
             s.Ciz(e.Graphics);

             foreach (var siradaki in ucaklar)
                 siradaki.Ciz(e.Graphics);

             foreach (var siradaki in mermiler)
                 siradaki.Ciz(e.Graphics);

       
    }

         private void AnaPencere_KeyDown(object sender, KeyEventArgs e)
         {

             if(s!=null)
             {
                 if (e.KeyCode == Keys.Right)
                 {
                     if (s.X<800-s.Genislik)
                     s.SagaGit();
                 }
                 if (e.KeyCode == Keys.Left)
                 {
                     if(s.X>0)
                     s.SolaGit();
                 }

             }

             if (e.KeyCode == Keys.Enter)
             {
                 if(BittiMi==true)
                 {
                     ucaklar.Clear();
                     mermiler.Clear();

                     BittiMi = false;
                     t.Start();
                 
                 
                 
                 }
                

             }

             if(e.KeyCode== Keys.Escape)
             {
                 t.Stop();
             }
             if(e.KeyCode==Keys.Space)
             {
                 m = new Mermi();
                 m.X = (s.X + s.Genislik/2)  - m.Genislik / 2;
                 m.Y = s.Y-m.Genislik;
                 mermiler.Add(m);

             }

             Invalidate();




            
         }
}
}