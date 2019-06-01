using LkWebApi.Models;

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
    }
}
