using AxaColpatria.NotAxApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxaColpatria.NotAxApp.Core.Interfaces
{
    public interface ITableroService
    {
        Task<IEnumerable<Tablero>> GetAllTablerosAsync();
        Task<Tablero?> GetTableroByIdAsync(int id);
        Task<Tablero> AddTableroAsync(Tablero tablero);
        Task<bool> UpdateTableroAsync(Tablero tablero);
        Task<bool> DeleteTableroAsync(int id);

    }
}
