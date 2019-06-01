using LkWebApi.Helpers;
using LkWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LkWebApi.Repositories
{

    /// <summary>
    /// Репозиторий для работы с книгами
    /// </summary>
    public class BookRepository : BaseRepository
    {
        /// <summary>
        /// Добавление книги
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            _dbSet.Books.Add(book);
        }

        /// <summary>
        /// Проверка наличия книги по идентификатору
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public bool IsExists(Guid bookId)
        {
            return _dbSet.Books.Any(b => b.Id == bookId);
        }

        /// <summary>
        /// Удаление по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(Guid id)
        {
            var result = false;

            var book = _dbSet.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _dbSet.Books.Remove(book);
                result = true;

                var authorIds = book.Authors.Select(a => a.Id);
                foreach (var authorId in authorIds)
                {
                    var books = FindBooksByAuthorId(authorId);
                    if (!books.Any())
                    {
                        var author = _dbSet.Authors.FirstOrDefault(a => a.Id == authorId);
                        if (author != null)
                        {
                            _dbSet.Authors.Remove(author);
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Получить отсортированный список
        /// </summary>
        /// <param name="sortFilter"></param>
        /// <returns></returns>
        public IEnumerable<Book> SortByFilter(SortFilter sortFilter)
        {
            IEnumerable<Book> result = _dbSet.Books;
            if (sortFilter.SortByHead)
            {
                result = _dbSet.Books.OrderBy(b => b.Head);
            }
            else if (sortFilter.SortByYear)
            {
                result = _dbSet.Books.OrderBy(b => b.PublishYear);
            }
            return result;
        }

        /// <summary>
        /// Поиск книг по автору
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public IEnumerable<Book> FindBooksByAuthorId(Guid authorId)
        {
            return _dbSet.Books.Where(b => b.Authors.Any(a => a.Id == authorId));
        }
    }
}
