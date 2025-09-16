using Microsoft.AspNetCore.Mvc;
using AxaColpatria.NotAxApp.Core.Interfaces;
using AxaColpatria.NotAxApp.Core.Models;

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
        public async Task<IActionResult> GetBoards()
            => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoard(int id)
        {
            var board = await _repository.GetByIdAsync(id);
            if (board == null) return NotFound();
            return Ok(board);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoard([FromBody] Tablero tablero)
        {
            var nuevo = await _repository.AddAsync(tablero);
            return CreatedAtAction(nameof(GetBoard), new { id = nuevo.Id }, nuevo);
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
