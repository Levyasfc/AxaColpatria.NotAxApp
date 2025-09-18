using Microsoft.AspNetCore.Mvc;
using AxaColpatria.NotAxApp.Core.Interfaces;
using AxaColpatria.NotAxApp.Core.Models;
using AxaColpatria.NotAxApp.Core.DTOs;

namespace AxaColpatria.NotAxApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableroController : ControllerBase
    {
        private readonly ITableroRepository _repository;

        public TableroController(ITableroRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTableros()
        
            {
                var tableros = await _repository.GetAllAsync();

                var tablerosDTO = tableros.Select(u => new TableroDTO

                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Notas = u.Notas?.Select(t => new NotaDTO

                    {
                        Id = t.Id,
                        Titulo = t.Titulo
                    }).ToList()
                }).ToList();

                return Ok(tablerosDTO);
            }

           

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoard(int id)
        {
            var board = await _repository.GetByIdAsync(id);
            if (board == null) return NotFound();
            return Ok(board);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoard([FromBody] TableroDTO tablero)
        {
            var tableronew = new Tablero
            {
                Nombre = tablero.Nombre,
                UsuarioId = tablero.UsuarioId
            };

            var createdTablero = await _repository.AddAsync(tableronew);
            return CreatedAtAction(nameof(GetBoard), new { id = createdTablero.Id }, createdTablero);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBoard(int id, [FromBody] Tablero tablero)
        {
            if (id != tablero.Id) return BadRequest();
            var result = await _repository.UpdateAsync(tablero);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoard(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
