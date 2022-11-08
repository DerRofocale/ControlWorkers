using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ControlWorkers.DataBase
{
    /// <copyright>
    /// © Dmitry Yalchik 2022. All rights are protected by the law of the Russian Federation
    /// </copyright>
    public class AppDBContext
    {
        ////public static string ConnectionString = "Host=localhost;Database=Employees;Username=postgres;Password=postgres";

        //public DbSet<User> Users { get; set; }
        //public DBContext()
        //{
        //    Database.EnsureCreated();
        //    if (this.Users.Count() == 0)
        //    {
        //        User admin = new User() { FirstName = "Дмитрий", MiddleName = "Иванович", LastName = "Яльчик", Role = Role.admin, Email = "dmitry_yalchik@mail.ru", PhoneNumber = "79825189800", Password = "11032003Ma" };
        //        this.Users.Add(admin);
        //        this.SaveChanges();
        //    }
        //}

        //// ПОДКЛЮЧЕНИЕ И КОНФИГУРАЦИЯ
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=testDiplom;Username=postgres;Password=postgres");
        //}

        //// СТАНДАРТНОЕ ЗНАЧЕНИЕ
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().Property(u => u.Role).HasDefaultValue(Role.user);
        //}
    }
}
