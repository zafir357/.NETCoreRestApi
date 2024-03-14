using EquipeDTO;
using ModelEquipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class JoueurDTOToDomain
    {
        public Joueur DTOToDomain(JoueurDTO jDTO)
        {

            Joueur joueur=new Joueur();
            joueur.Id = jDTO.Id;
            joueur.NomJoueur = jDTO.NomJoueur;
            joueur.PrenomJoueur = jDTO.PrenomJoueur;

            return joueur;
        }

    }
}
