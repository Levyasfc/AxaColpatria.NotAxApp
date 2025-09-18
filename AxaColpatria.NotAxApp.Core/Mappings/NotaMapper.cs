using AutoMapper;
using AxaColpatria.NotAxApp.Core.Models;
using AxaColpatria.NotAxApp.Core.DTOs;

namespace AxaColpatria.NotAxApp.Core.Mappings
{
    public static class NotaMapper
    {
        public static NotaDTO ToDTO(Nota nota)
        {
            return new NotaDTO
            {
            
                Titulo = nota.Titulo,
                Descripcion = nota.Descripcion,
                TableroId = (int)nota.TableroId
            };
        }

        public static Nota ToEntity(CreateNotaDTO dto)
        {
            return new Nota
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                TableroId = dto.TableroId
            };
        }

        public static void UpdateEntity(UpdateNotaDTO dto, Nota nota)
        {
            nota.Titulo = dto.Titulo;
            nota.Descripcion = dto.Descripcion;
            // Nota: UsuarioId y TableroId no se actualizan aquí
        }
    }
}