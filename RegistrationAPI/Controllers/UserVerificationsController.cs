using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrationAPI.ProductRental;
using RegistrationAPI.Service;

namespace RegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserVerificationsController : ControllerBase
    {
        private readonly IRegService _context;

        public UserVerificationsController(IRegService context)
        {
            _context = context;
        }

        // GET: api/UserVerifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserVerification>>> GetUserVerifications()
        {
            return await _context.getAlluserverificationdetails();
        }

        // GET: api/UserVerifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserVerification>> GetUserVerification(string id)
        {
            var userVerification = await _context.getuserverificationById(id);

            if (userVerification == null)
            {
                return NotFound();
            }

            return userVerification;
        }

        // PUT: api/UserVerifications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserVerification(string id, UserVerification userVerification)
        {
            bool b = false;
            try
            {
                b = _context.Edituserverification(id, userVerification);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!b)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

        }

        // POST: api/UserVerifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserVerification>> PostUserVerification(UserVerification userVerification)
        {
            bool b = false;
            try
            {
                b = _context.Adduserverification(userVerification);
                if (b == false)
                {
                    return BadRequest();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!b)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetUserVerification", new { id = userVerification.UserId }, userVerification);
        }

        // DELETE: api/UserVerifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserVerification(string id)
        {
            bool b = _context.Deleteuserverification(id);
            if (b == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
