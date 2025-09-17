

using AxaColpatria.NotAxApp.Core.Interfaces;
using AxaColpatria.NotAxApp.Core.Models;

namespace AxaColpatria.NotAxApp.Core.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Usuario> AddUsuarioAsync(Usuario usuario)
        {
            await _repository.AddAsync(usuario);
            return usuario;
        }

        public Task<bool> DeleteUsuarioAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetAllUsuariosAsync() => _repository.GetAllAsync();

        public Task<Usuario?> GetUsuarioByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUsuarioAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
