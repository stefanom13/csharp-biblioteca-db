using csharp_biblioteca_db;


List<Prestito> prestiti = new List<Prestito>();
List<Documento> documenti = new List<Documento>();
List<Utente> utenti = new List<Utente>();

documenti.Add(new Libro(85475, 324, "Il bello", 2008, "Romanzo", "Enzo Crudeli"));
documenti.Add(new Dvd(57425, 114, "Micheal Jordan", 2019, "Motivazionale", "Alex Jonh"));
documenti[0].disponibilità = true;
documenti[1].disponibilità = true;


Ospite ospite = new Ospite();
utenti.Add(new Utente("Fredrici", "Michele", "michele@libero.it", "gatto123", "3271563987"));

Console.WriteLine("***** Menù Ospite *****\n\nCosa si vuole fare?\n1 - Registrarsi\n2 - Ricercare documenti\n3 - LogIn\n4 - Ricerca prestiti");
int validator = Int32.Parse(Console.ReadLine());

switch (validator)
{
    case 1:

        Utente utente = ospite.RegistrazioneOspite();
        utenti.Add(utente);
        break;

    case 2:

        Documento documento = SearchInDocuments(documenti);

        break;
    case 3:

        Utente userLogged = LogIn(utenti);
        Thread.Sleep(2000);
        Console.Clear();
        Console.WriteLine("Passare alla sezione Noleggio?\n1 - si\n2 - no");
        validator = Int32.Parse(Console.ReadLine());

        if (validator == 1)
        {
            PrestaUnDocumento(documenti, userLogged);
        }
        break;
    case 4:
         CercaUtentePrestito(prestiti);
        break;
}

void CercaUtentePrestito(List<Prestito> prestiti)
{
    Console.Write("Inserire nome persona che si vuole cercare: ");
    string inputNome = Console.ReadLine();
    Console.Write("Inserire cognome persona che si vuole cercare: ");
    string inputCognome = Console.ReadLine();

    foreach (Prestito prestito in prestiti)
    {
        if (inputNome == prestito.Utente.Nome && inputCognome == prestito.Utente.Cognome)
        {
            Console.Write("nome: {0}\ncognome: {1}\nemail: {2}\ntelephone: {3}\n\n ***** Informazioni documenti *****\n{4}\n", prestito.Utente.Nome, prestito.Utente.Cognome, prestito.Utente.Email, prestito.Utente.Telefono, prestito.Documento.SetInformation());
        }

    }
}

void PrestaUnDocumento(List<Documento> documenti, Utente userLogged)
{
    Console.WriteLine("**** Noleggio documenti ****\n");

    Documento cercaDocumento = SearchInDocuments(documenti);

    if (cercaDocumento.disponibilità)
    {
        Console.WriteLine("\nDocumento disponibile, noleggiarlo?\n1 - si\n2 - no");
        int prestitoValidator = Int32.Parse(Console.ReadLine());
        if (prestitoValidator == 1)
        {
            cercaDocumento.datoA = DateTime.Today.ToShortDateString();

            Console.Write("Inizio prestito del documento: {0} ", cercaDocumento.datoA);

            Console.Write("Fine del prestito (gg/mm/aaaa): ");
            cercaDocumento.dataRitorno = Console.ReadLine();
            Prestito rent = new Prestito(userLogged, cercaDocumento, cercaDocumento.datoA, cercaDocumento.dataRitorno);
            prestiti.Add(rent);

        }
    }
}

Utente LogIn(List<Utente> utenti)
{
    Console.Write("Inserire Username: ");
    string username = Console.ReadLine();
    Console.Write("Inserire Password :");
    string password = Console.ReadLine();
    Console.Clear();
    foreach (Utente utente in utenti)
    {
        if (utente.Username == username && utente.Password == password)
        {

            Console.WriteLine("*** Sei Loggato ***");
            return utente;
        }
        else
        {

            Console.WriteLine("*** Nome o Password non validi ***");
            return null;

        }
    }
    return null;
}

Documento SearchInDocuments(List<Documento> documenti)
{
    Documento documento;
    Console.Write("***** Ricerca documenti *****\n\nCome si vuole cercare il documento?\n1 - codice identificativo\n2 - nome del documento");
    int validator = Int32.Parse(Console.ReadLine());
    switch (validator)
    {
        case 2:

            string nomeDocumento = CercaPerTitolo();
            documento = CercaPerTitoloLibreria(nomeDocumento);
            return documento;

        case 1:

            int codiceDocumento = CercaPerCodice();
            documento = CercaPerCodiceLiberia(codiceDocumento);
            return documento;

    }
    return null;
}

Documento CercaPerCodiceLiberia (int codiceCercato)
{
    foreach (Documento documento in documenti)
    {

        if (documento is Libro)
        {
            Libro libro = (Libro)documento;
            if (codiceCercato == libro.isbnLibro)
            {
                Console.WriteLine(libro.SetInformation());
                return libro;
            }
        }
        else
        {
            Dvd dvd = (Dvd)documento;
            if (codiceCercato == dvd.numeroSerie)
            {
                Console.WriteLine(dvd.SetInformation());
                return dvd;
            }
        }

    }
    return null;
}

Documento CercaPerTitoloLibreria(string parolaCercata)
{
    foreach (Documento documento in documenti)
    {
        if (parolaCercata == documento.Titolo)
        {
            Console.WriteLine(documento.SetInformation());
            return documento;
        }
    }
    return null;
}

int CercaPerCodice()
{
    Console.Write("Cerca per codice: ");
    int codiceCercato = Int32.Parse(Console.ReadLine());
    Console.Clear();
    return codiceCercato;
}

string CercaPerTitolo()
{
    Console.Write("\nInserire il titolo che si vuole cercare: ");
    string titoloCercato = Console.ReadLine();
    Console.Clear();
    return titoloCercato;
}