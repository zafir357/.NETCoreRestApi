using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class JoueurEntity
    {
        public int Id { get; set; }
        public string NomJoueur { get; set; }
        public string PrenomJoueur { get; set; }

        public int EquipeForeignKey
        {
            get; set;
        }

        [ForeignKey("EquipeForeignKey")]
        public EquipeEntity EquipeEntity
        {
            get; set;
        }
    }
}
