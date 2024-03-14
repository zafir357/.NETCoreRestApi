using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipeDTO
{
    public class EquipeDTO
    {
        [Required]     
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string ?nomEquipe { get; set; }
        public List<int> ?idJoueur { get; set; }

    }
}
