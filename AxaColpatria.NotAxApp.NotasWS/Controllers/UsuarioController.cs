using Microsoft.AspNetCore.Mvc;
using AxaColpatria.NotAxApp.Core.Interfaces;
using AxaColpatria.NotAxApp.Core.Models;
using AxaColpatria.NotAxApp.Core.DTOs;

namespace AxaColpatria.NotAxApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _repository.GetAllAsync();

            var usuariosDTO = usuarios.Select(u => new UserDTO

            {
                Id = u.Id,
                Nombre = u.Nombre,
                Tableros = u.Tableros?.Select(t => new TableroDTO

                {
                    Id = t.Id,
                    Nombre = t.Nombre
                }).ToList()
            }).ToList();

            return Ok(usuariosDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _repository.GetByIdAsync(id);
            if (usuario == null) return NotFound();
            

            var dto = new UserDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Tableros = usuario.Tableros?.Select(t=> new TableroDTO

                {
                Id = t.Id,
                Nombre = t.Nombre
                }
                ).ToList()
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] UserDTO usuario)
        {
            var nuevousuario = new Usuario
            {
                Nombre = usuario.Nombre
            };

            await _repository.AddAsync(nuevousuario);

            return CreatedAtAction(nameof(GetUsuario), new { id = nuevousuario.Id }, nuevousuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id) return BadRequest();
            var result = await _repository.UpdateAsync(usuario);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
