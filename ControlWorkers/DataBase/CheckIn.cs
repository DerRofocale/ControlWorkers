using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ControlWorkers.DataBase
{
    /// <copyright>
    /// © Dmitry Yalchik 2022. All rights are protected by the law of the Russian Federation
    /// </copyright>
    public class CheckIn
    {
        // Код регистрации входа
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Дата регистрации входа
        [Required]
        public DateTime DateTimeRegister { get; set; }

        // Код вошедшего пользователя
        [Required]
        public Guid? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
