using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEquipe
{
    public class Equipe
    {

        public int Id { get; set; }
        public string NomEquipe { get; set; }
        public List<Joueur> Joueurs { get; set;}

        public Equipe()
        {

        }


        public Equipe(int id, string nomEquipe, List<Joueur> joueurs)
        {
            Id = id;
            this.NomEquipe = nomEquipe;
            this.Joueurs = joueurs ?? throw new ArgumentNullException(nameof(joueurs));
        }


        public void addJoueur(Joueur joueur)
        {
            Joueurs.Add(joueur);
        }

        public void removeJoueur(Joueur joueur)
        {
            Joueurs.Remove(joueur);
        }

        


    }
}
