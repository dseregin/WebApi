using LkWebApi.Models;
using System;
using System.Linq;

namespace LkWebApi.Repositories
{

    /// <summary>
    /// Репозиторий для работы с книгами
    /// </summary>
    public class BookRepository
    {
        /// <summary>
        /// Добавление книги
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            DbSet.Books.Add(book);
        }

        /// <summary>
        /// Проверка наличия книги по идентификатору
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public bool IsExists(Guid bookId)
        {
            return DbSet.Books.Any(b => b.Id == bookId);
        }
    }
}
