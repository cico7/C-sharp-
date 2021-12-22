using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrizicKruzic
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            string[,] polje = new string[3, 3];
            polje = NovaIgra();

            int redak, stupac, igrac, brojac=0;
            string znak;

            do
            {
                igrac = brojac % 2 + 1;

                if (igrac == 1) 
                {
                    znak = "X";
                }
                else znak = "O";

                //

                Console.Write("Na redu je igrac broj {0}",igrac);
                Console.Write("Unesite redak:");
                //int.TryParse(Console.ReadLine(), out redak)
                redak = r.Next(1, 4);
                Console.Write("Unesite stupac:");
                //int.TryParse(Console.ReadLine(), out stupac);
                stupac = r.Next(1, 4);
                if (polje[redak-1, stupac-1] != "_")
                {
                    Console.WriteLine("Ta pozicija je zauzeta.");
                }
                else
                {
                    polje = OdigrajPotez(polje, znak, redak, stupac);
                    IscrtajTablu(polje);
                    
                    brojac++;   
                }
                if (brojac == 9) break;
            }
            while (redak != 0 && stupac != 0);
            Console.ReadKey();  
        }

        static void IscrtajTablu(string[,] parametar_polje) 
        {
            Console.WriteLine("#######################################################");

            
            for (int red = 0; red < 3; red++) 
            {
                //Console.WriteLine("Mi smo u redu {0}",red);
                Console.WriteLine("-------------");
                for (int stupac = 0; stupac < 3; stupac++) 
                {

                    Console.Write("| {0} ",parametar_polje[red,stupac]);
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("-------------");
        }
        static string[,] OdigrajPotez(string[,] tablicaZaIgru, string znak, int redak, int stupac ) 
        {
            //Ova metoda odigrava jedan potez prema parametrima koji će joj biti proslijeđeni
            //Odigrati potez znači ažurirati polje u tablici za igru
            
            tablicaZaIgru[redak-1, stupac-1] = znak;
            Console.WriteLine("Odigrali smo znak {0} na poziciji ({1},{2})",znak,redak,stupac);
            return tablicaZaIgru;
        }
        static string[,] NovaIgra()
        {
            string[,] PraznaTablica = new string[3, 3]
            {
                {"_" ,"_" ,"_" },
                {"_" ,"_" ,"_" },
                {"_" ,"_" ,"_" }
            };
            return PraznaTablica;
        }
            //Ova metoda poništava sve do sad odigrane poteze na način da sve pozicije u tablici za igru postavlja na "_"
    }
}
/*
 napraviti metodu za iscrtavanje tablice:
void iscrtaj_igru(string[,] tabla_krizic_kruzic)
{
}
 string[,] krizic_kruzic = new string[3, 3]

{
{"_" ,"O","X" },
{"X","O","O"  },
{"_" ,"_" ,"X"},
};

{
{"A" ,"B","C"},
{"D","E","F"},
{"G" ,"H" ,"I"},
};

pozivanje sa:

iscrtaj_igru(krizic_kruzic);

program inicijalizira praznu tablu za igranje


program naizmjenice pita prvog i drugog igraca na kojem retku i stupcu zele staviti svoj znak i to upisuje odmah u tablu i iscrtava je

2

1
*/