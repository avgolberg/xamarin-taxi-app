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
    public class RidersController : ControllerBase
    {
        private readonly TaxiContext _context;

        public RidersController(TaxiContext context)
        {
            _context = context;
        }

        // GET: api/Riders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rider>>> GetRiders()
        {
            return await _context.Riders.Include("City").ToListAsync();
        }

        // GET: api/Riders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rider>> GetRider(int id)
        {
            var rider = await _context.Riders.FindAsync(id);

            if (rider == null)
            {
                return NotFound();
            }

            _context.Entry(rider).Reference(r => r.City).Load();

            return rider;
        }

        // PUT: api/Riders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRider(int id, Rider rider)
        {
            if (id != rider.Id)
            {
                return BadRequest();
            }

            _context.Entry(rider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RiderExists(id))
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

        // POST: api/Riders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rider>> PostRider(Rider rider)
        {
            _context.Riders.Add(rider);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRider", new { id = rider.Id }, rider);
        }

        // DELETE: api/Riders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRider(int id)
        {
            var rider = await _context.Riders.FindAsync(id);
            if (rider == null)
            {
                return NotFound();
            }

            _context.Riders.Remove(rider);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RiderExists(int id)
        {
            return _context.Riders.Any(e => e.Id == id);
        }
    }
}
