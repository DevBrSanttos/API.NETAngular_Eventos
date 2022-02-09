using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Domain.Identity;

namespace ProEventos.Persistence.Contextos
{
    public class ProEventosContext : IdentityDbContext<User, Role, int,
                                                       IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                                       IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options)
            : base(options) { }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Informar as chaves estrangeiras na tabela de associação
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new { PE.EventoId, PE.PalestranteId });

            // Deletar rede social em modo cascata ao deletar o evento
            modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            // Deletar rede social em modo cascata ao deletar o palestrante
            modelBuilder.Entity<Palestrante>()
                .HasMany(p => p.RedesSoiais)
                .WithOne(rs => rs.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);


            // Outra forma de fazer o relacionamento N-N
            modelBuilder.Entity<UserRole>(userRole =>
                {
                    userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                    userRole.HasOne(ur => ur.role)
                        .WithMany(r => r.userRoles)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();

                    userRole.HasOne(ur => ur.user)
                        .WithMany(r => r.userRoles)
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired();
                }
            );

        }

    }
}