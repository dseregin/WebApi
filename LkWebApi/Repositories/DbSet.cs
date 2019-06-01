using LkWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LkWebApi.Repositories
{
    /// <summary>
    /// Хранилище данных в памяти
    /// </summary>
    public static class DbSet
    {
        public static List<Book> Books = new List<Book> { new Book { Id = Guid.Parse("B6CE0749-D215-4974-890B-6E70F5588824"), Head = "Структуры данных и алгоритмы", PageCount = 64, PublishYear = 2016, PublishingHouse = "НГТУ", Isbn = "978-5-7782-2958-7" } };
        public static List<BookImage> BookImages = new List<BookImage> { new BookImage { BookId = Guid.Parse("B6CE0749-D215-4974-890B-6E70F5588824"), FileName = "BookImage1.png" } };
    }
}
