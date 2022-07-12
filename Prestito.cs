using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca_db
{
    internal class Prestito
    {
        public Utente Utente { get; private set; }
        public Documento Documento { get; private set; }

        string inizioPrestito;
        string finePrestito;

        public Prestito(Utente utente, Documento documento, string inizioPrestito, string finePrestito)
        {
            this.Utente = utente;
            this.Documento = documento;
            this.finePrestito = finePrestito;
            this.inizioPrestito = inizioPrestito;
        }
    }
}
