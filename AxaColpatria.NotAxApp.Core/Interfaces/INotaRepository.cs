using AxaColpatria.NotAxApp.Core.Models;

namespace AxaColpatria.NotAxApp.Core.Interfaces
{
    public interface INotaRepository
    {
        Task<IEnumerable<Nota>> GetAllAsync();
        Task<Nota?> GetByIdAsync(int id);
        Task AddAsync(Nota nota);
        Task UpdateAsync(Nota nota);
        Task DeleteAsync(int id);
    }
}
