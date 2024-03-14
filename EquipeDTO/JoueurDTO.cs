using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipeDTO
{
    public class JoueurDTO
    {
        [Required]
        public int Id { get; set; }

        [StringLength(150,MinimumLength = 2)]
        public string ?NomJoueur { get; set; }
        public string ?PrenomJoueur { get; set; }
        public int equipeFK { get; set; }

    }
}
