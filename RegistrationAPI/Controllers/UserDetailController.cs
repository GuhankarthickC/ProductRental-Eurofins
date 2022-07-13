using Microsoft.AspNetCore.Mvc;
using RegistrationAPI.ProductRental;
using RegistrationAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private readonly IRegService db;
        public UserDetailController(IRegService _db)
        {
            db = _db;
        }
        [HttpGet]
        [Route("Getallusers")]
        public async Task<ActionResult<List<UserDetail>>> Index()
        {
            List<UserDetail> l = new();
            l = db.getAllUsers();
            return Ok(l);
        }
        [HttpGet]
        public async Task<ActionResult<UserDetail>> Index(string gmail)
        {
            UserDetail ud = new();
            ud = db.getAccDetailsBygmail(gmail);
            return Ok(ud);
        }
        [HttpGet]
        [Route("GetDetailById{id}")]
        public async Task<ActionResult> GetDetailById(int id)
        {
            
            return Ok(db.getAccDetailsById(id));
        }
        [HttpPost]
        public async Task<ActionResult> AddUser(UserDetail ud)
        {
            db.AddUser(ud);
            return Ok();
        }

    }
}
