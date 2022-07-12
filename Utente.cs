using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace csharp_biblioteca_db
{
    internal class Utente : Ospite
    {
        public string Cognome { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Telefono { get; private set; }
        public string Username { get; private set; }


        public Utente(string cognome, string nome, string email, string password, string telefono) : base()
        {
            this.Cognome = cognome;
            this.Nome = nome;
            this.Email = email;
            this.Password = password;
            this.Telefono = telefono;
            this.Username = cognome + nome;

        }
    }
}
