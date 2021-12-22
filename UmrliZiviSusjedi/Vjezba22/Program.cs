using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmrliZivi
{
    class Program
    {
        static void Main(string[] args)
        { /* Napraviti polje dimenzija 80*20 . Te dvije veličine spremiti i u varijable. Svaka čelija u polju može biti živa (1) ili mrtva (0)
             Napraviti sljedece metode: 
                1.Iscrtaj(polje, brojredova, brojstupaca) -- umjesto jedinica ispisivati zvjezdice a umjesto nula razmake -- 
                         (polje, 80, 20)
                2.ObrisiEkran()
                3.PrebrojiZiveSusjede(polje, brojredova, brojstupaca, red, stupac) -- susjedi neke čelije su one čelije koje se dodiruju snjom
                                     (polje, 80, 20, 5 , 4)
                4.IspuniPolje(polje, brojredova, brojstupaca)
            
            Dodati jos dvije varijable u main koje se zovu MinSusjedaZaPrezivljavanje=3, MaxSusjedaZaPrezivljavanje=6
                        Program u svakom prolasku u polju ugasi one pozicije koje su izvan definiranog raspona broja susjeda za prezivljavanje
            A upali one pozicije koje imaju odgovarajuci broj susjeda. 
            
            
            Cijelo polje se iscrtava nakon sto se izbrise ekran. procese ponavljam 
            dok ne predemo max broj iteracija.


        */
            int MaxIteracija = 20;

            int MaxRedova =20, MaxStupaca =80;

            int[,] polje = new int[MaxRedova, MaxStupaca];

            polje = IspuniPolje(polje, MaxRedova, MaxStupaca);
            for (int brojac=0;brojac<MaxIteracija ; brojac++ ) 
            {
                
               
                
                Console.WriteLine(brojac);
                
                polje = IzracunajZive(polje, MaxRedova, MaxStupaca);
                ObrisiEkran();
                Iscrtaj(polje, MaxRedova, MaxStupaca);

                //System.Threading.Thread.Sleep(500);

            }

            Console.ReadKey();

        }

        static int[,] IzracunajZive(int[,] poljeZivih, int BrojRedova, int BrojStupaca)
        {
            int MinSusjedaZaPrezivljavanje = 2, MaxSusjedaZaPrezivljavanje = 4;

            for (int redak = 0; redak < BrojRedova; redak++)
            {
                for (int stupac = 0; stupac < BrojStupaca; stupac++)
                {
                    int BrojZivihSusjeda = PrebrojiZiveSusjede(poljeZivih, BrojRedova, BrojStupaca, redak, stupac);
                    if (BrojZivihSusjeda >= MinSusjedaZaPrezivljavanje && BrojZivihSusjeda <= MaxSusjedaZaPrezivljavanje)
                    {
                        poljeZivih[redak, stupac] = 1;
                    }
                    else
                    {
                        poljeZivih[redak, stupac] = 0;
                    }
                }
            }
            return poljeZivih;
        }

        static int PrebrojiZiveSusjede(int[,] ZiviMrtvipolje, int BrojRedova, int BrojStupaca, int RedCelije, int StupacCelije) 
        {
            int ZiviSusjedi = 0;
            for (int redak = RedCelije-1 ; redak <= RedCelije + 1; redak++) //red celije je 6, treba procit 5 6 7
            {
                for (int stupac = StupacCelije-1; stupac <= StupacCelije +1; stupac++)
                {
                    try
                    {
                        if (ZiviMrtvipolje[redak, stupac] == 1)
                        {
                            if (!(redak == RedCelije && stupac == StupacCelije)) ZiviSusjedi++;

                        }
                    }
                    catch 
                    {

                    }   
                }  
            }
            return ZiviSusjedi;
        }

        static void Iscrtaj(int[,] IscrtanoPolje, int BrojRedova, int BrojStupaca)
        {

            for (int redak = 0; redak < BrojRedova; redak++)
            {
                for (int stupac = 0; stupac < BrojStupaca; stupac++)
                {
                    Console.Write("{0}", IscrtanoPolje[redak, stupac] == 1 ? "*" : " " );
                }
                Console.WriteLine();
            }
        }


        static void ObrisiEkran() 
        {
            Console.Clear();
        }

        static int[,] IspuniPolje(int[,] IspunjenoPolje, int BrojRedova, int BrojStupaca) 
        {
            int SanseZaZivot = 66;

            Random r = new Random();

            for(int redak =0;redak<BrojRedova ; redak++) 
            {
                for(int stupac = 0; stupac < BrojStupaca; stupac++)
                {
                    //Slučajni brojevi 1-10 u 60 posto slučajeva su između 1-6
                    int slucajniBroj = r.Next(1, 101);
                    if (slucajniBroj<=SanseZaZivot) 
                    {
                        IspunjenoPolje[redak, stupac] = 1;
                    }
                    else
                    {
                        IspunjenoPolje[redak, stupac] = 0;
                    }
                }
            }
            return IspunjenoPolje;
        }
    }
}

