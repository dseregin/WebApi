using System;
using System.ComponentModel.DataAnnotations;

namespace LkWebApi.Models
{
    public class Author
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Required(ErrorMessage = "Не указано имя автора")]
        [StringLength(20, ErrorMessage ="Некорректная длина имени автора")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required(ErrorMessage ="Не указана фамилия автора")]
        [StringLength(20, ErrorMessage ="Некорректная длина фамилии автора")]
        public string SecondName { get; set; }
    }
}
