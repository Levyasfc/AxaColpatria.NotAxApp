using AxaColpatria.NotAxApp.Core.Interfaces;
using AxaColpatria.NotAxApp.Core.Models;
using AxaColpatria.NotAxApp.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AxaColpatria.NotAxApp.Infraestructure.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly AppDbContext _context;

        public NotaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Nota>> GetAllAsync()
        {
            return await _context.Notas.ToListAsync();
        }

        public async Task<Nota?> GetByIdAsync(int id)
        {
            return await _context.Notas.FindAsync(id);
        }

        public async Task AddAsync(Nota nota)
        {
            await _context.Notas.AddAsync(nota);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Nota nota)
        {
            _context.Notas.Update(nota);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var nota = await _context.Notas.FindAsync(id);
            if (nota != null)
            {
                _context.Notas.Remove(nota);
                await _context.SaveChangesAsync();
            }
        }
    }
}
