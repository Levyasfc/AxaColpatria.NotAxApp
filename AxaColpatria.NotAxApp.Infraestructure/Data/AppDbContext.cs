using System;
using Microsoft.EntityFrameworkCore;
using AxaColpatria.NotAxApp.Core.Models;

namespace AxaColpatria.NotAxApp.Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Nota> Notas { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Tablero> Tableros { get; set; } = null!;
    }
}
