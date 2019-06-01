using LkWebApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LkWebApi.Attributes
{
    /// <summary>
    /// Валидатор количества авторов у книги
    /// </summary>
    public class AuthorListValidateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (!(value is IEnumerable<Author> authorList) || !authorList.Any())
                return false;
            return true;
        }
    }
}
