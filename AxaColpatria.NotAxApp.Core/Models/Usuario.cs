namespace AxaColpatria.NotAxApp.Core.Models
{
    public class Usuario
    {
        public static int? UsuarioId { get; internal set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Tablero>? Tableros { get; set; } = new List<Tablero>();

    }
}
