using AxaColpatria.NotAxApp.Core.Interfaces;
using AxaColpatria.NotAxApp.Core.Models;
using AxaColpatria.NotAxApp.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AxaColpatria.NotAxApp.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
            => await _context.Usuarios.Include(u => u.Tableros).ToListAsync();

        public async Task<Usuario?> GetByIdAsync(int id)
            => await _context.Usuarios.Include(u => u.Tableros).FirstOrDefaultAsync(u => u.Id == id);

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
