using AppCliente.Models;
using AppCliente.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppCliente.Controllers
{
    public class LibroController : Controller
    {
        LibroService servicio = new LibroService();
        LibroService servicio2 = new LibroService();
        LibroService servicio3 = new LibroService();
        LibroService servicio4 = new LibroService();
        AutorService autorService = new AutorService();
        static List<int> autoresInicio = new List<int>();
        // GET: LibroController
        public async Task<ActionResult> Index()
        {
            List<Libro> libros = await servicio.ListarLibros();
            ViewBag.autores = new SelectList(await autorService.ListarAutores(), "Idautor", "NombreCompleto");
            return View(libros);
        }


        // GET: LibroController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.autores = new SelectList(await autorService.ListarAutores(), "Idautor", "NombreCompleto");
            return View();
        }

        // POST: LibroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Libro libro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   Libro lib= await servicio.InsertarLibro(libro);
                    AutorLibro[] autores = new AutorLibro[libro.IdAutor!.Length];
                    for (int i = 0; i < libro.IdAutor!.Length; i++)
                    {
                        AutorLibro autor = new AutorLibro();
                        autor.Idlibro = lib.Idlibro;
                        autor.Idautor = Convert.ToInt32(libro.IdAutor[i]);
                        autores[i] = autor;
                    }

                    await servicio.AgregarAutores(autores);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(libro);
            }
        }
        // GET: LibroController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Libro libro = await servicio.ObtenerLibro(id);
            if (libro != null) 
            {
                IEnumerable<AutorLibro> autores = await servicio2.ObtenerAutores(id);
                if (autores != null)
                {
                    var autorList = await autorService.ListarAutores();
                    var selectedAutor = new List<int>();

                    foreach (var item in autores)
                    {
                        selectedAutor.Add(item.Idautor);
                    }
                    autoresInicio = selectedAutor;
                    ViewBag.autors = new MultiSelectList
                    (
                        items: autorList,
                        dataValueField: nameof(Autor.Idautor),
                        dataTextField: nameof(Autor.NombreCompleto),
                        selectedValues: selectedAutor
                    );
                }
                return View(libro);
            }
            else { return NotFound(); }
            
        }

        // POST: LibroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Libro libro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<int> numRol = new List<int>();
                    for (int i = 0; i < libro.IdAutor!.Length; i++)
                    {
                        numRol.Add(Convert.ToInt32(libro.IdAutor[i]));
                    }
                    if (!autoresInicio.Equals(numRol))
                    {
                        IEnumerable<AutorLibro> roles = await servicio2.ObtenerAutores(id);
                        foreach (var item in roles)
                        {
                            await servicio3.EliminarAutor(item.Idautorlibro);
                        }
                        AutorLibro[] roleslista = new AutorLibro[libro.IdAutor!.Length];
                        for (int i = 0; i < libro.IdAutor!.Length; i++)
                        {
                            AutorLibro rol = new AutorLibro();
                            rol.Idlibro = id;
                            rol.Idautor = Convert.ToInt32(libro.IdAutor[i]);
                            roleslista[i] = rol;
                        }
                        await servicio4.AgregarAutores(roleslista);
                    }
                    await servicio.EditarLibro(libro, id);
                    return RedirectToAction(nameof(Index));
                }
                return View(libro);
            }
            catch
            {
                return View(libro);
            }
        }


        // POST: LibroController/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            int idLibro = Convert.ToInt32(id);
            await servicio.EliminarLibro(idLibro);
            return Json(new
            {
                success = true,
                responseText = "200"
            });
        }
    }
}
