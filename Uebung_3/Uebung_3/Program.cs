//test bennet
//test rune
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Uebung_3
{
    class Program
    {



        static void Main()

        {

            //Messagebox funktioniert noch nicht





            string message = "Wollen Sie mit der Berechnung fortfahren?";
            string title = "Frage";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);





            string Eingabe;
            int EingabeNeu;
            do //Prüfung der Eingabe auf Plausbilität
            {
                Console.Clear();
                do
                {
                    Console.Clear();
                    Console.WriteLine("Für die Berechnung eines einfachen Balkens 1 drücken, für einen T-Träger 2, für einen Kasten 3");

                    Eingabe = Console.ReadLine();

                    if (PrüfungZahl(Eingabe) == false) //Prüfung mit der Methode TryParse in Unterprogramm
                    {
                        Console.WriteLine("Leider hast du keine Zahl Eingegeben.(bestätige mit einer Taste)");
                        Console.ReadKey();
                    }


                }
                while (PrüfungZahl(Eingabe) == false);

                EingabeNeu = Convert.ToInt32(Eingabe); //Eingabe ist eine Zhal und kann fehlerfrei in eine Integer convertiert werden 

                if (EingabeNeu > 4)
                {
                    Console.WriteLine("Auswahl steht nicht zur Verfügung. (bestätige mit einer Taste)");
                    Console.ReadKey();
                }
            }
            while ( EingabeNeu > 4); //Prüfung ob die Eingabe der Möglichen Auswahl entspricht

            int nummer = EingabeNeu;
            int caseSwitch = nummer;

            switch(caseSwitch)
            {

                case 1:

            //Schreiben Sie eine Eingabe für die Kantenlängen a und b
            Console.WriteLine("Bitte geben Sie Kantenlänge a (Breite) in mm an");
            string eingabeA;
            eingabeA = Console.ReadLine();
            double a;
            a = Convert.ToDouble(eingabeA);

            Console.WriteLine("Bitte geben Sie Kantenlänge b (Höhe) in mm an");
            string eingabeB;
            eingabeB = Console.ReadLine();
            double b;
            b = Convert.ToDouble(eingabeB);


            //• Berechnen Sie die Fläche
            double flaeche = Rechteck(a, b);
            Console.WriteLine("Die FLäche beträgt: " + flaeche + " qm");

            //• Berechnen Sie den Flächenschwerpunkt des Profils.
            Console.WriteLine("Schwerpunkt in bezug auf die Obere linke Ecke: " + SRechteck(a) + "/" + SRechteck(b)); //Schwerkupnkberechnung des rechteckes

            //• Berechnen Sie die Flächenträgheitsmomente des Profils
            double ix = IRechteck(a,b);
            double iy = IRechteck(b,a);
                            
            

            Console.WriteLine("Ix: " + ix + " mm^4");
            Console.WriteLine("Iy: " + iy + " mm^4");

            Console.ReadKey();
                    
             break;

                case 2:
                    Console.Clear();
                    double bBreite;
                    double bBreiteRip;
                    double hHöhe;
                    double hHöheRip;
                    double lLänge;
                    string bBreiteE;
                    string bBreiteRipE;
                    string hHöheE;
                    string hHöheRipE;
                    string lLängeE;
                    do
                    {
                        Console.Clear();
                        do

                        {
                            Console.Clear();

                            Console.WriteLine("Hier kannst du einen T-Träger berechnen (eingaben in mm):");

                            Console.WriteLine("Gurtbreite B: ");
                            bBreiteE = Console.ReadLine();

                            Console.WriteLine("Rippenbreite b (die Rippe muss schmaler als die Gesamtbreite sein): ");
                            bBreiteRipE = Console.ReadLine();

                            Console.WriteLine("Gurthöhe H: ");
                            hHöheE = Console.ReadLine();

                            Console.WriteLine("Rippenhöhe h (die Rippe muss flacher als die Gesamthöhe sein): ");
                            hHöheRipE = Console.ReadLine();

                            Console.WriteLine("Länge L (die Rippe muss kürzer als die Gesamthöhe sein):");
                            lLängeE = Console.ReadLine();

                            if ((PrüfungZahl(bBreiteE) || PrüfungZahl(bBreiteRipE) || PrüfungZahl(hHöheE) || PrüfungZahl(hHöheRipE) || PrüfungZahl(lLängeE)) == false)
                            {
                                Console.WriteLine("Eigabe ist keine Zahl.(Bestätige mit einer Taste)");
                            }

                        }
                        while ((PrüfungZahl(bBreiteE) || PrüfungZahl(bBreiteRipE) || PrüfungZahl(hHöheE) || PrüfungZahl(hHöheRipE) || PrüfungZahl(lLängeE)) == false);
                        
                        
                        bBreite = Convert.ToInt32(bBreiteE);
                        hHöhe = Convert.ToInt32(hHöheE);
                        bBreiteRip = Convert.ToInt32(bBreiteRipE);
                        hHöheRip = Convert.ToInt32(hHöheRipE);
                        lLänge = Convert.ToInt32(lLängeE);
                        if (bBreite > 0 || hHöhe > 0 || bBreiteRip > 0 || hHöheRip > 0 || lLänge > 0)
                        {
                            Console.WriteLine("Deine Eingaben müssen Größer null sein.(Bestätige mit einer Taste)");
                            Console.ReadKey();
                        }
                        if (bBreiteRip<bBreite)
                        {
                            Console.WriteLine("Die Rippe muss schmaler sein als die Gesammtbreite.(Bestätige mit einer Taste)");
                        }

                    }
                    while (bBreite>0 || hHöhe>0 || bBreiteRip>0 || hHöheRip>0 || lLänge>0 || bBreiteRip<bBreite);                   
                    


                    double Fläche = Rechteck(bBreite, hHöhe) + Rechteck(bBreiteRip, hHöheRip);
                    double Volumen = Fläche * lLänge;
                    double SchwerpunktX = (Rechteck(bBreite, hHöhe)* SRechteck(bBreite) + Rechteck(bBreiteRip, hHöheRip) * SRechteck(bBreiteRip)) / Fläche;
                    double SchwerpunktY = -1*((Rechteck(bBreite, hHöhe) * SRechteck(hHöhe) + Rechteck(bBreiteRip, hHöheRip) * SRechteck(hHöheRip)) / Fläche);
                    double SchwerpunktZ = lLänge / 2;
                    double Iy = (IRechteck(bBreite, hHöhe) + IRechteck(bBreiteRip, hHöheRip)) /12;
                    



                        Console.WriteLine("Die Fläche beträgt: " + Fläche +" mm^2");
                        Console.WriteLine("Das Volumen beträgt: " + Volumen + " mm^3");
                        Console.WriteLine("Schwerpunkt in bezug auf Ecke oben links: " + SchwerpunktX + " mm" + "/" + SchwerpunktY + " mm" + "/" + SchwerpunktZ + " mm");
                        Console.WriteLine("Flächenträgheitsmomente: Iy=" + Iy+ " mm^4");

                    //Komentare und weitere Berechnungen folgen





                    Console.ReadKey();
                break;

            //berechnung T-Profil


        }


        }

        public static double Rechteck(double a, double b)
        {
            double flaeche;
            flaeche = a * b;
            return flaeche;
        }

        public static double SRechteck(double seitenlänge)
        {
            double schwerpunkt = seitenlänge / 2;
            return schwerpunkt;
          
        }

        public static double IRechteck (double a, double b)
        {
           double I = a * Math.Pow(b, 3) / 12;
            return I;
        }

        public static bool PrüfungZahl(string Eingabe)
        {
            int i = 0;            
            bool result = int.TryParse(Eingabe, out i);

            return result;
        }




    }
}
