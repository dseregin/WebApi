using LkWebApi.Models;
using System;
using System.Collections.Generic;

namespace LkWebApi.Repositories
{
    /// <summary>
    /// Хранилище данных в памяти
    /// </summary>
    public class DbSet
    {
        public List<Book> Books = new List<Book> { new Book { Id = Guid.Parse("B6CE0749-D215-4974-890B-6E70F5588824"), Head = "Структуры данных и алгоритмы", PageCount = 64, PublishYear = 2016, PublishingHouse = "НГТУ", Isbn = "978-5-7782-2958-7", Authors = new List<Author> { new Author { Id = Guid.Parse("27CBF2B3-E345-466C-9469-4542D08E9366"), FirstName = "Виктор", SecondName = "Хиценко" } } } };
        public List<BookImage> BookImages = new List<BookImage>();
        public List<Author> Authors = new List<Author> { new Author { Id = Guid.Parse("27CBF2B3-E345-466C-9469-4542D08E9366"), FirstName = "Виктор", SecondName = "Хиценко" } };
    }
}
