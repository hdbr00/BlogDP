﻿using BlogDapper.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogDapper.Repositorio
{
    public interface IComentarioRepositorio
    {
        Comentario GetComentario(int id);
        List<Comentario> GetComentario();
        Comentario CreateComentario(Comentario comentario); 
        Comentario ActualizarComentario(Comentario comentario);
        void BorrarComentario(int id);

        List<Comentario> GetComentarioArticulo(); 

    }
}
