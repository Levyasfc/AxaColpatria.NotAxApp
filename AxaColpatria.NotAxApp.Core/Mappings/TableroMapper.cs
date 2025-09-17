using AxaColpatria.NotAxApp.Core.DTOs;
using AxaColpatria.NotAxApp.Core.Models;

namespace AxaColpatria.NotAxApp.Core.Mappings
{
    public static class TableroMapper
    {

        public static TableroDTO ToDTO(Tablero tablero)
        {
            return new TableroDTO
            {
                Id = tablero.Id,
                Nombre = tablero.Nombre
            };
        }

        public static CreateTableroDTO ToEntity(Tablero tablero)
        {
            return new CreateTableroDTO
            {
                Nombre = tablero.Nombre
            };
        }



    }
}
