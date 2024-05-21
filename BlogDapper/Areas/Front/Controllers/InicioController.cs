using BlogDapper.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace BlogDapper.Areas.Front.Controllers
{
    [Area("Front")]
    public class InicioController : Controller
    {
        private readonly IDbConnection _bd; 

        public InicioController(IConfiguration configuration) //**
        {
            _bd = new SqlConnection(configuration.GetConnectionString("ConexionSQLLocalDB"));
        }

        public IActionResult Index() //**
        {
            var sqlSlider = @"SELECT * FROM Slider ORDER BY IdSlider Desc";
            ViewData["ListaSlider"] =  _bd.Query<Slider>(sqlSlider ).ToList();


            var sqlArticulos = @"SELECT * FROM Articulo Where Estado=@Estado ORDER BY IdArticulo Desc";
            var articulos = _bd.Query<Articulo>(sqlArticulos, new {@Estado = 1 }).ToList();


            var sqlCategorias = @"SELECT * FROM Categoria ORDER BY IdCategoria Desc";
            ViewData["ListaCategorias"] = _bd.Query<Categoria>(sqlCategorias).ToList();

            //Esta linea es para poder saber si estamos en el home o no...!

            ViewBag.IsHome = true; 

            return View(articulos);
        }

        [HttpGet]
        public IActionResult Detalle(int id)
        {
            var sql = @"SELECT * FROM Articulo WHERE IdArticulo=@IdArticulo";
            var articulo = _bd.Query<Articulo>(sql, new { IdArticulo = id }).Single();

            //Enviar la lista de comentarios para este articulo

            var sqlComentarios = @"SELECT * FROM Comentario Where ArticuloId =@ArticuloId ORDER BY IdComentario DESC";
            ViewData["ListaComentarios"] = _bd.Query<Comentario>(sqlComentarios, new
            {

                ArticuloId = id

            }).ToList();

            return View(articulo);
        }



        [HttpPost]
        public IActionResult CrearComentario(string Titulo,string Mensaje,int ArticuloId)
        {
            var sql = @"INSERT INTO comentario(Titulo, Mensaje,ArticuloId,FechaCreacion)Values(@Titulo, @Mensaje,@ArticuloId,@FechaCreacion)";
            _bd.Execute(sql, new
            {
                Titulo,
                Mensaje, 
                ArticuloId,
                FechaCreacion = DateTime.Now

            });

            return RedirectToAction("Index","Inicio");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}