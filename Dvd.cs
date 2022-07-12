using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca_db
{
    internal class Dvd : Documento
    {

        public int numeroSerie;
        int durataFilm;

        public Dvd(int numeroSerie, int durataFilm, string titolo, int anno, string settore, string autore) : base(titolo, anno, settore, autore)
        {
            this.numeroSerie = numeroSerie;
            this.durataFilm = durataFilm;
        }

        public Dvd(string titolo, int anno, string settore, string autore) : base(titolo, anno, settore, autore) { }
    }
}
