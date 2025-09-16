using System;

namespace AxaColpatria.NotAxApp.Core.Models
{
    public class Tablero
    {

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Nota> Notas { get; set; } = new List<Nota>();


        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; } = null!;


    }
}
