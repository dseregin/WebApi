using LkWebApi.Helpers;
using LkWebApi.Models;
using System;
using System.Collections.Generic;

namespace LkWebApi.BookService
{
    public partial class BookService
    {
        public void AddBook(Book book)
        {
            foreach (var author in book.Authors)
            {
                var existedAuthor = GetAuthorByFio(author.FirstName, author.SecondName);
                if (existedAuthor == null)
                {
                    if (author.Id == Guid.Empty)
                        author.Id = Guid.NewGuid();

                    AddAuthor(author);
                }
                else
                {
                    author.Id = existedAuthor.Id;
                }
            }

            if (book.Id == Guid.Empty)
                book.Id = Guid.NewGuid();

            _bookRepository.AddBook(book);
        }

        public bool IsExistBook(Guid bookId)
        {
            return _bookRepository.IsExists(bookId);
        }

        public bool DeleteBookById(Guid bookId)
        {
            return _bookRepository.DeleteById(bookId);
        }

        public IEnumerable<Book> SortBookByFilter(SortFilter sortFilter)
        {
            return _bookRepository.SortByFilter(sortFilter);
        }
    }
}
