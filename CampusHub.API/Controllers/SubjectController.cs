using CampusHub.API.Data;
using CampusHub.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusHub.API.Controllers
{
    [ApiController]
    [Route("/api/subjects")]
    public class SubjectsController : ControllerBase
    {
        private readonly DataContext _context;

        public SubjectsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Subjects.ToListAsync());
        }




        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Subject subject)
        {
            try
            {
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return Ok(subject);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una asignatura con el mismo nombre.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Subject subject)
        {
            try
            {
                _context.Update(subject);
                await _context.SaveChangesAsync();
                return Ok(subject);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una asignatura con el mismo nombre.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            _context.Remove(subject);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
