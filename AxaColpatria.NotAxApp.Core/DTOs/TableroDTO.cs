
namespace AxaColpatria.NotAxApp.Core.DTOs
{
    public class TableroDTO
    {

        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<NotaDTO> Notas { get; set; } = new();
        public int UsuarioId { get; set; }


    }

    public class CreateTableroDTO
    {
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
    }
}
