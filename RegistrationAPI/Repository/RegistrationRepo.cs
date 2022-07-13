using Microsoft.EntityFrameworkCore;
using RegistrationAPI.ProductRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationAPI.Repository
{
    public class RegistrationRepo : IRegRepo
    {
        private readonly ProductRentalContext db;
        public RegistrationRepo(ProductRentalContext _db)
        {
            db = _db;
        }

        public void AddUser(UserDetail ud)
        {
            db.Add(ud);
            db.SaveChanges();
        }

        public UserDetail getAccDetailsBygmail(string gmail)
        {
            var result = (from i in db.UserDetails where i.Gmail == gmail select i).FirstOrDefault();
            return result;
        }

        public UserDetail getAccDetailsById(int id)
        {
            UserDetail ud = db.UserDetails.Find(id);
            return ud;
        }

        public List<UserDetail> getAllUsers()
        {
            return db.UserDetails.ToList();
        }
        public bool Adduserverification(UserVerification p)
        {
            UserVerification cd = new();
            bool b = true;
            cd = db.UserVerifications.Find(p.UserId);
            if (cd == null)
            {
                db.UserVerifications.Add(p);
                try
                {
                    db.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    throw;
                }
            }
            else
            {
                b = false;
            }
            return b;
        }

        public bool Deleteuserverification(string id)
        {
            var uv = db.UserVerifications.Find(id);
            if (uv == null)
            {
                return false;
            }
            else
            {
                db.UserVerifications.Remove(uv);
                db.SaveChanges();
                return true;
            }

        }

        public bool Edituserverification(string id, UserVerification p)
        {
            bool flag = false;
            db.Entry(p).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userverificationItemExists(id))
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }



        public async Task<List<UserVerification>> getAlluserverificationdetails()
        {
            List<UserVerification> l = await db.UserVerifications.ToListAsync();
            return l;
        }


        public async Task<UserVerification> getuserverificationById(string id)
        {
            var cart = await db.UserVerifications.FindAsync(id);
            return cart;
        }


        private bool userverificationItemExists(string id)
        {
            return db.UserVerifications.Any(e => e.UserId == id);
        }

    }
}
