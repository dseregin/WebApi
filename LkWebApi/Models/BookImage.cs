using System;

namespace LkWebApi.Models
{
    public class BookImage
    {
        /// <summary>
        /// Идентификатор книги
        /// </summary>
        public Guid BookId { get; set; }

        /// <summary>
        /// Название файла
        /// </summary>
        public string FileName { get; set; }
        
        /// <summary>
        /// Каталог
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Файл
        /// </summary>
        public byte[] Data { get; set; }
    }
}