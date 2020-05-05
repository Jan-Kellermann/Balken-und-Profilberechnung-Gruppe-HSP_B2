﻿//test bennet
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

            


            string message = "Herzlich Willkommen! Möchten Sie mit den Berechnungen zu verschiedenen Profilen beginnen?";
            string title = "Frage";
            
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                Environment.Exit(1);
            }
            else
            {

                //Hier wird Auswahl getroffen wechen Träger man berechnen möchte
                string Eingabe;
                int EingabeNeu;
                do //Prüfung der Eingabe auf Plausbilität
                {
                    Console.Clear();
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Für die Berechnung eines einfachen Balkens 1 drücken, für einen T-Träger 2, für einen Kasten 3, für ein Rundprofil 4, für ein Rohr 5");

                        Eingabe = Console.ReadLine();

                        if (PrüfungZahl(Eingabe) == false) //Prüfung mit der Methode TryParse in Unterprogramm
                        {
                            Console.WriteLine("Leider hast du keine Zahl eingegeben.(bestätige mit einer Taste)");
                            Console.ReadKey();
                        }


                    }
                    while (PrüfungZahl(Eingabe) == false);

                    EingabeNeu = Convert.ToInt32(Eingabe); //Eingabe ist eine Zahl und kann fehlerfrei in ein Integer convertiert werden 

                    if (EingabeNeu > 6)
                    {
                        Console.WriteLine("Auswahl steht nicht zur Verfügung. (bestätige mit einer Taste)");
                        Console.ReadKey();
                    }
                }
                while (EingabeNeu > 6); //Prüfung ob die Eingabe der Möglichen Auswahl entspricht

                int nummer = EingabeNeu;
                int caseSwitch = nummer;

                switch (caseSwitch)
                {

                    case 1: //Rechteck

                        Console.WriteLine("  * * * * * *");
                        Console.WriteLine("  *         *");
                        Console.WriteLine("  *         *  b");
                        Console.WriteLine("  * * * * * *");
                        Console.WriteLine("       a        ");

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
                        double flaeche = FlaecheRechteck(a, b);
                        Console.WriteLine("Die FLäche beträgt: " + flaeche + " qm");

                        //• Berechnen Sie den Flächenschwerpunkt des Profils.
                        Console.WriteLine("Schwerpunkt in Bezug auf die obere linke Ecke: " + SRechteck(a) + "/" + SRechteck(b)); //Schwerkupnkberechnung des rechteckes

                        //• Berechnen Sie die Flächenträgheitsmomente des Profils
                        double ix = IRechteck(a, b);
                        double iy = IRechteck(b, a);



                        Console.WriteLine("Ix: " + ix + " mm^4");
                        Console.WriteLine("Iy: " + iy + " mm^4");

                        Console.ReadKey();

                        break;

                        //**********************************************************************************************************************************************************************

                    case 2: // T-Profil
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
                            do //Zahlen werden eingelesen und geprüft ob sie mit dem Datentyp und übereinstimmen und ob es sich um eine Zahl handelt 

                            {
                                Console.Clear();

                                Console.WriteLine("Hier kannst du einen T-Träger berechnen (Eingaben in mm):");
                                //Darstellung des Profils als Sternehaufen

                                Console.WriteLine("|     B    |__");
                                Console.WriteLine("***********");
                                Console.WriteLine("*         * H");
                                Console.WriteLine("****   ****___");
                                Console.WriteLine("   *   *    ");
                                Console.WriteLine("   *   *    ");
                                Console.WriteLine("   *   *    h");
                                Console.WriteLine("   *   *    ");
                                Console.WriteLine("   *****______");
                                Console.WriteLine("   | b |");

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

                            //wenn es sich bei den Eingaben um Zahlen handelt werden die eingaben in Double konvertiert

                            bBreite = Convert.ToDouble(bBreiteE);
                            hHöhe = Convert.ToDouble(hHöheE);
                            bBreiteRip = Convert.ToDouble(bBreiteRipE);
                            hHöheRip = Convert.ToDouble(hHöheRipE);
                            lLänge = Convert.ToDouble(lLängeE);

                            if (bBreite < 0 || hHöhe < 0 || bBreiteRip < 0 || hHöheRip < 0 || lLänge < 0)
                            {
                                Console.WriteLine("Deine Eingaben müssen Größer null sein.(Bestätige mit einer Taste)");
                                Console.ReadKey();
                            }
                            if (bBreiteRip > bBreite)
                            {
                                Console.WriteLine("Die Rippe muss schmaler sein als die Gesammtbreite.(Bestätige mit einer Taste)");
                                Console.ReadKey();
                            }

                        }
                        while (bBreite < 0 || hHöhe < 0 || bBreiteRip < 0 || hHöheRip < 0 || lLänge < 0 || bBreiteRip > bBreite);

                        //Sind die Zahlen Größer Null und die Rippenbreite schmaler als Die Gutbreite wird mit den Berechnungen begonnen
                        double RechteckGurt = FlaecheRechteck(bBreite, hHöhe);                                                                 //mehrfach wiederkehrende Unterprogrammaufrufe wurden ausgegliedert
                        double RechteckRippe = FlaecheRechteck(bBreiteRip, hHöheRip);                                                          //mehrfach wiederkehrende Unterprogrammaufrufe wurden ausgegliedert

                        double Fläche = RechteckGurt + RechteckRippe;                                                                   //Flächenberechnung der T-Träger wird aus zwei Rechtecken zusammengesetzt die über das Unterprogramm Rechteck() aus der Balkenberechnung
                        double Volumen = Fläche * lLänge;                                                                               // Volumen wird durch die bereits berechnete Fläche und die Trägerlänge berechnet
                        double SchwerpunktX = (RechteckGurt * SRechteck(bBreite) + RechteckRippe * SRechteck(bBreiteRip)) / Fläche;     //Schwerpunkt wird durch Zusammenrechnung der einzelschwerpunkte der Rechtecke berechnet
                        double SchwerpunktY = -1 * ((RechteckGurt * SRechteck(hHöhe) + RechteckRippe * SRechteck(hHöheRip)) / Fläche);    //Schwerpunkt wird durch Zusammenrechnung der einzelschwerpunkte der Rechtecke berechnet
                        double SchwerpunktZ = lLänge / 2;                                                                               //Der Schwerpunkt in Balkenlänge befindet sich mittig
                        double Iy = (IRechteck(bBreite, hHöhe) + IRechteck(bBreiteRip, hHöheRip)) / 12;                                  //Berechnung des Flächenträgheitsmomentes um die Y Achse
                        double Ix = ((IRechteck(hHöheRip, bBreiteRip) + IRechteck(hHöhe, bBreite)) / 12); //Berechnung des Flächenträgheitsmomentes um die X Achse (Steiner Anteil konnte ich noch nicht implementieren) 



                        Console.WriteLine("Die Fläche beträgt: " + Fläche + " mm^2");
                        Console.WriteLine("Das Volumen beträgt: " + Volumen + " mm^3");
                        Console.WriteLine("Schwerpunkt in bezug auf Ecke oben links: " + SchwerpunktX + " mm" + "/" + SchwerpunktY + " mm" + "/" + SchwerpunktZ + " mm");
                        Console.WriteLine("Flächenträgheitsmomente: Iy=" + Iy + " mm^4");
                        //Console.WriteLine("Flächenträgheitsmomente: Ix=" + Ix + " mm^4");

                        //Komentare und weitere Berechnungen folgen





                        Console.ReadKey();

                        break;

                    


                    //***********************************************************************************************************************************************************************************
                    case 3: //Kasten



                        break;

                        
                    //*******************************************************************************************************************************************************************************

                    case 4: //Rundprofil
                        string dDurchmesserE;
                        string lLängeERund;
                        double dDurchmesser;
                        double lLängeRund;
                        do
                        {
                            do
                            {
                               

                                Console.Clear();
                                Console.WriteLine("Hier kannst du ein Rundprofil berechnen (Eingaben in mm):");
                                Console.WriteLine("  * *");
                                Console.WriteLine("*--d--*");
                                Console.WriteLine("  * *");
                               

                                Console.WriteLine("Durchmesser d: ");
                                dDurchmesserE = Console.ReadLine();

                                Console.WriteLine("Länge l:");
                                lLängeERund = Console.ReadLine();

                                if (( PrüfungZahl(dDurchmesserE) || PrüfungZahl(lLängeERund)) == false)
                                {
                                    Console.WriteLine("Eigabe ist keine Zahl.(Bestätige mit einer Taste)");
                                }

                                
                            } while ((PrüfungZahl(dDurchmesserE) || PrüfungZahl(lLängeERund)) == false);


                            dDurchmesser = Convert.ToDouble(dDurchmesserE);
                            lLängeRund = Convert.ToDouble(lLängeERund);

                            if (dDurchmesser < 0 || lLängeRund < 0 )
                            {
                                Console.WriteLine("Deine Eingaben müssen größer null sein.(Bestätige mit einer Taste)");
                                Console.ReadKey();
                            }


                        } while (dDurchmesser < 0 || lLängeRund < 0);
                                 


                        
                        Console.WriteLine("Kreisfläche: " + Kreisfläche(dDurchmesser) + "mm²");
                        Console.WriteLine("Volumen: " + Kreisfläche(dDurchmesser) * lLängeRund + "mm³");
                        Console.WriteLine("Schwerpunkt XY: " + dDurchmesser / 2 + "mm");
                        Console.WriteLine("Schwerpunkt: " + lLängeRund / 2 + "mm");
                        Console.WriteLine("Flächenträgheitsmoment: " + IKreis(dDurchmesser) + "mm^4");



                        Console.ReadKey();
                       

                        break;
                    //**************************************************************************************************************************************************************************************

                    case 5: //Rohr

                        string dDurchmesserEingabeAussen;                        
                        string dDurchmesserEingabeInnen;                        
                        string lLängeEingabeRohr;

                        double dDurchmesserAussen;
                        double dDurchmesserInnen;
                        double lLängeRohr;

                        do
                        {
                            do
                            {

                                Console.Clear();
                                Console.WriteLine("Hier kannst du ein Rundprofil berechnen (Eingaben in mm):");
                                Console.WriteLine("        * *             ");
                                Console.WriteLine("    *         *           ");
                                Console.WriteLine("  *              *       ");
                                Console.WriteLine(" *      * *       *    ");
                                Console.WriteLine("*     *--d--*     *   D = Durchmesser Außen ");
                                Console.WriteLine(" *      * *      *    ");
                                Console.WriteLine("   *            *       ");
                                Console.WriteLine("     *       *          ");
                                Console.WriteLine("        * *           ");



                                Console.WriteLine("Durchmesser D:  ");
                                dDurchmesserEingabeAussen = Console.ReadLine();

                                Console.WriteLine("Durchmesser d: ");
                                dDurchmesserEingabeInnen = Console.ReadLine();

                                Console.WriteLine("Länge l:");
                                lLängeEingabeRohr = Console.ReadLine();


                                if ((PrüfungZahl(dDurchmesserEingabeAussen) || PrüfungZahl(lLängeEingabeRohr) || PrüfungZahl(dDurchmesserEingabeInnen)) == false)
                                {
                                    Console.WriteLine("Eigabe ist keine Zahl.(Bestätige mit einer Taste)");
                                }


                            } while ((PrüfungZahl(dDurchmesserEingabeAussen) || PrüfungZahl(lLängeEingabeRohr) || PrüfungZahl(dDurchmesserEingabeInnen)) == false);


                            dDurchmesserInnen = Convert.ToDouble(dDurchmesserEingabeInnen);
                            dDurchmesserAussen = Convert.ToDouble(dDurchmesserEingabeAussen);
                            lLängeRohr = Convert.ToDouble(lLängeEingabeRohr);

                            if (dDurchmesserInnen < 0 || lLängeRohr < 0 || dDurchmesserAussen < 0)
                            {
                                Console.WriteLine("Deine Eingaben müssen größer null sein.(Bestätige mit einer Taste)");
                                Console.ReadKey();
                            }


                        } while (dDurchmesserInnen < 0 || lLängeRohr < 0 || dDurchmesserAussen < 0);
                                 


                        
                        Console.WriteLine("Kreisfläche: " + (Kreisfläche(dDurchmesserAussen) - Kreisfläche(dDurchmesserInnen)) + "mm²");
                        Console.WriteLine("Volumen: " + (Kreisfläche(dDurchmesserAussen) - Kreisfläche(dDurchmesserInnen)) * lLängeRohr + "mm³");
                        Console.WriteLine("Schwerpunkt XY: " + dDurchmesserAussen / 2 + "mm");
                        Console.WriteLine("Schwerpunkt_Länge: " + lLängeRohr / 2 + "mm");
                        Console.WriteLine("Flächenträgheitsmoment: " + IRohr(dDurchmesserAussen, dDurchmesserInnen) + "mm^4");



                        Console.ReadKey();

                        break;
                   //***********************************************************************************************************************************************************************************
                    case 6: // I-Profil 
                        break;


                }
            }


            


        }

       // public static double EingangsprüfungZahlen (double a)       Hier ein Unterprogramm, gucken ob die Zahl positiv ist?
      //  {
            
      //  }

        public static double FlaecheRechteck(double a, double b)
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

        public static double IKreis(double d)
        {
            double I = (Math.PI * Math.Pow(d, 4)) / 64;
            return I;
        }

        public static double Kreisfläche(double d)
        {
            double s = d / 2;
            double A = Math.PI * Math.Pow(s, 2);
            return A;
        }

        public static double IRohr (double D, double d)
        {
            double I = Math.PI * (Math.Pow(D, 4) - Math.Pow(d, 4)) / 64;
            return I;
        }




    }
}
