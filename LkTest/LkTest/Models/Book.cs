using LkTest.Attributes;
using System.ComponentModel.DataAnnotations;

namespace LkTest.Models
{
    public class Book
    {
        [Required(ErrorMessage = "Не указан заголовок книги")]
        [StringLength(30, ErrorMessage ="Некорректная длина заголовка")]
        public string Head { get; set; }
        //public IEnumerable<Author> Authors {get;set;}
        [Required(ErrorMessage = "Не задано количество страниц")]
        [Range(1, 10000, ErrorMessage = "Недопустимое количество страниц")]
        public int PageCount { get; set; }

        public int PublishYear { get; set; }

        [StringLength(30, ErrorMessage = "Некорректная длина названия издательства")]
        public string PublishingHouse { get; set; }

        [IsbnValidate]
        public string Isbn { get; set; }
    }
}