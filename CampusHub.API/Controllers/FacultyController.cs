using CampusHub.API.Data;
using CampusHub.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusHub.API.Controllers
{
    [ApiController]
    [Route("/api/faculties")]
    public class FacultiesController : ControllerBase
    {
        private readonly DataContext _context;


        public FacultiesController(DataContext context)
        {
            _context = context;
        }


        //Método GET LIST

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Faculties

                .Include(x => x.UniversityPrograms)
                .ToListAsync());

        }

        [HttpGet("full")]
        public async Task<ActionResult> GetFull()
        {
            return Ok(await _context.Faculties
                .Include(x => x.UniversityPrograms!)
                .ThenInclude(x => x.Subjects)
                .ToListAsync());
        }





        //´Método GET con parámetro

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var faculty = await _context.Faculties

                .Include(x => x.UniversityPrograms)
                .ThenInclude(x => x.Subjects)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (faculty is null)
            {
                return NotFound(); //404
            }

            return Ok(faculty);

        }




        // Método POST -- CREAR
        [HttpPost]
        public async Task<ActionResult> Post(Faculty faculty)
        {
            _context.Add(faculty);
            try
            {

                await _context.SaveChangesAsync();
                return Ok(faculty);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un facultad con el mismo nombre.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }





        //Método PUT --- UPDATE

        [HttpPut]
        public async Task<ActionResult> Put(Faculty faculty)
        {
            _context.Update(faculty);
            await _context.SaveChangesAsync();
            return Ok(faculty);
        }



        // Método DELETE-- Eliminar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Faculties
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound(); //404
            }

            return NoContent(); //204
        }







    }
}
