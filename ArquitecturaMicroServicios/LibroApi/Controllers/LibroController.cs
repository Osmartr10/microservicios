using LibroDomain;
using LibroInfrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly LibrobdContext _contexto;
        public LibroController(LibrobdContext contexto)
        {
            _contexto = contexto;
        }
        // GET: api/<LibroController>
        [HttpGet]
        public async Task<ActionResult<List<Libro>>> Get()
        {
            var list = await _contexto.Libros
           .Select(libro => new Libro
           {
               Idlibro = libro.Idlibro,
               Titulo = libro.Titulo,              
               Anio = libro.Anio,
               Editorial = libro.Editorial,              
               Libroautores = libro.Libroautores

           }).ToListAsync();
            return  list;
        }

        // GET api/<LibroController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> Obtener(int id)
        {
            Libro? libro = await _contexto.Libros.FirstOrDefaultAsync(x => x.Idlibro == id);
            if (libro != null)
            {
                return libro;
            }
            else { return NotFound(); }
        }

        // POST api/<LibroController>
        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {
            if (libro != null)
            {
                _contexto.Libros.Add(libro);
                await _contexto.SaveChangesAsync();
                return CreatedAtAction(nameof(Obtener), new { id = libro.Idlibro }, libro);
            }
            else
            {
                return BadRequest("Debe Ingresar datos validos");
            }
        }

        // PUT api/<LibroController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Libro libro, int id)
        {
            Libro? existe = await _contexto.Libros.FirstOrDefaultAsync(x => x.Idlibro == id);
            if (existe != null)
            {
                existe.Titulo = libro.Titulo;
                existe.Anio = libro.Anio;
                existe.Editorial = libro.Editorial;
                await _contexto.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("No exite el Libro");
            }
        }

        // DELETE api/<LibroController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Libro? existe = await _contexto.Libros.FirstOrDefaultAsync(x => x.Idlibro == id);
            if (existe != null)
            {
                _contexto.Remove(existe);
                await _contexto.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("El Libro a Eliminar no Existe"); }
        }
    }
}
