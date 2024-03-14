using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class JoueurRepository : IJoueurRepository
    {
        private readonly EquipeContext _context;


        public JoueurRepository(EquipeContext context)
        {
            _context = context;
        }
        public void Create(JoueurEntity joueur)
        {
            _context.Joueurs.Add(joueur);
            _context.SaveChanges();
        }

        public void Delete(JoueurEntity joueur)
        {
            _context.Joueurs.Remove(joueur);
            _context.SaveChanges();
        }

        public IEnumerable<JoueurEntity> GetAll()
        {
            return _context.Joueurs.ToList<JoueurEntity>();
        }

        public JoueurEntity GetById(int id)
        {
            return _context.Joueurs.Find(id);
        }

        public void Update(JoueurEntity joueurDetails, int id)
        {
            var joueur = _context.Joueurs.Find(id);
            if (joueur.Id != null)
            {
                joueur.Id = joueurDetails.Id;
                joueur.NomJoueur = joueurDetails.NomJoueur;
                joueur.PrenomJoueur = joueurDetails.PrenomJoueur;
                joueur.EquipeForeignKey = joueurDetails.EquipeForeignKey;
            }
            else
            {
                return;
            }
            _context.Joueurs.Update(joueur);
            _context.SaveChanges();
        }
    }
}
