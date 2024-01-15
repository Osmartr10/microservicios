using EstudianteDomain;
using EstudianteInfrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EstudianteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {

        private readonly EstudiantebdContext _contexto;
        public EstudianteController(EstudiantebdContext contexto)
        {
            _contexto = contexto;
        }
        // GET: api/<EstudianteController>
        [HttpGet]
        public async Task<ActionResult<List<Estudiante>>> Get()
        {
            return await _contexto.Estudiantes.ToListAsync();
        }

        // GET api/<EstudianteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> Get(int id)
        {
            Estudiante? estudiante = await _contexto.Estudiantes.FirstOrDefaultAsync(x => x.Idestudiante == id);
            if (estudiante != null)
            {
                return estudiante;
            }
            else { return NotFound(); }
        }

        // POST api/<EstudianteController>
        [HttpPost]
        public async Task<ActionResult> Post(Estudiante estudiante)
        {
            if (estudiante != null)
            {
                _contexto.Estudiantes.Add(estudiante);
                await _contexto.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("Debe Ingresar datos validos");
            }
        }

        // PUT api/<EstudianteController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Estudiante estudiante, int id)
        {
            Estudiante? existe = await _contexto.Estudiantes.FirstOrDefaultAsync(x => x.Idestudiante == id);
            if (existe != null)
            {
                existe.ci=estudiante.ci;    
                existe.Nombre = estudiante.Nombre;
                existe.Apellido = estudiante.Apellido;
                await _contexto.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("No exite el Estudiante");
            }
        }

        // DELETE api/<EstudianteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Estudiante? existe = await _contexto.Estudiantes.FirstOrDefaultAsync(x => x.Idestudiante == id);
            if (existe != null)
            {
                _contexto.Remove(existe);
                await _contexto.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("El Estudiante a Eliminar no Existe"); }
        }
    }
}
