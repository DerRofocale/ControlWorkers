using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostAPI.Models
{
    public class User
    {
        // Код пользователя
        //[Required]
        //[Key]
        public Guid Id { get; set; }

        // Роль пользователя
        //[Required]
        //[ConcurrencyCheck]
        public int? RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }


        // Изображение пользователя
        //[ConcurrencyCheck]
        public byte[]? UserPic { get; set; }

        // Имя пользователя
        //[Required]
        //[ConcurrencyCheck]
        public string FirstName { get; set; }

        // Отчество пользователя
        //[ConcurrencyCheck]
        public string? MiddleName { get; set; }

        // Фамилия пользователя
        //[ConcurrencyCheck]
        //[Required]
        public string LastName { get; set; }

        // Телефонный номер пользователя
        //[ConcurrencyCheck]
        //[Required]
        public string PhoneNumber { get; set; }

        // Электронная почта пользователя
        //[ConcurrencyCheck]
        //[Required]
        public string Email { get; set; }

        // Адрес пользователя
        public string? Address { get; set; }

        // Пароль пользователя
        //[ConcurrencyCheck]
        //[Required]
        public string Password { get; set; }

        //Активирован ли аккаунт
        //[ConcurrencyCheck]
        //[Required]
        public bool IsActivated { get; set; }
    }
}
