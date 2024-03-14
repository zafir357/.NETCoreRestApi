using Microsoft.EntityFrameworkCore;
using ModelEquipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class EquipeContext:DbContext
    {
        public EquipeContext() { }

        public EquipeContext(DbContextOptions<EquipeContext> options) : base(options) { }
        public DbSet<EquipeEntity> Equipes { get; set; }
        public DbSet<JoueurEntity> Joueurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
         => options.UseSqlite($"Data Source=EF.Equipe.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EquipeEntity manu = new EquipeEntity { Id = 1, NomEquipe = "Manu" };
            EquipeEntity psg = new EquipeEntity { Id = 2, NomEquipe = "PSG" };
            modelBuilder.Entity<EquipeEntity>().HasData(manu, psg);

            modelBuilder.Entity<JoueurEntity>().HasData(new JoueurEntity { Id = 1, NomJoueur = "Nom", PrenomJoueur = "Prenom", EquipeForeignKey =1 },
                                                        new JoueurEntity { Id = 2, NomJoueur = "Nom2", PrenomJoueur = "Prenom2", EquipeForeignKey=2 },
                                                        new JoueurEntity { Id = 3, NomJoueur = "Nom3", PrenomJoueur = "Prenom3", EquipeForeignKey = 2 });
        }
    }

}
