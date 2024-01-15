using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using PrestamoDomain;
using PrestamoInfrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrestamoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly PrestamobdContext _contexto;
        public PrestamoController(PrestamobdContext contexto)
        {
            _contexto = contexto;
        }
        // GET: api/<PrestamoController>
        [HttpGet]
        public async Task<ActionResult<List<Prestamo>>> Get()
        {
            return await _contexto.Prestamos.Find(Builders<Prestamo>.Filter.Empty).ToListAsync();
        }

        // GET api/<PrestamoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prestamo>> Get(string id)
        {
            var filter = Builders<Prestamo>.Filter.Eq(x => x.Idprestamo, id);
            Prestamo? prestamo = await _contexto.Prestamos.Find(filter).SingleOrDefaultAsync();
            if (prestamo != null)
            {
                return prestamo;
            }
            else { return NotFound(); }
        }

        // POST api/<PrestamoController>
        [HttpPost]
        public async Task<ActionResult> Post(Prestamo prestamo)
        {
            if (prestamo != null)
            {
                await _contexto.Prestamos.InsertOneAsync(prestamo);
                return Ok();
            }
            else
            {
                return BadRequest("Debe Ingresar datos validos");
            }
        }

        // PUT api/<PrestamoController>/5
        [HttpPut]
        public async Task<ActionResult> Put(Prestamo prestamo)
        {
            var existe = Builders<Prestamo>.Filter.Eq(x => x.Idprestamo, prestamo.Idprestamo);
            if (existe != null)
            {

                await _contexto.Prestamos.ReplaceOneAsync(existe, prestamo);
                return Ok();
            }
            else
            {
                return BadRequest("No exite el Prestamo");
            }
        }

        // DELETE api/<PrestamoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var existe = Builders<Prestamo>.Filter.Eq(x => x.Idprestamo, id);
            if (existe != null)
            {
                await _contexto.Prestamos.DeleteOneAsync(existe);
                return Ok();
            }
            else { return BadRequest("El Prestamo a Eliminar no Existe"); }
        }
    }
}
