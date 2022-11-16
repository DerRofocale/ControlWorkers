using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Resources;
using ControlWorkers.Services;
using Microsoft.EntityFrameworkCore;

namespace ControlWorkers.DataBase
{
    /// <copyright>
    /// © Dmitry Yalchik 2022. All rights are protected by the law of the Russian Federation
    /// </copyright>
    public class AppDBContext : DbContext
    {
        /// <summary>
        /// public static string ConnectionString = "Host=localhost;Database=Employees;Username=postgres;Password=postgres";
        /// </summary>

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        /// <summary>
        /// Add-Migration [Name] -verbose
        /// Update-Database // ПРИ ОТСУТСТВИИ РЕЗУЛЬТАТА ПЕРВЫМ МЕТОДОМ
        /// </summary>
        public AppDBContext()
        {

            if (this.Users.Count() == 0 && this.Roles.Count() == 0)
            {
                Role adminRole = new Role() { Name = "Администратор" };
                this.Roles.Add(adminRole);

                var assembly = System.Reflection.Assembly.GetExecutingAssembly();



                User adminUser = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Дмитрий",
                    MiddleName = "Иванович",
                    LastName = "Яльчик",
                    Role = adminRole,
                    Email = "dmitry_yalchik@mail.ru",
                    PhoneNumber = "79825189800",
                    Password = SHA256Service.ConvertToSHA256("11032003Ma"),
                    IsActivated = true
                };
                this.Users.Add(adminUser);

                this.SaveChanges();
            }
        }

        // ПОДКЛЮЧЕНИЕ И КОНФИГУРАЦИЯ
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string _currentDBHost = RegistryService.GetRegistryKeySettings("DBHost");
            string _currentDBPort = RegistryService.GetRegistryKeySettings("DBPort");
            string _currentDBName = RegistryService.GetRegistryKeySettings("DBName");
            string _currentDBUser = RegistryService.GetRegistryKeySettings("DBUser");
            string _currentDBPassword = RegistryService.GetRegistryKeySettings("DBPassword");
            optionsBuilder.UseNpgsql($"Host={_currentDBHost};Port={_currentDBPort};Database={_currentDBName};Username={_currentDBUser};Password={_currentDBPassword}");
        }

        // СТАНДАРТНОЕ ЗНАЧЕНИЕ
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().Property(u => u.Role).HasDefaultValue("1");
            modelBuilder.Entity<User>().Property(u => u.IsActivated).HasDefaultValue(false);
        }
    }
}
