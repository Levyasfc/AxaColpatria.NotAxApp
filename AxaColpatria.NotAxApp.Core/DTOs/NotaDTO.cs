using System;

namespace AxaColpatria.NotAxApp.Core.DTOs

{

    // No se uso inyecccion de dependencias para los DTOs porque son clases simples sin lógica
    public class NotaDTO
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }
        public int TableroId { get; set; }
    }

    // Para crear
    public class CreateNotaDTO
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }
        public int TableroId { get; set; }
    }

    // Para actualizar
    public class UpdateNotaDTO
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
    }
}