using Microsoft.EntityFrameworkCore;
using apiWeb.Models;

namespace apiWeb.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Invitado> Invitados { get; set; }
    }
}