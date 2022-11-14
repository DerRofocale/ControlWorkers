using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlWorkers.DataBase;
using ControlWorkers.Interfaces;

namespace ControlWorkers.Services.DataBaseServices
{
    public class UserService : ICommonDB<User>
    {
        private readonly AppDBContext db;
        public UserService(AppDBContext _db)
        {
            this.db = _db;
        }

        public bool Add(User model)
        {
            try
            {
                db.Users.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(User model)
        {
            try
            {
                var user = db.Users.Where(x => x.Id == model.Id).FirstOrDefault();
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<User> GetAll()
        {
            try
            {
                return db.Users.ToList();
            }
            catch
            {
                return null;
            }
        }

        public User GetByID(Guid id)
        {
            try
            {
                var user = db.Users.Where(x => x.Id == id).FirstOrDefault();
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(User model)
        {
            try
            {
                var user = db.Users.Where(x => x.Id == model.Id).FirstOrDefault();

                if (user != null)
                {
                    user.Address = model.Address;
                    user.UserPic = model.UserPic;
                    user.IsActivated = model.IsActivated;
                    user.Password = model.Password;
                    user.Email = model.Email;
                    user.FirstName = model.FirstName;
                    user.MiddleName = model.MiddleName;
                    user.LastName = model.LastName;
                    user.PhoneNumber = model.PhoneNumber;
                    user.RoleId = model.RoleId;
                    db.Users.Update(user);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
