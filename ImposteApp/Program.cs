using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ImposteApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prima istanza di choice (scelta del menù) e di NuovoContribuente
            int choice;
            Contribuente NuovoContribuente = null;

            // inizio ciclo do-while cosicchè il programma si ripeta finché non si esce o si prema una key diversa
            do
            {
                // MENU OPERAZIONI UTENTE
                Console.WriteLine("================MENU OPERAZIONI UTENTE==============");
                Console.WriteLine("Scegli l'operazione da effettuare:");
                Console.WriteLine("1. Inserisci dati");
                                                         // Il calcolo dell'imposta ora avviene direttamente dopo aver confermato i dati 
                Console.WriteLine("2. Esci");
                Console.WriteLine("========================================");
                
                // Scelta basata dall'input dell'utente:
                choice = Convert.ToInt32(Console.ReadLine()); // valore di choice
                //--------------------------------------------------------------
                // visto che sono solo e opzioni, con if inserisce i dati + costruttore + dopo la conferma dei dati avvia metodo per calcolare l'imposta
                                                   // 2 chiude il programma
                                                   // Con qualsiasi altra key riavvia il programma (do-while)
                if (choice == 1)
                {
                    // Inserimento dei dati Contribuente:
                    Console.WriteLine("\nInserisci nome:");
                    string nome = Console.ReadLine();
                    Console.WriteLine("\nInserisci cognome:");
                    string cognome = Console.ReadLine();
                    //-------------------------------------------------------------------------------
                    // Data di nascita + controllo data nel formato giusto
                    Console.WriteLine("\nInserisci data di nascita (gg/mm/aaaa):");
                    string inputDate = Console.ReadLine();
                    DateTime dataNascita;
                    while (!DateTime.TryParseExact(inputDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascita))
                    {
                        Console.WriteLine("Data non valida, riprova:");
                        inputDate = Console.ReadLine();
                    }
                    //-------------------------------------------------------------------------------
                    // Codice fiscale + controllo sul codice fiscale
                    Console.WriteLine("\nInserisci il tuo codice fiscale:");
                    string codiceFiscale = Console.ReadLine();
                    if (codiceFiscale.Length != 16)
                    {
                        Console.WriteLine("\nIl codice fiscale deve essere di 16 caratteri!\n");
                        Console.WriteLine("Riprova:\n");
                        codiceFiscale = Console.ReadLine();
                    }
                    //-------------------------------------------------------------------------------
                    // Sesso + controllo sul sesso
                    Console.WriteLine("\nInserisci sesso (m/f):");
                    char sesso = Console.ReadKey().KeyChar;
                    if (sesso != 'f' && sesso != 'm') 
                    {
                        Console.WriteLine("\nCarattere non valido.");
                        Console.WriteLine("Riprova:\n");
                        sesso = Console.ReadKey().KeyChar;
                    }
                    // -------------------------------------------------------------------------------
                    Console.WriteLine("\nInserisci il comune di residenza:");
                    string comuneResidenza = Console.ReadLine();
                    //--------------------------------------------------------------------------------
                    // Reddito annuale + controllo che siano numeri
                    Console.WriteLine("\nInserisci il tuo reddito annuale:");
                    double redditoAnnuale;
                    while (!double.TryParse(Console.ReadLine(), out redditoAnnuale))
                    {
                        Console.WriteLine("Inserisci un valore numerico valido.");
                        Console.WriteLine("\nInserisci il tuo reddito annuale:");
                    }
                    //-------------------------------------------------------------------------------
                    // Parte il costruttore:
                    NuovoContribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);
                    //
                    //------------------ RIEPILOGO E CONFERMA DEI DATI --------------------------------------
                    Console.WriteLine("================ RIEPILOGO DATI ==============\n");
                    NuovoContribuente?.Riepilogo(); 
                    // mostra il riepilogo SOLO se NuovoContribuente non è null
                    Console.WriteLine("Confermi i dati inseriti? (y/n)");
                    char conferma = Console.ReadKey().KeyChar;
                    if (conferma == 'n' || conferma == 'N')
                    {
                        Console.WriteLine("\n Il programma verrà riavviato \n");
                        NuovoContribuente = null;
                    }
                    else if (conferma == 'y' || conferma == 'Y')
                    {
                        Console.WriteLine("\nCalcolo dell'imposta in corso...\n");
                        NuovoContribuente?.CalcolaImposta();
                    }
                }
                else
                {
                    Console.WriteLine("\nRiavvio del programma...\n");
                }

            } while (choice != 2); 
            // Continua fino a quando la scelta non è "Esci" (5)
        }
    }
}