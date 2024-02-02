using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImposteApp
{
    internal class Contribuente
    {
        // DEVE AVERE LE CLASSI
        //Nome, Cognome, DataNascita, CodiceFiscale, Sesso, ComuneResidenza, RedditoAnnuale
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string CodiceFiscale { get; set; }   
        public char Sesso { get; set; }   
        public string ComuneResidenza { get; set; } 
        public double RedditoAnnuale { get; set; }
        private double Imposta {  get; set; }


        // Costruttore Contribuente:
        public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, char sesso, string comuneResidenza, double redditoAnnuale)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
        }
        // Metodi:
        // Riepilogo dati che apparirà nel menù utente dopo l'inserimento dei dati per la conferma:
        public void Riepilogo()
        {
            Console.WriteLine($"Contribuente:\t\t\t{Nome} {Cognome}");
            Console.WriteLine($"Nato il:\t{DataNascita.ToShortDateString()} ({Sesso})");
            Console.WriteLine($"Residente in:\t{ComuneResidenza}");
            Console.WriteLine($"Codice Fiscale:\t\t{CodiceFiscale}");
            Console.WriteLine($"Reddito dichiarato:\t {RedditoAnnuale}");
        }

        // Calcolo imposta:
        // switch su dato RedditoAnnuale 
        // ritorna un double (imposta)
        public double CalcolaImposta()
        {
            Console.WriteLine("================ CALCOLO IMPOSTA ============== \n");

            switch (RedditoAnnuale)
            {
                case double reddito when reddito <= 15000:
                    Imposta = reddito * 0.23;
                    break;

                case double reddito when reddito <= 28000:
                    Imposta = 3450 + (reddito - 15000) * 0.27;
                    break;

                case double reddito when reddito <= 55000:
                    Imposta = 6960 + (reddito - 28000) * 0.38;
                    break;

                case double reddito when reddito <= 75000:
                    Imposta = 17220 + (reddito - 55000) * 0.41;
                    break;

                default:
                    Imposta = 25420 + (RedditoAnnuale - 75000) * 0.43;
                    break;
            }

            RecapImposta();
            return Imposta;
        }

        // Recap Imposta
        // Al riepilogo aggiunge il nuovo dato imposta
        public void RecapImposta() {
            Console.WriteLine("================ CALCOLO IMPOSTA ============== \n");
            Riepilogo();
            Console.WriteLine($"IMPOSTA DA VERSARE: \t{Imposta}");
            Console.WriteLine("\n\n");

        }
    }
}
