using LkWebApi.Models;

namespace LkWebApi.BookService
{
    public partial class BookService
    {
        public Author GetAuthorByFio(string firstName, string secondName)
        {
            return _authorRepository.GetAuthorByFio(firstName, secondName);
        }

        public void AddAuthor(Author author)
        {
            _authorRepository.Add(author);
        }
    }
}
