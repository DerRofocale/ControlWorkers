using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorkers.DataBase
{
    /// <copyright>
    /// © Dmitry Yalchik 2022. All rights are protected by the law of the Russian Federation
    /// </copyright>
    public class CheckIns
    {
        // Код регистрации входа
        public int Id { get; set; }
        // Дата регистрации входа
        public DateTime DateTimeRegister { get; set; }
        // Код вошедшего пользователя
        public int IdUser { get; set; }
        // Виртуальный объект пользователя
        public virtual Users User { get; set; }
    }
}
