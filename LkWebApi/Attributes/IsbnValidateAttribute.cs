using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LkWebApi.Attributes
{
    /// <summary>
    /// Валидатор корректности ISBN
    /// </summary>
    public class IsbnValidateAttribute : ValidationAttribute
    {
        private const string _pattern = @"^(978\-)?(\d+\-\d+\-\d+\-\d{1})$";
        private const int _isbn10Length = 13;
        private const int _isbn13Length = 17;
        public override bool IsValid(object value)
        {
            if (!(value is string strValue)) return false;

            if (Regex.IsMatch(strValue, _pattern) && (strValue.Length == _isbn10Length || strValue.Length == _isbn13Length))
            {
                if (strValue.Length == _isbn10Length)
                    return ValidIsbn10(strValue.Replace("-", ""));
                if (strValue.Length == _isbn13Length)
                    return ValidIsbn13(strValue.Replace("-", ""));
            }
            return false;
        }

        private bool ValidIsbn10(string isbn10)
        {
            int s = 0, t = 0;

            foreach(var digit in isbn10)
            {
                t += (int)char.GetNumericValue(digit);
                s += t;
            }
            return s % 11 == 0;
        }

        private bool ValidIsbn13(string isbn13)
        {
            var s = 0;
            for (int i = 0; i < isbn13.Length; i++)
            {
                if (i % 2 == 0)
                    s += (int)char.GetNumericValue(isbn13[i]);
                else
                    s += 3 * (int)char.GetNumericValue(isbn13[i]);
            }
            return s % 10 == 0;
        }
    }
}