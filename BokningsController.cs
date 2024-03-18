using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application;
using BordsBokning.Models;
using System.Web.Http.Cors;

namespace BordsBokning
{
    [Route("api/[controller]")]
    [ApiController]
    public class BokningsController : ControllerBase
    {
        private readonly BokningsContext _context;

        public BokningsController(BokningsContext context)
        {
            _context = context;
        }

        // GET: api/Boknings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bokning>>> GetBokningar()
        {
            return await _context.Bokningar.ToListAsync();
        }

        // GET: api/Boknings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bokning>> GetBokning(int id)
        {
            var bokning = await _context.Bokningar.FindAsync(id);

            if (bokning == null)
            {
                return NotFound();
            }

            return bokning;
        }

        // PUT: api/Boknings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBokning(int id, Bokning bokning)
        {
            if (id != bokning.Id)
            {
                return BadRequest();
            }

            _context.Entry(bokning).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BokningExists(id))
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

        // POST: api/Boknings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bokning>> PostBokning(Bokning bokning)
        {
            _context.Bokningar.Add(bokning);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBokning", new { id = bokning.Id }, bokning);
        }

        // DELETE: api/Boknings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBokning(int id)
        {
            var bokning = await _context.Bokningar.FindAsync(id);
            if (bokning == null)
            {
                return NotFound();
            }

            _context.Bokningar.Remove(bokning);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BokningExists(int id)
        {
            return _context.Bokningar.Any(e => e.Id == id);
        }
    }
}
