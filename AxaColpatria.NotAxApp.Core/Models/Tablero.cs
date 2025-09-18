using System;
using System.Text.Json.Serialization;

namespace AxaColpatria.NotAxApp.Core.Models
{
    public class Tablero
    {

        public int Id { get; set; }
        public string Nombre { get; set; }

        //Relacion con TABLERO

        public ICollection<Nota> Notas { get; set; } = new List<Nota>();

        //Relacion Usuario
        [JsonIgnore]

        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; } 


    }
}
