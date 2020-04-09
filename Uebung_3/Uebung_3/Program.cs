//test bennet
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



        static void Main(string[] args)

        {

            //Messagebox funktioniert noch nicht





            string message = "Wollen Sie mit der Berechnugn fortfahren?";
            string title = "Frage";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);

            if (result == DialogResult.No) 
            {
                System.Windows.Application.Exit();
            }
            //hier komm ich jetzt nicht mehr weiter wie schließt man das Programm bei drücken von nein?
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
            double flaeche = Flaechenberechnung(a, b);
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



        }
        public static double Flaechenberechnung(double a, double b)
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
