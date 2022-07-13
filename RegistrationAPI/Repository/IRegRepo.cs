using RegistrationAPI.ProductRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationAPI.Repository
{
    public interface IRegRepo
    {
        List<UserDetail> getAllUsers();
        UserDetail getAccDetailsBygmail(string gmail);
        UserDetail getAccDetailsById(int id);
        void AddUser(UserDetail ud);
        Task<List<UserVerification>> getAlluserverificationdetails();
        bool Adduserverification(UserVerification p);
        bool Deleteuserverification(string pid);
        bool Edituserverification(string id, UserVerification p);
        Task<UserVerification> getuserverificationById(string id);

    }
        
}
