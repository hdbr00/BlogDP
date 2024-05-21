using BlogDapper.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogDapper.Repositorio
{
    public interface IArticuloRepositorio
    {
        Articulo GetArticulo(int id);
        List<Articulo> GetArticulo();
        Articulo CreateArticulo(Articulo Articulo);
        Articulo ActualizarArticulo(Articulo articulo);
        void BorrarArticulo(int id);

        //se agrega nuevo método para obtener la relacion entre articulo y categoría. 
        List<Articulo> GetArticuloCategoria(); 

    }
}
