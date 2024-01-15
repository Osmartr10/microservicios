using AppCliente.Models;
using AppCliente.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppCliente.Controllers
{
    public class EstudianteController : Controller
    {
        EstudianteService servicio=new EstudianteService();
        // GET: EstudianteController
        public async Task<ActionResult> Index()
        {
            List<Estudiante> estudiantes = await servicio.ListarEstudiantes();
            return View(estudiantes);
        }

       
        // GET: EstudianteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstudianteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Estudiante estudiante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await servicio.InsertarEstudiante(estudiante);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(estudiante);
            }
        }

        // GET: EstudianteController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Estudiante estudiante = await servicio.ObtenerEstudiante(id);
            return View(estudiante);
        }

        // POST: EstudianteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Estudiante estudiante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await servicio.EditarEstudiante(estudiante, id);
                    return RedirectToAction(nameof(Index));
                }
                return View(estudiante);
            }
            catch
            {
                return View(estudiante);
            }
        }

      
        // POST: EstudianteController/Delete/5
        [HttpPost]

        public async Task<ActionResult> Delete(string id)
        {
            int idEstudiante = Convert.ToInt32(id);
            await servicio.EliminarEstudiante(idEstudiante);
            return Json(new
            {
                success = true,
                responseText = "200"
            });
        }
    }
}
