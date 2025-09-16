using System;

namespace AxaColpatria.NotAxApp.Core.Models
{
    public class Nota
    {
        
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public bool Completada { get; set; }


        // Relaciones
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public int? TableroId { get; set; }
        public Tablero? Tablero { get; set; }


    }
}
