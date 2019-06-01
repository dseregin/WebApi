using LkWebApi.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LkWebApi.Models
{
    public class Book
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        [Required(ErrorMessage = "Не указан заголовок книги")]
        [StringLength(30, ErrorMessage ="Некорректная длина заголовка")]
        public string Head { get; set; }

        /// <summary>
        /// Список авторов
        /// </summary>
        [AuthorListValidate]
        public IEnumerable<Author> Authors {get;set;}

        /// <summary>
        /// Количество страниц
        /// </summary>
        [Required(ErrorMessage = "Не задано количество страниц")]
        [Range(1, 10000, ErrorMessage = "Недопустимое количество страниц")]
        public int PageCount { get; set; }

        /// <summary>
        /// Год публикации
        /// </summary>
        [PublishYearValidate(ErrorMessage ="Некорректный год публикацц")]
        public int? PublishYear { get; set; }


        /// <summary>
        /// Издательтсво
        /// </summary>
        [StringLength(30, ErrorMessage = "Некорректная длина названия издательства")]
        public string PublishingHouse { get; set; }


        /// <summary>
        /// ISBN
        /// </summary>
        [IsbnValidate]
        public string Isbn { get; set; }
    }
}