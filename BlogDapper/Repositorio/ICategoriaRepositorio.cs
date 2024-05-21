using BlogDapper.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogDapper.Repositorio
{
    public interface ICategoriaRepositorio
    {
        Categoria GetCategoria(int id);
        List<Categoria> GetCategorias();
        Categoria CreateCategoria(Categoria categoria); 
        Categoria ActualizarCategoria(Categoria categoria);
        void BorrarCategoria(int id);
        IEnumerable<SelectListItem> GetListaCategorias();


    }
}
