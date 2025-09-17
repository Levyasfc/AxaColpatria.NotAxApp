using AxaColpatria.NotAxApp.Core.DTOs;
using AxaColpatria.NotAxApp.Core.Models;

namespace AxaColpatria.NotAxApp.Core.Mappings
{
    public static class UserMapper
    {

        public static UserDTO ToDTO(Usuario usuario){

            return new UserDTO
            {
                Nombre = usuario.Nombre
            };
                    
        }

        public static CreateUserDTO ToEntity(Usuario usuario)
        {
            return new CreateUserDTO
            {
                Nombre = usuario.Nombre
            };
        }

    }
}
