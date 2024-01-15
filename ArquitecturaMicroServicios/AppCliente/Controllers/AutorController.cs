using AppCliente.Models;
using AppCliente.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppCliente.Controllers
{
    public class AutorController : Controller
    {
        AutorService servicio = new AutorService();
        // GET: AutorController
        public async Task<ActionResult> Index()
        {
            List<Autor> autores = await servicio.ListarAutores();
            return View(autores);
        }
      

        // GET: AutorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Autor autor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await servicio.InsertarAutor(autor);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(autor);
            }
        }

        // GET: AutorController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Autor autor = await servicio.ObtenerAutor(id);
            return View(autor);
        }

        // POST: AutorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Autor autor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await servicio.EditarAutor(autor, id);
                    return RedirectToAction(nameof(Index));
                }
                return View(autor);
            }
            catch
            {
                return View(autor);
            }
        }
      
        // POST: AutorController/Delete/5
        [HttpPost]      
        public async Task<ActionResult> Delete(string id)
        {
            int idAutor = Convert.ToInt32(id);
            await servicio.EliminarAutor(idAutor);
            return Json(new
            {
                success = true,
                responseText = "200"
            });
        }
    }
}
