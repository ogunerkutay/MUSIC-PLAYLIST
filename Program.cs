using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSIC_PLAYLIST
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string[] listeler = new string[1] { "Liste Boş" };
            string girilendeger = string.Empty;
            string listeismi = string.Empty;
            do
            {
                Console.WriteLine("Şarkıları listelemek için 'listele'\nŞarkı eklemek için 'sarki ekle'\nŞarkı çıkartmak için 'sarki cikart'\nÇıkmak için 'tamam' yazınız!");
                Console.WriteLine(new String('-', 100));
                girilendeger = Console.ReadLine().Trim().ToLower();

                switch (girilendeger)
                {
                    case "tamam":
                        break;
                    case "listele":
                        Listele(listeler);
                        break;
                    case "sarki ekle":
                        listeler = SarkiEkle(listeler);
                        break;
                    case "sarki cikart":
                        listeler = SarkiCikart(listeler);
                        break;

                    default:
                        Console.WriteLine(new String('-', 100));
                        Console.WriteLine("Böyle bir komut bulunamadı!");
                        break;
                }
            } while (girilendeger != "tamam");
            Console.WriteLine("Uygulamamızı puanlamayı unutmayın, bizi tercih ettiğiniz için teşekkür ederiz!");
        }
        static void Listele(string[] args)
        {
            Console.WriteLine(new String('-', 100));
            Console.WriteLine("Listenizin son hali : ");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
            Console.WriteLine(new String('-', 100));
        }
        static string[] SarkiEkle(string[] args)
        {
            Console.WriteLine(new String('-', 100));
            Console.WriteLine("Şarkınız için bir isim belirtiniz!");
            string listeismi;
            do
            {
                listeismi = Console.ReadLine().Trim();
                if (listeismi == string.Empty)
                {
                    Console.WriteLine("Şarkı isimleri boşluk olamaz!");
                }
            } while (listeismi == string.Empty);
            
            if (args[0] == "Liste Boş")
            {
                args[0] = listeismi;

                Listele(args);
                return args;
            }
            else
            {
                string[] yeniListe = new string[args.Length + 1];
                Array.Copy(args, yeniListe, args.Length);
                yeniListe[yeniListe.Length - 1] = listeismi;
                Listele(yeniListe);
                return yeniListe;
            }

        }


        static string[] SarkiCikart(string[] args)
        {
            Console.WriteLine(new String('-', 100));
            Console.WriteLine("Çıkartmak istediğiniz şarkı için bir isim belirtiniz!");
            Listele(args);
            string listeismi;
            do
            {
                listeismi = Console.ReadLine().Trim();
                if (!args.Contains(listeismi))
                {
                    Console.WriteLine("Çıkartmak istediğiniz şarkı ismi yoktur!\nLütfen aşağıdaki listeden şarkı çıkartmak için bir şarkı isim seçiniz : ");
                    Listele(args);
                }

            } while (listeismi == string.Empty || !args.Contains(listeismi));
            string cevap;
            do
            {
                Console.WriteLine(new String('-', 100));
                Console.WriteLine(listeismi + " listenizden silinecektir emin misiniz? evet - hayır");
                Console.WriteLine(new String('-', 100));
                cevap = Console.ReadLine().Trim();   
            } while (cevap!="evet" && cevap!="hayır");

            if (cevap == "evet")
            {
                if (args.Length == 1)
                {
                    args[Array.IndexOf(args, listeismi)] = "Liste Boş";
                }
                else
                {
                    args[Array.IndexOf(args, listeismi)] = String.Empty;
                    args = args.Where(listeisimleri => !string.IsNullOrEmpty(listeisimleri)).ToArray();
                }


                Listele(args);

            }

            return args;
        }
    }
}
