using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebLab2.Models;
using Microsoft.AspNetCore.Cors;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebLab2.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly TestBaseDbContext _context;
        public TestController(TestBaseDbContext context)
        {
            _context = context;
        }
        // GET: api/test/list
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Test>>> GetAllTests()
        {
            return await _context.Tests.Include(p => p.Questions).ToListAsync();
        }

        // GET api/test/<id>
        [HttpGet("{id}")]
        public async Task<ActionResult<Test>> GetTest(int id)
        {
            var test = await _context.Tests.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }
            return test;
        }

        // POST api/test
        [HttpPost]
        public async Task<ActionResult<Test>> PostTest([FromBody] Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Tests.Add(test);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTest", new { id = test.Id }, test);
        }

        // PUT api/test/<id>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTest(int id, Test test)
        {
            if (id != test.Id)
            {
                return BadRequest();
            }
            _context.Entry(test).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestExists(id))
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

        private bool TestExists(int id)
        {
            return _context.Tests.Any(e => e.Id == id);
        }

        // DELETE api/test/id=<id>
        [HttpDelete("id={id}")]
        public async Task<IActionResult> DeleteTest(int id)
        {
            var test = await _context.Tests.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }
            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
