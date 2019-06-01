using LkWebApi.Models;

namespace LkWebApi.BookService
{
    public partial class BookService
    {
        public void AddImage(BookImage bookImage)
        {
            _bookImageRepository.AddImage(bookImage);
        }
    }
}
