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
            Schwerpunktberechnung(a, b);

            //• Berechnen Sie die Flächenträgheitsmomente des Profils
            double ix;
            double iy;

            ix = a * Math.Pow(b, 3) / 12;
            iy = b * Math.Pow(a, 3) / 12;

            Console.WriteLine("Ix: " + ix + " mm^4");
            Console.WriteLine("Iy: " + iy + " mm^4");

            Console.ReadKey();
                    
             break;

                case 2:
                    
                    double bBreite;
                    double bBreiteRip;
                    double hHöhe;
                    double hHöheRip;
                    double lLänge;

                    do

                    {
                        Console.Clear();

                        Console.WriteLine("Hier kannst du einen T-Träger berechnen:");

                        Console.WriteLine("Breite B: "); bBreite = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Rippenbreite b (die Rippe muss schmaler als die Gesamtbreite sein): "); bBreiteRip = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Höhe H: "); hHöhe = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Rippenhöhe h (die Rippe muss flacher als die Gesamthöhe sein): "); hHöheRip = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Länge L (die Rippe muss kürzer als die Gesamthöhe sein):"); lLänge = Convert.ToDouble(Console.ReadLine());

                        if (hHöhe < hHöheRip && bBreite < bBreiteRip)
                        {
                            Console.WriteLine("Überprüfe deine Eingabe, die Rippe muss flacher als die Gesamthöhe sein, und die Rippe muss schmaler als die Gesamtbreite sein, bestätige mit einer Taste");

                            Console.ReadKey();
                        }

                        else if (bBreite < bBreiteRip)
                        {
                            Console.WriteLine("Überprüfe deine Eingabe, die Rippe muss schmaler als die Gesamtbreite sein, bestätige mit einer Taste");

                            Console.ReadKey();
                        }

                        else if (hHöhe < hHöheRip)
                        {
                            Console.WriteLine("Überprüfe deine Eingabe, die Rippe muss kürzer als die Gesamthöhe sein, bestätige mit einer Taste");

                            Console.ReadKey();
                        }

                        else if (lLänge < 0)
                        {
                            Console.WriteLine("Überprüfe deine Eingabe, der Träger muss länger Null sein, bestätige mit einer Taste");

                            Console.ReadKey();
                        }

                    }
                    while (bBreite < bBreiteRip || hHöhe < hHöheRip || lLänge < 0);

                        double Fläche = Rechteck(bBreite, hHöhe) + Rechteck(bBreiteRip, hHöheRip);
                        double Volumen = Fläche * lLänge;

                        Console.WriteLine("Die Fläche beträgt: " + Fläche);
                        Console.WriteLine("Das Volumen beträgt: " + Volumen);

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

        public static void Schwerpunktberechnung(double a, double b)
        {
            double schwerpunktX = a / 2;
            double schwerpunktY = b / 2;
            Console.WriteLine("Schwerpunkt (X/Y): (" + schwerpunktX + "/" + schwerpunktY + ")");
        }







    }
}
