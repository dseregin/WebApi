using LkWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LkWebApi.Repositories
{
    /// <summary>
    /// Репозиторий для работы с изображениями обложек
    /// </summary>
    public class BookImageRepository
    {
        /// <summary>
        /// Добавление информации о изображении
        /// </summary>
        /// <param name="bookImage"></param>
        public void AddImage(BookImage bookImage)
        {
            DbSet.BookImages.Add(bookImage);
        }

        /// <summary>
        /// Получение информации изображения по идентификатору книги
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public BookImage GetByBookId(Guid bookId)
        {
            return DbSet.BookImages.FirstOrDefault(bi => bi.BookId == bookId);
        }
    }
}
