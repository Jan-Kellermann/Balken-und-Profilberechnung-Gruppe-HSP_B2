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


            Console.WriteLine("Für die berechnung eines einfachen Balkens 1 drücken, für einen T-Träger 2, für einen Kasten 3");

            int nummer = Convert.ToInt32(Console.ReadLine());
               int caseSwitch =  nummer;

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

                    do

                    {
                        Console.Clear();

                        Console.WriteLine("Hier kannst du einen T-Träger berechnen (eingaben in mm):");

                        Console.WriteLine("Gurtbreite B: "); 
                        bBreite = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Rippenbreite b (die Rippe muss schmaler als die Gesamtbreite sein): "); 
                        bBreiteRip = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Gurthöhe H: "); 
                        hHöhe = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Rippenhöhe h (die Rippe muss flacher als die Gesamthöhe sein): "); 
                        hHöheRip = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Länge L (die Rippe muss kürzer als die Gesamthöhe sein):"); lLänge = Convert.ToDouble(Console.ReadLine());

                        if (bBreite <= 0 || bBreiteRip <= 0 || hHöhe <= 0 ||  hHöheRip <= 0 || lLänge <= 0)
                        {
                            Console.WriteLine("die eingaben sollten größer null sein");
                        }
                       
                        else if (bBreite < bBreiteRip)
                        {
                            Console.WriteLine("Überprüfe deine Eingabe, die Rippe muss schmaler als die Gurttbreite sein, bestätige mit einer Taste");

                            Console.ReadKey();
                        }

                        
                    }
                    while (bBreite < bBreiteRip || bBreite <= 0 || bBreiteRip <= 0 || hHöhe <= 0 || hHöheRip <= 0 || lLänge <= 0);

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

                    //Komentare und weitere berechnungen folgen





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





    }
}
