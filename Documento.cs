using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca_db
{
    internal class Documento
    {

        public string Titolo { get; private set; }
        int anno;
        string settore;
        public bool disponibilità { get; set; }
        public string datoA;
        public string dataRitorno;
        string autore;


        public Documento(string titolo, int anno, string settore, string autore)
        {
            this.Titolo = titolo;
            this.anno = anno;
            this.settore = settore;
            this.autore = autore;
        }

        public string SetInformation()
        {
            return $"Titolo: {Titolo}\nAnno: {anno}\nGenere: {settore}\nDisponibilità : {disponibilità} | preso da: {datoA} | verra restituito: {dataRitorno}\nAutore: {autore}\n\n";
        }
    }
}
