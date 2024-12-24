using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace larionov_3_vs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace ComputerBookingAPI.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class BookingsController : ControllerBase
        {
            private readonly ApplicationDbContext _context;

            public BookingsController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: api/Bookings
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
            {
                return await _context.Bookings.ToListAsync();
            }

            // GET: api/Bookings/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Booking>> GetBooking(int id)
            {
                var booking = await _context.Bookings.FindAsync(id);
                if (booking == null)
                {
                    return NotFound();
                }
                return booking;
            }

            // POST: api/Bookings
            [HttpPost]
            public async Task<ActionResult<Booking>> PostBooking(Booking booking)
            {
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetBooking", new { id = booking.BookingID }, booking);
            }

            // PUT: api/Bookings/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutBooking(int id, Booking booking)
            {
                if (id != booking.BookingID)
                {
                    return BadRequest();
                }

                _context.Entry(booking).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Bookings.Any(e => e.BookingID == id))
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

            // DELETE: api/Bookings/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteBooking(int id)
            {
                var booking = await _context.Bookings.FindAsync(id);
                if (booking == null)
                {
                    return NotFound();
                }

                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();

                return NoContent();
            }
        }
    }
}
