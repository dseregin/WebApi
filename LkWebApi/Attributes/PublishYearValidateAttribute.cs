using System;
using System.ComponentModel.DataAnnotations;

namespace LkWebApi.Attributes
{
    /// <summary>
    /// Валидатор года публикации
    /// </summary>
    public class PublishYearValidateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var year = value as int?;
            if (year.HasValue && (year.Value < 1800 || year.Value > DateTime.Now.Year))
                return false;
            return true;
                
        }
    }
}
