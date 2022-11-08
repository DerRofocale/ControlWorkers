using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ControlWorkers.DataBase
{
    /// <copyright>
    /// © Dmitry Yalchik 2022. All rights are protected by the law of the Russian Federation
    /// </copyright>
    public class User
    {
        // Код пользователя
        public Guid Id { get; set; }
        // Роль пользователя
        public Role Role { get; set; }
        // Изображение пользователя
        public byte[]? UserPic{ get; set; }
        // Имя пользователя
        public string FirstName { get; set; }
        // Отчество пользователя
        public string? MiddleName { get; set; }
        // Фамилия пользователя
        public string LastName { get; set; }
        // Телефонный номер пользователя
        public string PhoneNumber { get; set; }
        // Электронная почта пользователя
        public string Email { get; set; }
        // Адрес пользователя
        public string? Address { get; set; }
        // Пароль пользователя
        public string Password { get; set; }
    }
}
