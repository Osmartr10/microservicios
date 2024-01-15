using LibroDomain;
using LibroInfrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly LibrobdContext _contexto;
        public AutorController(LibrobdContext contexto)
        {
            _contexto = contexto;
        }
        // GET: api/<AutorController>
        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await _contexto.Autores.ToListAsync();
        }

        // GET api/<AutorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> Get(int id)
        {
            Autor? autor = await _contexto.Autores.FirstOrDefaultAsync(x => x.Idautor == id);
            if (autor != null)
            {
                return autor;
            }
            else { return NotFound(); }
        }

        // POST api/<AutorController>
        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            if (autor != null)
            {
                _contexto.Autores.Add(autor);
                await _contexto.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("Debe Ingresar datos validos");
            }
        }

        // PUT api/<AutorController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            Autor? existe = await _contexto.Autores.FirstOrDefaultAsync(x => x.Idautor == id);
            if (existe != null)
            {
                existe.Nombre = autor.Nombre;
                existe.Apellido = autor.Apellido;               
                await _contexto.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("No exite el Autor");
            }
        }

        // DELETE api/<AutorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Autor? existe = await _contexto.Autores.FirstOrDefaultAsync(x => x.Idautor == id);
            if (existe != null)
            {
                _contexto.Remove(existe);
                await _contexto.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("El Autor a Eliminar no Existe"); }
        }
    }
}
