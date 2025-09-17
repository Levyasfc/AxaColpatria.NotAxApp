using AxaColpatria.NotAxApp.Core.Models;

namespace AxaColpatria.NotAxApp.Core.Interfaces
{
    public interface ITableroRepository
    {
        Task<IEnumerable<Tablero>> GetAllAsync();
        Task<Tablero?> GetByIdAsync(int id);
        Task<Tablero> AddAsync(Tablero tablero);
        Task<bool> UpdateAsync(Tablero tablero);
        Task<bool> DeleteAsync(int id);
    }
}
