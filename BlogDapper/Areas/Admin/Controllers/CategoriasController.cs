using BlogDapper.Models;
using BlogDapper.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogDapper.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepositorio _repoCategoria;

        public CategoriasController(ICategoriaRepositorio repoCategoria)
        {
                _repoCategoria = repoCategoria;    
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();  
        }
        #region
        [HttpGet]
        public IActionResult GetCategorias()
        {
            return Json(new { data = _repoCategoria.GetCategorias() });
        }

        [HttpDelete]
        public IActionResult BorrarCategoria(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                _repoCategoria.BorrarCategoria(id.GetValueOrDefault()); 
                return Json(new { success = true, message= "Categoria borrada correctamente"});
            }

        }

        #endregion


        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear([Bind("IdCategoria,Nombre,FechaCreacion")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _repoCategoria.CreateCategoria(categoria);
                return RedirectToAction(nameof(Index)); 
            }

            return View(categoria);
        }

        //Recuperar el dato
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id==null)
            {
                return NotFound(); 
            }
            var categoria = _repoCategoria.GetCategoria(id.GetValueOrDefault());
            if (categoria == null)
            {
                return NotFound();

            }

            return View(categoria);  
        }

        [HttpPost]
        public IActionResult Editar([Bind("IdCategoria,Nombre,FechaCreacion")] Categoria categoria,int id)
        {
            if (id != categoria.IdCategoria)
            {
                return NotFound(); 
            }

            if (ModelState.IsValid)
            {
                _repoCategoria.ActualizarCategoria(categoria);
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

    }
}
