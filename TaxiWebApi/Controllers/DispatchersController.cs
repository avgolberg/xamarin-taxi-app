using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxiWebApi.Context;
using TaxiWebApi.Models;

namespace TaxiWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispatchersController : ControllerBase
    {
        private readonly TaxiContext _context;

        public DispatchersController(TaxiContext context)
        {
            _context = context;
        }

        // GET: api/Dispatchers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dispatcher>>> GetDispatchers()
        {
            return await _context.Dispatchers.Include("City").ToListAsync();
        }

        // GET: api/Dispatchers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dispatcher>> GetDispatcher(int id)
        {
            var dispatcher = await _context.Dispatchers.FindAsync(id);

            if (dispatcher == null)
            {
                return NotFound();
            }

            _context.Entry(dispatcher).Reference(d => d.City).Load();

            return dispatcher;
        }

        // PUT: api/Dispatchers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDispatcher(int id, Dispatcher dispatcher)
        {
            if (id != dispatcher.Id)
            {
                return BadRequest();
            }

            _context.Entry(dispatcher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DispatcherExists(id))
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

        // POST: api/Dispatchers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dispatcher>> PostDispatcher(Dispatcher dispatcher)
        {
            _context.Dispatchers.Add(dispatcher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDispatcher", new { id = dispatcher.Id }, dispatcher);
        }

        // DELETE: api/Dispatchers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDispatcher(int id)
        {
            var dispatcher = await _context.Dispatchers.FindAsync(id);
            if (dispatcher == null)
            {
                return NotFound();
            }

            _context.Dispatchers.Remove(dispatcher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DispatcherExists(int id)
        {
            return _context.Dispatchers.Any(e => e.Id == id);
        }
    }
}
