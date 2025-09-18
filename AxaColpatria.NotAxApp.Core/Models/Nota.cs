using System;
using System.Text.Json.Serialization;

namespace AxaColpatria.NotAxApp.Core.Models
{
    public class Nota
    {
        
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public bool Completada { get; set; }


        // Relacion por tablero

        [JsonIgnore]

        public int? TableroId { get; set; }
        public Tablero? Tablero { get; set; }


    }
}
