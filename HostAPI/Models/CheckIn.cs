using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostAPI.Models
{
    public class CheckIn
    {
        //[Required]
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Дата регистрации входа
        //[Required]
        public DateTime DateTimeRegister { get; set; }

        // Дата регистрации входа
        //[Required]
        public string IPAdress { get; set; }

        // Код вошедшего пользователя
        //[Required]
        public Guid? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
