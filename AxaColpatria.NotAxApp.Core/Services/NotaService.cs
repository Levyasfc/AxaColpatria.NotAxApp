using AxaColpatria.NotAxApp.Core.Interfaces;
using AxaColpatria.NotAxApp.Core.Models;

namespace AxaColpatria.NotAxApp.Infraestructure.Services
{
    public class NotaService : INotaService
    {
        private readonly INotaRepository _repository;

        public NotaService(INotaRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Nota>> GetAllNotasAsync() => _repository.GetAllAsync();

        public Task<Nota?> GetNotaByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task AddNotaAsync(Nota nota) => _repository. AddAsync(nota);

        public Task UpdateNotaAsync(Nota nota) => _repository.UpdateAsync(nota);

        public Task DeleteNotaAsync(int id) => _repository.DeleteAsync(id);
    }
}
