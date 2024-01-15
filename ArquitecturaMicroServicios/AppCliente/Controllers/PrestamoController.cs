using AppCliente.Models;
using AppCliente.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppCliente.Controllers
{
    public class PrestamoController : Controller
    {
        PrestamoService servicio = new PrestamoService();
        EstudianteService estudianteService = new EstudianteService();
        LibroService libroService = new LibroService();
        static List<Detalle>? detalleLista;
        // GET: PrestamoController
        public async Task<ActionResult> Index()
        {
            List<Prestamo> prestamos = await servicio.ListarPrestamos();
            return View(prestamos);
        }

        // GET: PrestamoController/Details/5
        public async Task<ActionResult> Detail(string id)
        {
            Prestamo prestamo = await servicio.ObtenerPrestamo(id);
            return View(prestamo);
        }

        // GET: PrestamoController/Create
        public async Task<ActionResult> Create()
        {
            Prestamo pedido = new Prestamo();
            ViewBag.Estudiantes = new SelectList(await estudianteService.ListarEstudiantes(), "Idestudiante", "NombreCompleto");
            ViewData["libros"] = await libroService.ListarLibros();
            return View(pedido);
        }

        // POST: PrestamoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Prestamo prestamo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (detalleLista != null)
                    {
                        prestamo.PrestamoDetalle = detalleLista;
                    }
                    await servicio.InsertarPrestamo(prestamo);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(prestamo);
            }
        }

        // GET: PrestamoController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            Prestamo prestamo = await servicio.ObtenerPrestamo(id);
            ViewBag.Estudiantes = new SelectList(await estudianteService.ListarEstudiantes(), "Idestudiante", "NombreCompleto");
            ViewData["libros"] = await libroService.ListarLibros();
            return View(prestamo);
        }
        // POST: PrestamoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Prestamo prestamo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (detalleLista != null)
                    {
                        prestamo.PrestamoDetalle = detalleLista;
                    }
                    await servicio.EditarPrestamo(prestamo);
                    return RedirectToAction(nameof(Index));
                }
                return View(prestamo);
            }
            catch
            {
                return View(prestamo);
            }
        }

        [HttpPost]
        public void InsertarDetalle([FromBody] List<Detalle> detalle)
        {
            detalleLista = new List<Detalle>();
            detalleLista = detalle;
        }
        // POST: PrestamoController/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {

            await servicio.EliminarPrestamo(id);
            return Json(new
            {
                success = true,
                responseText = "200"
            });
        }
    }
}
