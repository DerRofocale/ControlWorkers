using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostAPI.Models
{
    public class Role
    {
        // Код роли
        //[Required]
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Название роли
        //[Required]
        public string Name { get; set; }
    }
}
