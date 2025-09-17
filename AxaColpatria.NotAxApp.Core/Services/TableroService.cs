using AxaColpatria.NotAxApp.Core.Interfaces;
using AxaColpatria.NotAxApp.Core.Models;

namespace AxaColpatria.NotAxApp.Core.Services
{
    public class TableroService : ITableroService
    {

        private readonly ITableroRepository _repository;

        public TableroService(ITableroRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Tablero>> GetAllTablerosAsync() => _repository.GetAllAsync();

        public Task<Tablero?> GetTableroByIdAsync(int id) => _repository.GetByIdAsync(id);

        public async Task<Tablero> AddTableroAsync(Tablero tablero)
        {
            await _repository.AddAsync(tablero);
            return tablero; 
        }

        public async Task<bool> UpdateTableroAsync(Tablero tablero)
        {
            await _repository.UpdateAsync(tablero);
            return true;
        }

        public async Task<bool> DeleteTableroAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
    
    
