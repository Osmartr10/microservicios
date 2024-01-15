using LibroApi.DTO;
using LibroDomain;
using LibroInfrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorLibroController : ControllerBase
    {
        private readonly LibrobdContext _contexto;
        public AutorLibroController(LibrobdContext contexto)
        {
            _contexto = contexto;
        }

        [HttpPost]
        public async Task<ActionResult> Agregar(AutorLibro[] autor)
        {

            if (autor != null)
            {
                foreach (var item in autor)
                {
                    _contexto.AutorLibros.Add(item);

                }
                await _contexto.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("Array Autor Libro Vacio"); }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<dtoAutor>>> Listar(int id)
        {
            var list = await _contexto.AutorLibros
             .Where(p => p.Idlibro == id)
             .Select(autor => new dtoAutor
             {
                 Idautorlibro = autor.Idautorlibro,
                 Idlibro = autor.Idlibro,
                 Idautor = autor.Idautor,
                 NombreAutor = autor.IdautorNavigation!.Nombre + " " + autor.IdautorNavigation!.Apellido

             }).ToListAsync();

            return list;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            AutorLibro? existe = await _contexto.AutorLibros.FirstOrDefaultAsync(x => x.Idautorlibro == id);
            if (existe != null)
            {
                _contexto.Remove(existe);
                await _contexto.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("El AutorLibro a Eliminar no Existe"); }
        }
    }
}
