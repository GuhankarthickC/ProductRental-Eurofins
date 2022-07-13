using RegistrationAPI.ProductRental;
using RegistrationAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationAPI.Service
{
    public class RegistrationService : IRegService
    {
        private readonly IRegRepo irr;
        public RegistrationService(IRegRepo ir)
        {
            irr = ir;
        }

        public void AddUser(UserDetail ud)
        {
           
            irr.AddUser(ud);
        }

        public bool Adduserverification(UserVerification p)

        {
            bool b= irr.Adduserverification(p);
            return b;
        }

        public bool Deleteuserverification(string pid)
        {
            bool r=irr.Deleteuserverification(pid);
            return r;
        }

        public bool Edituserverification(string id, UserVerification p)
        {
            bool r = irr.Edituserverification(id,p);
            return r;
        }

        public UserDetail getAccDetailsBygmail(string gmail)
        {
            return irr.getAccDetailsBygmail(gmail);
        }

        public UserDetail getAccDetailsById(int id)
        {
            return irr.getAccDetailsById(id);
        }

        public List<UserDetail> getAllUsers()
        {
            return irr.getAllUsers();
        }

        public Task<List<UserVerification>> getAlluserverificationdetails()
        {
            return irr.getAlluserverificationdetails();
        }

        public Task<UserVerification> getuserverificationById(string id)
        {
            return irr.getuserverificationById(id);
        }
    }
}
