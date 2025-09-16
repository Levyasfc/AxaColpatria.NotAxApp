namespace AxaColpatria.NotAxApp.Core.Models
{
    public class Usuario
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Tablero>? Tableros { get; set; } = new List<Tablero>();

    }
}
