using Microsoft.AspNetCore.Mvc;
using AxaColpatria.NotAxApp.Core.Interfaces;
using AxaColpatria.NotAxApp.Core.Models;
using AxaColpatria.NotAxApp.Core.DTOs;

namespace AxaColpatria.NotAxApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotasController : ControllerBase
    {
        private readonly INotaService _notaService;

        public NotasController(INotaService notaService)
        {
            _notaService = notaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotaDTO>>> GetAllNotas()
        {
            var notas = await _notaService.GetAllNotasAsync();

            var notasDTO = notas.Select(n => new NotaDTO
            {
                Titulo = n.Titulo,
                Descripcion = n.Descripcion
            });

            return Ok(notas);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<NotaDTO>> GetNotaById(int id)
        {
            var nota = await _notaService.GetNotaByIdAsync(id);
            if (nota == null) return NotFound();

            var notaDTO = new NotaDTO
            {
                Titulo = nota.Titulo,
                Descripcion = nota.Descripcion
            };

            return Ok(nota);
        }

        [HttpPost]
        public async Task<ActionResult> AddNota([FromBody] CreateNotaDTO Crearnota)
        {
            var nota = new Nota
            {
                Titulo = Crearnota.Titulo,
                Descripcion = Crearnota.Descripcion,
                UsuarioId = Crearnota.UsuarioId,
                TableroId = Crearnota.TableroId
            };

            await _notaService.AddNotaAsync(nota);
            return CreatedAtAction(nameof(GetNotaById), new { id = nota.Id }, nota);

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateNota(string titulonota, [FromBody] NotaDTO notaDTO)
        {
            if (titulonota != notaDTO.Titulo) return BadRequest();

            var nota = new Nota
            {
                Titulo = notaDTO.Titulo,
                Descripcion = notaDTO.Descripcion
            };

            await _notaService.UpdateNotaAsync(nota);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteNota(int id)
        {
            await _notaService.DeleteNotaAsync(id);
            return NoContent();
        }
    }
}
