using BlogDapper.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Data.SqlClient;

namespace BlogDapper.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly IDbConnection _bd;

        public CategoriaRepositorio(IConfiguration configuration)
        {
            _bd = new SqlConnection(configuration.GetConnectionString("ConexionSQLLocalDB")); 
        }

        public Categoria ActualizarCategoria(Categoria categoria)
        {
            var sql = "UPDATE Categoria SET Nombre =@Nombre Where IdCategoria=@IdCategoria";
            _bd.Execute(sql, categoria); 
            return categoria; 
        }

        public void BorrarCategoria(int id)
        {
            var sql = "DELETE FROM Categoria Where IdCategoria=@IdCategoria";
            _bd.Execute(sql, new {IdCategoria = id});
        }

        public Categoria CreateCategoria(Categoria categoria)
        {
            var sql = "INSERT INTO Categoria(Nombre,FechaCreacion)VALUES(@Nombre,@FechaCreacion)"; 
            _bd.Execute(sql, new {
                categoria.Nombre,
                FechaCreacion = DateTime.Now 
            });

            return categoria; 
        }

        public Categoria GetCategoria(int id)
        {
            var sql = "SELECT * FROM Categoria Where IdCategoria=@IdCategoria";
            return _bd.Query<Categoria>(sql, new {IdCategoria = id }).Single();
        }

        public List<Categoria> GetCategorias()
        {
            var sql = "SELECT * FROM Categoria";
            return _bd.Query<Categoria>(sql).ToList();
        }

        public IEnumerable<SelectListItem> GetListaCategorias()
        {
            var sql = "SELECT * FROM categoria";
            var lista = _bd.Query<Categoria>(sql).ToList();
            SelectList listaCategorias = new SelectList(lista, "IdCategoria", "Nombre"); 
            
            return listaCategorias;
        }
    }
}
