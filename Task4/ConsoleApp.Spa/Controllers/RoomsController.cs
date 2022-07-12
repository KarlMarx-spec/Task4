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
    public class RoomsController : ControllerBase
    {
        private readonly GeneralContext _context;

        public RoomsController(GeneralContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // GET: api/Rooms/Task1
        [HttpGet("Task1")]
        public List<string> Task1()
        {
            var result = new List<string>();
            var data = from room in _context.Rooms
                       join floor in _context.Floors on room.FloorId equals floor.Id
                       select new
                       {
                           room.Number,
                           room.Length,
                           room.Width,
                           floor.Height
                       };
            foreach (var item in data)
            {
                result.Add($"Номер комнаты: {item.Number}, площадь: {item.Length * item.Width}, " +
                $"объем: {item.Length * item.Width* item.Height}");
            }
            return result;
        }

        // GET: api/Rooms/rooms_w_b_&_f
        [HttpGet("rooms_w_b_a_f")]
        public List<string> W_build_and_floors()
        {
            var result = new List<string>();
            var data = from room in _context.Rooms
                       join floor in _context.Floors on room.FloorId equals floor.Id
                       join building in _context.Buildings on floor.BuildingId equals building.Id
                       select new
                       {
                           room.Number,
                           building.Name,
                           fnum = floor.Number
                       };
            foreach (var item in data)
            {
                result.Add($"Номер комнаты: {item.Number}, этаж: {item.fnum}, " +
                $"в здании : \"{item.Name}\"");
            }
            return result;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
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

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
    }
}
