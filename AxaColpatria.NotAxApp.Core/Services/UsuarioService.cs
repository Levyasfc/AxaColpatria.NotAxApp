

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

        public Task<IEnumerable<Usuario>> GetAllUsuariosAsync() => _repository.GetAllAsync();

        public Task<Usuario?> GetUsuarioByIdAsync(int id) => _repository.GetByIdAsync(id);  

        public async Task<Usuario> AddUsuarioAsync(Usuario usuario)
        {
            await _repository.AddAsync(usuario);
            return usuario;
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return true;
        }

        

        public async Task<bool> UpdateUsuarioAsync(Usuario usuario)
        {
            await _repository.UpdateAsync(usuario);
            return true;
        }
    }
}
