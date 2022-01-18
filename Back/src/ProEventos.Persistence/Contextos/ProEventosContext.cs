using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contextos
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options)
        {

        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }

        //ASSOCIAÇÃO N-N
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new { PE.eventoId, PE.palestranteId });

            // Deletar rede social em modo cascata ao deletar o evento
            modelBuilder.Entity<Evento>()
                .HasMany(e => e.redesSociais)
                .WithOne(rs => rs.evento)
                .OnDelete(DeleteBehavior.Cascade);

            // Deletar rede social em modo cascata ao deletar o palestrante
            modelBuilder.Entity<Palestrante>()
                .HasMany(p => p.redesSoiais)
                .WithOne(rs => rs.palestrante)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}