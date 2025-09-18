using AxaColpatria.NotAxApp.Core.Models;

namespace AxaColpatria.NotAxApp.Core.DTOs
{

    public class UserDTO{

        public int Id { get; set; }
        public string Nombre{ get; set; }

        public List<TableroDTO> Tableros { get; set; } = new();
    }

    public class CreateUserDTO
    {
        public string Nombre { get; set; }
    }

}
