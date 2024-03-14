using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntiteEQ
{
    public class EquipeEntity
    {
        public int Id { get; set; }
        public string NomEquipe { get; set; }
        public List<JoueurEntity> Joueurs { get; set; }
    }
}
