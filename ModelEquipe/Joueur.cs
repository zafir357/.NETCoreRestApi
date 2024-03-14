using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEquipe
{
    public class Joueur
    {
        public Joueur()
        {

        }

        public Joueur(int id, string nomJoueur, string prenomJoueur)
        {
            Id = id;
            this.NomJoueur = nomJoueur;
            this.PrenomJoueur = prenomJoueur;
        }

        public int Id { get; set; }
        public string NomJoueur { get; set; }
        public string PrenomJoueur { get; set; }
 
        public bool Equals(Joueur other)
        {
            return NomJoueur.Equals(other.NomJoueur)
                && PrenomJoueur.Equals(other.PrenomJoueur);

        }


        public override bool Equals(object obj)
        {
            if (obj is null) return false; // is null
            if (ReferenceEquals(obj, this)) return true; // is me
            if (!obj.GetType().Equals(GetType())) return false; // is different type
            return Equals(obj as Joueur); // is not me, is not null, is same type : send up
        }

        public override int GetHashCode()
        {
            return NomJoueur.GetHashCode()+PrenomJoueur.GetHashCode();
        }

       
    }
}
