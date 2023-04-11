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
    }

    public class Document
    {
        public string Id { get; protected set; }
        public string Title { get; protected set; }
        public uint Year { get; protected set; }
        public string Section { get; protected set; }
        public string Shelf { get; protected set; }
        public string Author { get; protected set; }

        public Document(string id, string title, uint year, string section, string shelf, string author)
        {
            Id = id;
            Title = title;
            Year = year;
            Section = section;
            Shelf = shelf;
            Author = author;
        }
    }

    public class Book : Document
    {
        public uint NumberPages { get; protected set; }

        public Book(string id, string title, uint year, string section, string shelf, string author, uint numberPages) : base(id, title, year, section, shelf, author)
        {
            NumberPages = numberPages;
        }
    }

    public class Dvd : Document
    {
        public uint Minutes { get; protected set; }

        public Dvd(string id, string title, uint year, string section, string shelf, string author, uint minutes) : base(id, title, year, section, shelf, author)
        {
            Minutes = minutes;
        }
    }

    public class Loan
    {
        public User User { get; set; }
        public Document Document { get; set; }
        public string TimeSpan { get; set; }

        public Loan(User user, Document document, string timeSpan)
        {
            User = user;
            Document = document;
            TimeSpan = timeSpan;
        }
    }

    public class Library
    {
        public List<Book> Books { get; private set; }
        public List<Dvd> Dvd { get; private set; }
        public List<User> Users { get; private set; }

        public List<Loan> Loans { get; private set; }

        public Library (List<Book> books, List<Dvd> dvd, List<User> users)
        {
            Books = books;
            Dvd = dvd;
            Users = users;
        }
    }
}
