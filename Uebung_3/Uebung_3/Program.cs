//test bennet
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Schreiben Sie eine Eingabe für die Kantenlängen a und b
            Console.WriteLine("Bitte geben Sie Kantenlänge a (Breite) an");
            string eingabeA;
            eingabeA = Console.ReadLine();
            double a;
            a = Convert.ToDouble(eingabeA);

            Console.WriteLine("Bitte geben Sie Kantenlänge b (Höhe) an");
            string eingabeB;
            eingabeB = Console.ReadLine();
            double b;
            b = Convert.ToDouble(eingabeB);


            //• Berechnen Sie die Fläche
            double flaeche;
            flaeche = a * b;
            Console.WriteLine("Die FLäche beträgt: " + flaeche + " qm");

            
            //• Berechnen Sie den Flächenschwerpunkt des Profils.
            double schwerpunktX;
            double schwerpunktY;

            schwerpunktX = a / 2;
            schwerpunktY = b / 2;

            Console.WriteLine("Schwerpunkt (X/Y): (" + schwerpunktX + "/" + schwerpunktY + ")");

            //• Berechnen Sie die Flächenträgheitsmomente des Profils
            double ix;
            double iy;

            ix = a * Math.Pow(b, 3) / 12;
            iy = b * Math.Pow(a, 3) / 12;

            Console.WriteLine("Ix: " + ix + " mm^4");
            Console.WriteLine("Iy: " + iy + " mm^4");


            Console.ReadKey();
        }
    }
}
