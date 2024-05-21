using BlogDapper.Models;
using BlogDapper.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogDapper.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ComentariosController : Controller
    {
        private readonly IComentarioRepositorio _repoComentario;

        public ComentariosController(IComentarioRepositorio repoComentario)
        {
                _repoComentario = repoComentario;    
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();  
        }
        #region
        [HttpGet]
        public IActionResult GetComentarios()
        {
            //return Json(new { data = _repoComentario.GetComentario()});
            return Json(new { data = _repoComentario.GetComentarioArticulo()}); 
        }
        [HttpDelete]
        public IActionResult BorrarComentario(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                _repoComentario.BorrarComentario(id.GetValueOrDefault()); 
                return Json(new { success = true, message= "Comentario borrado correctamente"});
            }

        }

        #endregion
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear([Bind("IdCategoria,Nombre,FechaCreacion")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                _repoComentario.CreateComentario(comentario);
                return RedirectToAction(nameof(Index)); 
            }

            return View(comentario);
        }

        //Recuperar el dato
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id==null)
            {
                return NotFound(); 
            }
            var comentario = _repoComentario.GetComentario(id.GetValueOrDefault());
            if (comentario == null)
            {
                return NotFound();

            }

            return View(comentario);  
        }

        [HttpPost]
        public IActionResult Editar([Bind("IdCategoria,Nombre,FechaCreacion")] Comentario comentario,int id)
        {
            if (id != comentario.IdComentario)
            {
                return NotFound(); 
            }

            if (ModelState.IsValid)
            {
                _repoComentario.ActualizarComentario(comentario);
                return RedirectToAction(nameof(Index));
            }

            return View(comentario);
        }

    }
}
