using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca_db
{
    internal class Ospite
    {
                private static int StoreViews = 1;

        public Ospite()
        {
            Ospite.StoreViews++;
        }


        public Utente RegistrazioneOspite()
        {
            Console.WriteLine("**** Registrazione Utente ****\n");
            string nome = Console.ReadLine();
            Console.Write("Inserire nome: {0}", nome);

            string cognome = Console.ReadLine();
            Console.Write("Inserire cognome: {0}", cognome);

            string email = Console.ReadLine();
            Console.Write("Inserire email: {0}", email);

            string password = Console.ReadLine();
            Console.Write("Inserire password: {0}", password);

            string telefono = Console.ReadLine();
            Console.Write("Inserire telefono: {0}", telefono);

            Utente registrazioneUser = new Utente(nome, cognome, email, password, telefono);

            return registrazioneUser;
        }


        //deve poter eseguire delle ricerche per codice o per titolo e, eventualmente

        public List<Documento>  SearchInDocuments(List<Documento> documenti)
        {
            List<Documento> listaFiltrata= new List<Documento>();
            Console.Write("***** Ricerca documenti *****\n\nCome si vuole cercare il documento?\n1 - codice identificativo\n2 - nome del documento");
            int validator = Int32.Parse(Console.ReadLine());
            switch (validator)
            {
                case 1:
                    string titoloCercato = CercaperTitolo();
                    break; 

                case 2:
                    int codiceDocumento = CercaperCodice();

                    break;

            }
            return documenti;
        }

        // metodi ricerca documento
        public string CercaperTitolo()
        {
            Console.Write("\nInserire il titolo che si vuole cercare: ");
            string titoloCercato = Console.ReadLine();
            Console.Clear();
            return titoloCercato;
        }
        public int CercaperCodice()
        {
            Console.Write("Cerca per codice: ");
            int codiceCercato = Int32.Parse(Console.ReadLine());
            Console.Clear();
            return codiceCercato;
        }
    }
}
