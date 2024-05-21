using BlogDapper.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BlogDapper.Repositorio
{
    public class ArticuloRepositorio : IArticuloRepositorio
    {
        private readonly IDbConnection _bd;
        public ArticuloRepositorio(IConfiguration configuration)
        {

            _bd = new SqlConnection(configuration.GetConnectionString("ConexionSQLLocalDB"));
        }
        public Articulo ActualizarArticulo(Articulo articulo)
        {
            var sql = "UPDATE Articulo SET Titulo=@Titulo, Descripcion=@Descripcion, Imagen=@Imagen,Estado=@Estado, CategoriaId=@CategoriaId Where IdArticulo=@IdArticulo";
            _bd.Execute(sql, articulo);
            return articulo;
        }
        public void BorrarArticulo(int id)
        {
            var sql = "DELETE FROM Articulo Where IdArticulo=@IdArticulo";
            _bd.Execute(sql, new { IdArticulo = id });
        }
        public Articulo CreateArticulo(Articulo articulo)
        {
            var sql = "INSERT INTO articulo(Titulo,Descripcion,Imagen,Estado,CategoriaId,FechaCreacion)"+
                "VALUES(@Titulo,@Descripcion,@Imagen, @Estado, @CategoriaId,@FechaCreacion)";
            _bd.Execute(sql, new
            {
                articulo.Titulo,
                articulo.Descripcion,
                articulo.Imagen,
                articulo.Estado,
                articulo.CategoriaId,
                FechaCreacion = DateTime.Now
            });

            return articulo;
        }
        public Articulo GetArticulo(int id)
        {
            var sql = "SELECT * FROM Articulo Where IdArticulo=@IdArticulo";
            return _bd.Query<Articulo>(sql, new { IdArticulo = id }).Single();
        }
        public List<Articulo> GetArticulo()
        {
            var sql = "SELECT * FROM Articulo";
            return _bd.Query<Articulo>(sql).ToList();
        }
        public List<Articulo> GetArticuloCategoria()
        {
            var sql = "SELECT a.*, c.Nombre FROM Articulo a INNER JOIN Categoria c " +
                   "ON a.CategoriaId=c.IdCategoria ORDER BY IdArticulo DESC";

            //dapper.
            var articulo = _bd.Query<Articulo, Categoria, Articulo>(sql, (a, c) =>
            {
                a.Categoria = c;
                return a;
            }, splitOn: "CategoriaId");

            return articulo.Distinct().ToList(); 
        }
    }
}
