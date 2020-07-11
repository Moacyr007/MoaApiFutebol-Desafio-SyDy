using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    class MyContext : DbContext
    {
        public DbSet<TimeEntity> Times { get; set; }
        public DbSet<CampeonatoEntity> Campeonato { get; set; }
        public DbSet<PartidaEntity> Partida { get; set; }
        public DbSet<PontuacaoCampeonatoEntity> PontuacaoCampeonato { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TimeEntity>(new TimeMap().Configure);
        }
    }
}
