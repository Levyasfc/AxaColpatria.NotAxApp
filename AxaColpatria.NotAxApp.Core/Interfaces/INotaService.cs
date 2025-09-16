using AxaColpatria.NotAxApp.Core.Models;

namespace AxaColpatria.NotAxApp.Core.Interfaces
{
    public interface INotaService
    {
        Task<IEnumerable<Nota>> GetAllNotasAsync();
        Task<Nota?> GetNotaByIdAsync(int id);
        Task AddNotaAsync(Nota nota);
        Task UpdateNotaAsync(Nota nota);
        Task DeleteNotaAsync(int id);
    }
}
