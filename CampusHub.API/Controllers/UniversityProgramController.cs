using CampusHub.API.Data;
using CampusHub.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusHub.API.Controllers
{
    [ApiController]
    [Route("/api/universityPrograms")]
    public class UniversityProgramsController : ControllerBase
    {
        private readonly DataContext _context;

        public UniversityProgramsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.UniversityPrograms
                .Include(x => x.Subjects)
                .ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var universityProgram = await _context.UniversityPrograms
                .Include(x => x.Subjects)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (universityProgram == null)
            {
                return NotFound();
            }

            return Ok(universityProgram);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(UniversityProgram universityProgram)
        {
            try
            {
                _context.Add(universityProgram);
                await _context.SaveChangesAsync();
                return Ok(universityProgram);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un programa con el mismo nombre.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(UniversityProgram universityProgram)
        {
            try
            {
                _context.Update(universityProgram);
                await _context.SaveChangesAsync();
                return Ok(universityProgram);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un programa con el mismo nombre.");
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
            var universityProgram = await _context.UniversityPrograms.FirstOrDefaultAsync(x => x.Id == id);
            if (universityProgram == null)
            {
                return NotFound();
            }

            _context.Remove(universityProgram);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
