using csharp_biblioteca;

Library library = new Library
    (
        new List<Book>
        {
        new Book("00000", "Il Signore degli Anelli", 1955, "Fantasy", "A5", "J. R. R. Tolkien", 1000),
        new Book("00001", "Io, Robot", 1950, "Fantascientifico", "G7", "Isaac Asimov", 200),
        new Book("00002", "10 Piccoli Indiani", 1939, "Giallo", "E9", "Agatha Christie", 250),
        new Book("00003", "Frankestein", 1818, "Horror", "S4", "Mary Shelley", 150),
        new Book("00004", "Le Avventure di Pinoccgio", 1883, "Per l'infanzia", "Z2", "Carlo Collodi", 500),
        },
        new List<Dvd>
        {
        new Dvd("00005", "La Storia Infinita", 1984, "Fantasy", "A1", "Producers Sales Organization", 97),
        new Dvd("00006", "Star Wars", 1977, "Fantascientifico", "G9", "Lucasfilms", 121),
        new Dvd("00007", "L'ultima notte di Amore", 2023, "Giallo", "E5", "Indiana Production", 124),
        new Dvd("00008", "Babadook", 2014, "Horror", "S8", "Causeway Films", 94),
        new Dvd("00009", "Super Mario Movie", 2023, "Per l'infanzia", "Z6", "Illumination Entertainment", 92),
        },
        new List<User>
        {
        new User("Rossi", "Mario", "ab@cd.com", "password", "3333333333"),
        new User("Bianchi", "Dottor", "ef@gh.com", "12345", "3334445555"),
        new User("Rota", "Maria", "ij@kl.com", "00000000", "3391011123"),
        new User("Esposito", "Salvatore", "mn@op.com", "password123", "3934445566"),
        new User("Verdi", "Lucia", "qr@st.com", "6543210", "3993333333"),
        }
    );

//library.Print();

User? activeUser = null;
string? controller;

do
{
    Console.WriteLine("Sei registrato? (S/N). Invio per uscire");

    controller = Console.ReadLine();
    if (controller == "S")
    {
        Console.WriteLine("Inserisci la tua email per accedere. Invio per tornare indietro");
        string inputMail;
        User? user;
        do
        {
            inputMail = Console.ReadLine();
            user = library.Users.Find(x => x.Email == inputMail);
            if(user == null && inputMail != "")
                Console.WriteLine("Email non trovata. Riprovare o premere invio per tornare indietro");
        } while (inputMail != "" && user == null);
        if(user != null)
        {
            Console.WriteLine("Inserisci la password");
            if (user.Password == Console.ReadLine())
            {
                activeUser = user;
                Console.WriteLine($"Benvenut* {activeUser.Name} {activeUser.Surname}");
            }
            else
            {
                Console.WriteLine("Password errata");
            }
        }
    }
    else
    {
        Console.WriteLine("Inserisci i tuoi dati per registrarti");
        string? name = null;
        string? surname = null;
        string? email = null;
        string? password = null;
        string? number = null;
        Console.WriteLine("Nome:");
        while (name == null)
            name = Console.ReadLine();
        Console.WriteLine("Cognome:");
        while (surname == null)
            surname = Console.ReadLine();
        Console.WriteLine("Email:");
        while (email == null)
            email = Console.ReadLine();
        Console.WriteLine("Password:");
        while (password == null)
            password = Console.ReadLine();
        Console.WriteLine("Numero di telefono:");
        while (number == null)
            number = Console.ReadLine();
        User newUser = new User(surname, name, email, password, number);
        activeUser = newUser;
        library.Users.Add(activeUser);
        Console.WriteLine("Registrato!");
    }
} while (activeUser == null && controller != "");


library.Print();