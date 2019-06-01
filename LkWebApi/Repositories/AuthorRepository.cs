using LkWebApi.Models;
using System;
using System.Linq;

namespace LkWebApi.Repositories
{
    /// <summary>
    /// Репозиторий для работы с авторами
    /// </summary>
    public class AuthorRepository : BaseRepository
    {
        /// <summary>
        /// Проверка надичия автора в множестве по имени и фамилии
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <returns></returns>
        public Author GetAuthorByFio(string firstName, string secondName)
        {
            return _dbSet.Authors.FirstOrDefault(a => a.FirstName.ToUpper() == firstName.ToUpper() && a.SecondName.ToUpper() == secondName.ToUpper());
        }

        /// <summary>
        /// Добавление автора
        /// </summary>
        /// <param name="author"></param>
        public void Add(Author author)
        {
            _dbSet.Authors.Add(author);
        }
    }
}
