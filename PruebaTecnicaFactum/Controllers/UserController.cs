using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Persistence;

namespace PruebaTecnicaFactum.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Context _context;

        public UserController(Context context)
        {
            _context = context;
        }

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var users = new List<User>();

            try
            {
                users = await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return users;
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            User user = null;
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                user = await _context.Users.FindAsync(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (user == null) { return NotFound(); }
            return user;
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { user.Id }, user);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, User user)
        {
            try
            {
                if (id != user.Id || !ModelState.IsValid) { return BadRequest(); }

                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            return NoContent();
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                var user = await _context.Users.FindAsync(id);

                if (user == null) { return NotFound(); }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return NoContent();        }
    }
}
