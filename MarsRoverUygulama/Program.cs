using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverUygulama
{
    class Program
    {
        static int bulunduguNoktaX = 0;
        static int bulunduguNoktaY = 0;
        static string bulunduguYon = "N";

        static void Main(string[] args)
        {
            //Maksimum gidebileceği noktaları istiyoruz.
            string ilkVeri = Console.ReadLine();

            //Boşlukları temizlemek için kullandık.
            ilkVeri = ilkVeri.Trim();

            //Boşluğa göre ayırıp integer veri tipine dönüştürüyoruz.
            var ilkGirisler = ilkVeri.Split(' ').Select(int.Parse).ToList();

            //Başlangıç noktalarını istiyoruz.
            string ikinciVeri = Console.ReadLine();

            //Boşlukları temizlemek için kullandık.
            ikinciVeri = ikinciVeri.Trim();

            //Boşluğa göre ayırıyoruz.
            var ikinciGirisler = ikinciVeri.Split(' ');

            //Boşluğa göre ayrılan verileri ilgili yerlerine göre dolduruyoruz.
            if (ikinciGirisler.Count() == 3)
            {
                bulunduguNoktaX = Convert.ToInt32(ikinciGirisler[0]);
                bulunduguNoktaY = Convert.ToInt32(ikinciGirisler[1]);
                bulunduguYon = ikinciGirisler[2];
            }

            //Gideceği yönlerin neler olduğunu istiyoruz.
            string haraketler = Console.ReadLine().ToUpper();

            //Koordinatlarını bulmak için hesaplama yapıyoruz.
            KoordinatlariBul(ilkGirisler, haraketler);

            //Ekrana çıktısını yazıyoruz.
            Console.WriteLine($"{bulunduguNoktaX} {bulunduguNoktaY} {bulunduguYon}");

            //Programın kapatılmaması için ekledik.
            Console.ReadLine();
        }

        public static void KoordinatlariBul(List<int> maksimumNoktalar, string hareketler)
        {
            foreach (var hareket in hareketler)
            {
                switch (hareket)
                {
                    case 'M':
                        {
                            switch (bulunduguYon)
                            {
                                case "N": bulunduguNoktaY += 1; break;
                                case "S": bulunduguNoktaY -= 1; break;
                                case "E": bulunduguNoktaX += 1; break;
                                case "W": bulunduguNoktaX -= 1; break;
                                default: break;
                            }
                        }
                        break;

                    case 'L':
                        {
                            switch (bulunduguYon)
                            {
                                case "N": bulunduguYon = "W"; break;
                                case "S": bulunduguYon = "E"; break;
                                case "E": bulunduguYon = "N"; break;
                                case "W": bulunduguYon = "S"; break;
                                default: break;
                            }
                        }
                        break;

                    case 'R':
                        {
                            switch (bulunduguYon)
                            {
                                case "N": bulunduguYon = "E"; break;
                                case "S": bulunduguYon = "W"; break;
                                case "E": bulunduguYon = "S"; break;
                                case "W": bulunduguYon = "N"; break;
                                default: break;
                            }
                        }
                        break;

                    default: break;
                }

                if (bulunduguNoktaX < 0 || bulunduguNoktaX > maksimumNoktalar[0] || bulunduguNoktaY < 0 || bulunduguNoktaY > maksimumNoktalar[1])
                {
                    Console.WriteLine($"Koordinatların dışında olamaz. (0, 0) ve ({maksimumNoktalar[0]} , {maksimumNoktalar[1]})");
                }
            }
        }
    }
}
