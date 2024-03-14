using ModelEquipe;
using System.Collections.Generic;

namespace Stub
{
    public class StubEquipe
    {
       public List<Joueur> joueurs = new List<Joueur>
        {
            new Joueur(1,"Essien","Michael"),
            new Joueur(2,"Rooney","Wayne"),
            new Joueur(3,"Zidane","Zinedine"),
            new Joueur(4,"Papin","Jean-Papierre"),
            new Joueur(5,"h","h"),
        };

        public Equipe equipe;
        public StubEquipe()
        {
            equipe = new Equipe(1, "Equipe1", joueurs);
        }
       
    }
}