using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Models;

namespace ConsoleApp.Spa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RTypesController : ControllerBase
    {
        private readonly GeneralContext _context;

        public RTypesController(GeneralContext context)
        {
            _context = context;
        }

        // GET: api/RTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RType>>> GetRTypes()
        {
            return await _context.RTypes.ToListAsync();
        }

        // GET: api/RTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RType>> GetRType(int id)
        {
            var rType = await _context.RTypes.FindAsync(id);

            if (rType == null)
            {
                return NotFound();
            }

            return rType;
        }

        // PUT: api/RTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRType(int id, RType rType)
        {
            if (id != rType.Id)
            {
                return BadRequest();
            }

            _context.Entry(rType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RTypeExists(id))
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

        // POST: api/RTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RType>> PostRType(RType rType)
        {
            _context.RTypes.Add(rType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRType", new { id = rType.Id }, rType);
        }

        // DELETE: api/RTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRType(int id)
        {
            var rType = await _context.RTypes.FindAsync(id);
            if (rType == null)
            {
                return NotFound();
            }

            _context.RTypes.Remove(rType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RTypeExists(int id)
        {
            return _context.RTypes.Any(e => e.Id == id);
        }
    }
}
