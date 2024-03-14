using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntiteEQ
{
    public class EQContext:DbContext
    {
        public DbSet<EquipeEntity> Equipes { get; set; }

        public DbSet<JoueurEntity> Joueurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=EF.Equipe.db;");
    }
}
