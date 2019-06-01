using LkWebApi.Repositories;

namespace LkWebApi.BookService
{
    public partial class BookService
    {
        private BookRepository _bookRepository;
        private BookImageRepository _bookImageRepository;
        private AuthorRepository _authorRepository;

        public BookService(
            BookRepository bookRepository,
            BookImageRepository bookImageRepository,
            AuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _bookImageRepository = bookImageRepository;
            _authorRepository = authorRepository;
        }
    }
}
