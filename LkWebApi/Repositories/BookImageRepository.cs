using LkWebApi.Models;
using System;
using System.Linq;

namespace LkWebApi.Repositories
{
    /// <summary>
    /// Репозиторий для работы с изображениями обложек
    /// </summary>
    public class BookImageRepository : BaseRepository
    {
        /// <summary>
        /// Добавление информации о изображении
        /// </summary>
        /// <param name="bookImage"></param>
        public void AddImage(BookImage bookImage)
        {
           _dbSet.BookImages.Add(bookImage);
        }

        /// <summary>
        /// Получение информации изображения по идентификатору книги
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public BookImage GetByBookId(Guid bookId)
        {
            return _dbSet.BookImages.FirstOrDefault(bi => bi.BookId == bookId);
        }

    }
}
