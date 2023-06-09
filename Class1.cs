﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class User
    {
        public string Surname { get; set; }
        public string Name { get; set;}
        public string Email { get; set;}
        public string Password { get; set;}
        public string PhoneNumber { get; set;}

        public User(string surname, string name, string email, string password, string phoneNumber)
        {
            Surname = surname;
            Name = name;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
        }

        public void Print()
        {
            Console.WriteLine($"Nome: {Name}, Cognome: {Surname}, Email: {Email}, Numero di telefono: {PhoneNumber}");
        }
    }

    public class Document
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public uint Year { get; set; }
        public string Section { get; set; }
        public string Shelf { get; set; }
        public string Author { get; set; }

        public Document(string id, string title, uint year, string section, string shelf, string author)
        {
            Id = id;
            Title = title;
            Year = year;
            Section = section;
            Shelf = shelf;
            Author = author;
        }

        public virtual void Print()
        {
            Console.Write($"Titolo: {Title}, Id: {Id}, Anno: {Year}, Sezione: {Section}, Scaffale: {Shelf}, Autore: {Author}");
        }
    }

    public class Book : Document
    {
        public uint NumberPages { get; set; }

        public Book(string id, string title, uint year, string section, string shelf, string author, uint numberPages) : base(id, title, year, section, shelf, author)
        {
            NumberPages = numberPages;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($", Pagine: {NumberPages}");
        }
    }

    public class Dvd : Document
    {
        public uint Minutes { get; set; }

        public Dvd(string id, string title, uint year, string section, string shelf, string author, uint minutes) : base(id, title, year, section, shelf, author)
        {
            Minutes = minutes;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($", Durata: {Minutes}m");
        }
    }

    public class Loan
    {
        public User User { get; set; }
        public Document Document { get; set; }
        public string TimeSpan { get; set; }

        public Loan(User user, Document document)
        {
            User = user;
            Document = document;
            TimeSpan = "una settimana da ora";
        }

        public void Print()
        {
            Console.WriteLine($"Utente: {User.Name} {User.Surname}, Id documento: {Document.Id}, Periodo prestito: {TimeSpan}");
        }
    }

    public class Library
    {
        public List<Document> Documents { get; private set; }
        public List<User> Users { get; private set; }

        public List<Loan> Loans { get; private set; }

        public Library (List<Document> documents, List<User> users)
        {
            Documents = documents;
            Users = users;
            Loans = new List<Loan>();
        }

        public void Add (User user)
        {
            Users.Add(user);
        }
        public void Add(Loan loan)
        {
            Loans.Add(loan);
        }
        public void Add(Document document)
        {
            Documents.Add(document);
        }

        public IEnumerable<Loan> SearchLoan(string name, string surname)
        {
            return Loans.Where(loan => loan.User.Name == name).Where(loan => loan.User.Surname == surname);
        }
        public IEnumerable<User> SearchUser(string name, string surname)
        {
            return Users.Where(user => user.Name == name).Where(user => user.Surname == surname);
        }
        public IEnumerable<Document> SearchDocument(string Id, string name)
        {
            IEnumerable<Document> decumentFilterd;
            decumentFilterd = Documents.Where(book  => book.Id == Id).Where(book => book.Title == name);
            if (decumentFilterd.Any())
            {
                return decumentFilterd;
            }
            decumentFilterd = Documents.Where(document => document.Id == Id).Union(Documents.Where(document => document.Title == name));
            if (decumentFilterd.Any())
            {
                return decumentFilterd;
            }

            return default;
        }

        public void Print()
        {
            Console.WriteLine("Users:");
            foreach (User user in Users)
            {
                user.Print();
            }
            Console.WriteLine("Libri:");
            foreach (Document doc in Documents)
            {
                doc.Print();
            }
            Console.WriteLine("Prestiti:");
            foreach (Loan loan in Loans)
            {
                loan.Print();
            }
        }
    }
}
