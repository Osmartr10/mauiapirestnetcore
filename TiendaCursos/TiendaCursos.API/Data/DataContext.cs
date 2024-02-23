using Microsoft.EntityFrameworkCore;
using TiendaCursos.Shared;

namespace TiendaCursos.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) 
        { 
        }

        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Curso>().HasIndex(c=> c.Nombre).IsUnique();
        }
    }
}
