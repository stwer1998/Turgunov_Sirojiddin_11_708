using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Если есть пользователь с таким Login и Password то вернет true
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool GetOrganaizer(string login, string password);
        /// <summary>
        /// Добавления пользователя в базу данных
        /// </summary>
        /// <param name="organizer"></param>
        void AddOrganaizer(Organizer organizer);
        /// <summary>
        /// Проверякт есть ли пользователь таким логином если есть вернет true
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        bool GetLogin(string login);
    }
}
