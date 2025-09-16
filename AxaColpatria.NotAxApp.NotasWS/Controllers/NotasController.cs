using Microsoft.AspNetCore.Mvc;
using AxaColpatria.NotAxApp.Core.Interfaces;
using AxaColpatria.NotAxApp.Core.Models;

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
        public async Task<ActionResult<IEnumerable<Nota>>> GetAllNotas()
        {
            var notas = await _notaService.GetAllNotasAsync();
            return Ok(notas);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Nota>> GetNotaById(int id)
        {
            var nota = await _notaService.GetNotaByIdAsync(id);
            if (nota == null) return NotFound();
            return Ok(nota);
        }

        [HttpPost]
        public async Task<ActionResult> AddNota([FromBody] Nota nota)
        {
            await _notaService.AddNotaAsync(nota);
            return CreatedAtAction(nameof(GetNotaById), new { id = nota.Id }, nota);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateNota(int id, [FromBody] Nota nota)
        {
            if (id != nota.Id) return BadRequest();
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
