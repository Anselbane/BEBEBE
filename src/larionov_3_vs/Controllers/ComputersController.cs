using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace larionov_3_vs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComputersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComputersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Computers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Computer>>> GetComputers()
        {
            return await _context.Computers.ToListAsync();
        }

        // GET: api/Computers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Computer>> GetComputer(int id)
        {
            var computer = await _context.Computers.FindAsync(id);
            if (computer == null)
            {
                return NotFound();
            }
            return computer;
        }

        // POST: api/Computers
        [HttpPost]
        public async Task<ActionResult<Computer>> PostComputer(Computer computer)
        {
            _context.Computers.Add(computer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetComputer", new { id = computer.ComputerID }, computer);
        }

        // PUT: api/Computers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComputer(int id, Computer computer)
        {
            if (id != computer.ComputerID)
            {
                return BadRequest();
            }

            _context.Entry(computer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Computers.Any(e => e.ComputerID == id))
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

        // DELETE: api/Computers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComputer(int id)
        {
            var computer = await _context.Computers.FindAsync(id);
            if (computer == null)
            {
                return NotFound();
            }

            _context.Computers.Remove(computer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
