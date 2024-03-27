using System.Data;

namespace ButikSinemaUygulamasiG065
{
    internal class Program
    {
        //KULLANICI ETKİLEŞİMİ
        static Sinema Snm; //sinema nesnesi
        static void Main(string[] args)
        {
            //Giris();
            //Menu();
            //Uygulama();
            // Test();

            //Kullanıcıdan bir sayı girmesini isteyin.
            //Girilen değer sayı formatında değilse "Hatalı giriş yapıldı" mesajı verdirin.
            //Eğer doğruysa ekrana 2 katını yazdırın.


            //Kullanıcıdan iki sayı girmesini isteyin.
            //İlk değer sayı formatında değilse "Hatalı giriş yapıldı
            //mesajı verdirip değeri tekrar girmesini isteyin.
            //Bu sayı doğru girildikten sonra 2. sayıyı isteyin.
            //2 sayı da doğru bir şekilde alındıktan sonra bu sayıların
            //toplamını ekrana yazdıran kodu yazın.
            //Test2();

            //  SayıAl metodu ile ekrandan sayı alma işlemini yapabilir misin?
            //int sayi=SayiAl("Bir sayı girin: ");
            //Console.WriteLine(sayi*5);
            Test3();
        }
        static void Test()
        {
            Console.Write("Sayı girin: ");
            string giris = Console.ReadLine();
            int sayi;
            bool sonuc = int.TryParse(giris, out sayi); //true ya da false dönecek.
            if (!sonuc)  //sonuc==false
            {
                Console.WriteLine("Hatalı giriş yapıldı");
            }
            else
            {
                Console.WriteLine(sayi * 2);
            }
        }
        static void Test2()
        {
            bool sonuc = false;
            int sayi1 = 0, sayi2;
            while (!sonuc)
            {
                Console.Write("1. sayıyı giriniz: ");
                string giris = Console.ReadLine();
                sonuc = int.TryParse(giris, out sayi1);
                if (!sonuc)
                {
                    Console.WriteLine("Hatalı giriş yapıldı.");
                }
            }

            do
            {
                Console.Write("2. sayıyı giriniz: ");
                string giris = Console.ReadLine();
                sonuc = int.TryParse(giris, out sayi2);
                if (!sonuc)
                {
                    Console.WriteLine("Hatalı giriş yapıldı.");
                }

            } while (!sonuc);

            Console.WriteLine(sayi1 + sayi2);

        }
        static void Test3()
        {
            int s1 = SayiAl("1. sayıyı giriniz: ");
            int s2 = SayiAl("2. sayıyı giriniz: ");
            Console.WriteLine(s1 + s2);
        }
        static int SayiAl(string mesaj)
        {
            int sayi;
            bool sayiMi;
            while (true)
            {
                Console.Write(mesaj);
                sayiMi = int.TryParse(Console.ReadLine(), out sayi);
                if (!sayiMi)
                {
                    Console.WriteLine("Hatalı giriş yapıldı.");
                    continue;
                }
                return sayi;
            }
        }
        static void Giris()
        {
            Console.WriteLine("-------Butik Sinema Salonu-------");
            Console.Write("Film adı: ");
            string ad = Console.ReadLine();

            Console.Write("Kapasite: ");
            int kapasite = int.Parse(Console.ReadLine());

            Console.Write("Tam Bilet Fiyatı: ");
            int tamBilet = int.Parse(Console.ReadLine());

            Console.Write("Yarım Bilet Fiyatı: ");
            int yarimBilet = int.Parse(Console.ReadLine());

            Snm = new Sinema(ad, kapasite, tamBilet, yarimBilet);

        }
        static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Bilet Sat(S)     ");
            Console.WriteLine("2 - Bilet İade(R)    ");
            Console.WriteLine("3 - Durum Bilgisi(D) ");
            Console.WriteLine("4 - Çıkış(X)         ");

        }
        static void Uygulama()
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine().ToUpper();
                Console.WriteLine();
                switch (secim)
                {
                    case "1":
                    case "S":
                        BiletSat();
                        break;
                    case "2":
                    case "R":
                        BiletIade();
                        break;
                    case "3":
                    case "D":
                        DurumBilgisiGoster();
                        break;
                    case "4":
                    case "X":
                        Environment.Exit(0);
                        break;
                    case "L":
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Hatalı giriş yapıldı.");
                        break;
                }
            }
        }
        static void BiletSat()
        {
            Console.WriteLine("Bilet Sat:               ");
            Console.Write("Tam Bilet Adedi: ");
            int tam = int.Parse(Console.ReadLine());

            Console.Write("Yarım Bilet Adedi: ");
            int yarim = int.Parse(Console.ReadLine());

            //Snm.ToplamTamBiletAdedi += tam;
            //Snm.ToplamYarimBiletAdedi += yarim;
            Snm.BiletSatis(tam, yarim);

        }
        static void BiletIade()
        {
            Console.WriteLine("Bilet İade:               ");
            Console.Write("Tam Bilet Adedi: ");
            int tam = int.Parse(Console.ReadLine());

            Console.Write("Yarım Bilet Adedi: ");
            int yarim = int.Parse(Console.ReadLine());

            Snm.BiletIadesi(tam, yarim);

        }
        static void DurumBilgisiGoster()
        {
            Console.WriteLine("Durum Bilgisi ");
            Console.WriteLine("Film: " + Snm.Film);
            Console.WriteLine("Kapasite: " + Snm.Kapasite);
            Console.WriteLine("Tam Bilet Fiyatı : " + Snm.TamBiletFiyati);
            Console.WriteLine("Yarım Bilet Fiyatı : " + Snm.YarimBiletFiyati);
            Console.WriteLine("Toplam Tam Bilet Adedi: " + Snm.ToplamTamBiletAdedi);
            Console.WriteLine("Toplam Yarım Bilet Adedi: " + Snm.ToplamYarimBiletAdedi);
            Console.WriteLine("Ciro: " + Snm.Ciro);
            Console.WriteLine("Boş Koltuk Adedi: " + Snm.BosKoltukAdediGetir());

        }
    }
}