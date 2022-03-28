using System;

namespace Lab6.Model
{
    internal class Book
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Author { get; set; }
        int Pages { get; set; }
        string Description { get; set; }

        public Book(Guid id, string name, string author, int pages, string description)
        {
            Id = id;
            Name = name;
            Author = author;
            Pages = pages;
            Description = description;

        }
    }
}
