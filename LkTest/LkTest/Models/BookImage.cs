using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LkTest.Models
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
    }
}