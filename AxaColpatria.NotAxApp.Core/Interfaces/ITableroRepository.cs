using AxaColpatria.NotAxApp.Core.Models;

namespace AxaColpatria.NotAxApp.Core.Interfaces
{
    public interface ITableroRepository
    {
        Task<IEnumerable<Tablero>> GetAllTablerosAsync();
        Task<Tablero?> GetTableroByIdAsync(int id);
        Task<Tablero> AddTableroAsync(Tablero tablero);
        Task<bool> UpdateTableroAsync(Tablero tablero);
        Task<bool> DeleteTableroAsync(int id);
    }
}
