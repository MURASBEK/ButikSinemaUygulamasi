using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikSinemaUygulamasiG065
{
    //NESNEYE AİT VERİNİN YÖNETİMİ
    internal class Sinema
    {
        public string Film;
        public int Kapasite;
        public int TamBiletFiyati;
        public int YarimBiletFiyati;
        public int ToplamTamBiletAdedi;
        public int ToplamYarimBiletAdedi;
        public float Ciro;

        public Sinema(string filmAdi, int kap, int tam, int yarim)
        {
            this.Film = filmAdi;
            this.Kapasite = kap;
            this.TamBiletFiyati = tam;
            this.YarimBiletFiyati = yarim;
        }
        public void BiletSatis(int tam, int yarim)
        {
            if (this.BosKoltukAdediGetir() >= tam + yarim)
            {
                this.ToplamYarimBiletAdedi += yarim;
                this.ToplamTamBiletAdedi += tam;
                CiroHesapla();
                Console.WriteLine("İşlem gerçekleştirildi.  ");
            }
            else
            {
                Console.WriteLine("Yeterli boş koltuk yok. Satılabilecek bilet adedi: " + BosKoltukAdediGetir());
            }

        }
        public void BiletIadesi(int tam, int yarim)
        {
            if (tam <= this.ToplamTamBiletAdedi && yarim <= this.ToplamYarimBiletAdedi)
            {
                this.ToplamYarimBiletAdedi -= yarim;
                this.ToplamTamBiletAdedi -= tam;
                CiroHesapla();
                Console.WriteLine("İşlem gerçekleştirildi.  ");
            }
            else
            {
                Console.WriteLine("İade edilebilecek bilet miktarı aşıldı. ");
            }
        }
        private void CiroHesapla() //bu class'a özel bir metot
        {
            this.Ciro = this.ToplamTamBiletAdedi * this.TamBiletFiyati + this.ToplamYarimBiletAdedi * this.YarimBiletFiyati;

        }
        public int BosKoltukAdediGetir()
        {
            return this.Kapasite - this.ToplamYarimBiletAdedi - this.ToplamTamBiletAdedi;
        }


        //Satış sırasında boş koltuk adedinden fazla satışa izin vermesin.
        //İade sırasında satılandan fazla bilet iadesine izin vermesin
    }
}
