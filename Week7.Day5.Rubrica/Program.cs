using System;
using Week7.Day5.Rubrica.Core.BusinessLayer;
using Week7.Day5.Rubrica.Core.Entities;
using Week7.Day5.Rubrica.RepositoryEF.RepositoryEF;
using Week7.Day5.Rubrica.RepositoryMock.RepositoryMock;

namespace Week7.Day5.Rubrica
{
    public class Program
    {
    
        // private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiMock(), new RepositoryIndirizziMock());
          private static readonly IBusinessLayer bl = new MainBusinessLayer(new ContattoRepositoryEF(), new IndirizzoRepositoryEF());
        static void Main(string[] args)
        {
            bool continua = true;
            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }
        #region Interazione con l'utente
        private static int SchermoMenu()
        {
            Console.WriteLine("******************Menu****************");
            //Funzionalità su Corsi
            Console.WriteLine("\nFunzionalità Rubrica");
            Console.WriteLine("1. Visualizza tutti i contatti.");
            Console.WriteLine("2. Aggiungi un nuovo contatto.");
            Console.WriteLine("3. Aggiungi un indirizzo.");//Chiedi prima il contatto
            Console.WriteLine("4. Elimina contatto.");//solo se non ha un indirizzo associato

            //Exit
            Console.WriteLine("\n0. Exit");
            Console.WriteLine("********************************************");

            int scelta;
            Console.Write("Inserisci scelta: ");
            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 4)
            {
                Console.Write("\nScelta errata. Inserisci scelta corretta: ");
            }
            return scelta;
        }
        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    VisualizzaContatti();
                    break;
                case 2:
                 InserisciNuovoContatto();
                    break;
                case 3:
                 AggiungiIndirizzo(); //A un contatto esistente
                    break;
                case 4:
                    EliminaContatto();   //solo se non ha un indirizzo
                    break;        
                case 0:
                    return false;
            }
            return true;
        }

       

      
        #endregion



        #region Funzioni
        private static bool VisualizzaContatti()
        {
            var contatti = bl.GetAllContatti();
            if (contatti.Count == 0)
            {
                Console.WriteLine("Nessun contatto presente in rubrica.");
                return false;
            }
            else
            {
                Console.WriteLine("Lista dei contatti presenti in rubrica.");
                foreach (var item in contatti)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("Indirizzo:");

                    //Stampa indirizzo
                    if (item.Indirizzi.Count != 0)
                    {
                        foreach (var ind in item.Indirizzi)
                        {
                            Console.WriteLine(ind);
                        }
                    }
                    else Console.WriteLine("Nessun indirizzo registrato.");
                }
                return true;
            }
        }
        private static void InserisciNuovoContatto()
        {
            //Chiedo le info per creare il nuovo contatto
            Console.WriteLine("Inserisci nome");
            string nome = Console.ReadLine();
            while (string.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Errore. Devi inserire una stringa con almeno un carattere");
                nome = Console.ReadLine();
            }
            Console.WriteLine("Inserisci cognome");
            string cognome = Console.ReadLine();
            while (string.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Errore. Devi inserire una stringa con almeno un carattere");
                cognome = Console.ReadLine();
            }

            //lo creo
            Contatto nuovoContatto = new Contatto();
            nuovoContatto.Nome = nome;
            nuovoContatto.Cognome = cognome;

            //lo passo al bl
            var esito = bl.InserisciNuovoContatto(nuovoContatto);
            Console.WriteLine(esito);
        }
        private static void AggiungiIndirizzo()
        {
            //Visualizzo i contatti in rubrica
            bool rubricaPiena =VisualizzaContatti();
            if (rubricaPiena)
            {
                Console.WriteLine("Inserisci l'ID del contatto a cui vuoi aggiungere l'indirizzo.");
                int idContatto;
                while (!int.TryParse(Console.ReadLine(), out idContatto) || bl.GetAllContatti().Find(c => c.ID == idContatto) == null)
                {
                    Console.WriteLine("Errore. Inserisci il numero ID di un contatto della lista.");
                }

                //Chiedo le info per creare il nuovo indirizzo

                Console.WriteLine("Inserisci la tipologia (ad es. 'Domicilio' o 'Residenza').");
                string tipologia = Console.ReadLine();
                while (string.IsNullOrEmpty(tipologia))
                {
                    Console.WriteLine("Errore. Devi inserire una stringa con almeno un carattere");
                    tipologia = Console.ReadLine();
                }
                Console.WriteLine("Inserisci la via.");
                string via = Console.ReadLine();
                while (string.IsNullOrEmpty(via))
                {
                    Console.WriteLine("Errore. Devi inserire una stringa con almeno un carattere");
                    via = Console.ReadLine();
                }
                Console.WriteLine("Inserisci la città.");
                string città = Console.ReadLine();
                while (string.IsNullOrEmpty(città))
                {
                    Console.WriteLine("Errore. Devi inserire una stringa con almeno un carattere");
                    città = Console.ReadLine();
                }
                Console.WriteLine("Inserisci il CAP.");
                int cap;
                while (!int.TryParse(Console.ReadLine(), out cap) || cap < 0)
                {
                    Console.WriteLine("Errore. Inserisci un numero maggiore di zero.");
                }
                Console.WriteLine("Inserisci la provincia.");
                string provincia = Console.ReadLine();
                while (string.IsNullOrEmpty(provincia))
                {
                    Console.WriteLine("Errore. Devi inserire una stringa con almeno un carattere");
                    provincia = Console.ReadLine();
                }
                Console.WriteLine("Inserisci la nazione.");
                string nazione = Console.ReadLine();
                while (string.IsNullOrEmpty(nazione))
                {
                    Console.WriteLine("Errore. Devi inserire una stringa con almeno un carattere");
                    nazione = Console.ReadLine();
                }


                //Creo l'indirizzo
                Indirizzo nuovoIndirizzo = new Indirizzo();
                nuovoIndirizzo.Tipologia = tipologia;
                nuovoIndirizzo.Via = via;
                nuovoIndirizzo.Città = città;
                nuovoIndirizzo.Cap = cap;
                nuovoIndirizzo.Provincia = provincia;
                nuovoIndirizzo.Nazione = nazione;
                nuovoIndirizzo.ContattoId = idContatto;


                //lo passo al bl
                var esito = bl.InserisciNuovoIndirizzo(nuovoIndirizzo);
                Console.WriteLine(esito);
            }
            else Console.Write("");
        }
        private static void EliminaContatto()
        {
           
            bool rubricaPiena= VisualizzaContatti();
            if (rubricaPiena)
            {
                Console.WriteLine("Quale contatto vuoi eliminare? Inserisci il codice Id");
                int sceltaId;
                while (!int.TryParse(Console.ReadLine(), out sceltaId) || bl.GetAllContatti().Find(c => c.ID == sceltaId) == null)
                {
                    Console.WriteLine("Errore. Inserisci il numero ID di un contatto della lista.");
                }
                string esito = bl.EliminaContatto(sceltaId);
                Console.WriteLine(esito);
            }
            else Console.Write("");
        }
        #endregion
    }
}

