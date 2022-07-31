using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JasonAPI;
using JasonAPI.Data;

namespace JasonAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ArgusUsersController : ControllerBase
    {
        private readonly DataContext _context;

        public ArgusUsersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ArgusUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArgusUser>>> GetArgusUsers()
        {
          if (_context.ArgusUsers == null)
          {
              return NotFound();
          }
            return await _context.ArgusUsers.ToListAsync();
        }

        // GET: api/ArgusUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArgusUser>> GetArgusUser(int id)
        {
          if (_context.ArgusUsers == null)
          {
              return NotFound();
          }
            var argusUser = await _context.ArgusUsers.FindAsync(id);

            if (argusUser == null)
            {
                return NotFound();
            }

            return argusUser;
        }

        // PUT: api/ArgusUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArgusUser(int id, ArgusUser argusUser)
        {
            if (id != argusUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(argusUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArgusUserExists(id))
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

        // POST: api/ArgusUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArgusUser>> PostArgusUser(ArgusUser argusUser)
        {
          if (_context.ArgusUsers == null)
          {
              return Problem("Entity set 'DataContext.ArgusUsers'  is null.");
          }
            _context.ArgusUsers.Add(argusUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArgusUser", new { id = argusUser.Id }, argusUser);
        }

        // DELETE: api/ArgusUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArgusUser(int id)
        {
            if (_context.ArgusUsers == null)
            {
                return NotFound();
            }
            var argusUser = await _context.ArgusUsers.FindAsync(id);
            if (argusUser == null)
            {
                return NotFound();
            }

            _context.ArgusUsers.Remove(argusUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArgusUserExists(int id)
        {
            return (_context.ArgusUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
