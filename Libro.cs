using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca_db
{
    internal class Libro : Documento
    {
        public int isbnLibro;
        int pagineLibro;

        public Libro(int isbnLibro, int pagineLibro, string titolo, int anno, string settore, string autore) : base(titolo, anno, settore, autore)
        {
            this.isbnLibro = isbnLibro;
            this.pagineLibro = pagineLibro;
        }

        public Libro(string titolo, int anno, string settore, string autore) : base(titolo, anno, settore, autore) { }
    }
}
