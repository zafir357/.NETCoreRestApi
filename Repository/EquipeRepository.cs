using Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EquipeRepository : IEquipeRepository
    {
        private readonly EquipeContext _context;


        public EquipeRepository(EquipeContext context)
        {
            _context = context;

        }
        public void Create(EquipeEntity equipe)
        {
            _context.Equipes.Add(equipe);
            _context.SaveChanges();
        }

        public void Delete(EquipeEntity equipe)
        {
            _context.Equipes.Remove(equipe);
            _context.SaveChanges();
        }

        public IEnumerable<EquipeEntity> GetAll()
        {
            return _context.Equipes               
                .Include(a => a.Joueurs)
                .Select(a => new EquipeEntity
                {
                    Id = a.Id,
                    NomEquipe = a.NomEquipe,
                    Joueurs = a.Joueurs.Select(p => new JoueurEntity { Id = p.Id}).ToList()
                })
                .ToList();
        }

        public EquipeEntity GetById(int id)
        {
            EquipeEntity equipe=null;
            if (_context.Equipes.Find(id) != null)
            {
                equipe = _context.Equipes
                .Where(a => a.Id == id)
                .Include(a => a.Joueurs)
                .Select(a => new EquipeEntity
                {
                    Id = a.Id,
                    NomEquipe = a.NomEquipe,
                    Joueurs = a.Joueurs.Select(p => new JoueurEntity { Id = p.Id }).ToList()
                }).FirstOrDefault();

            }
            
            if(equipe != null)
            {
                return equipe;
            }
            else
            {
                return null;
            }
        }
       /* public EquipeEntity GetById(int id)
        {
            EquipeEntity equipe = null;
            return _context.Equipes.Find(id);
        }*/



        public dynamic GetJoueurEquipeById(int id, int joueurId)
        {
            var joueur= _context.Joueurs
                 .Where(a => a.Id == joueurId)
                 .Where(a =>a.EquipeEntity.Id==id)
                .Select(a => new JoueurEntity
                {
                    Id = a.Id,
                    NomJoueur = a.NomJoueur,
                    PrenomJoueur = a.PrenomJoueur,
                    EquipeForeignKey = a.EquipeForeignKey,

                })
                .ToList();

            return joueur;
        }


        public void Update(EquipeEntity equipeDetails, int id)
        {

            var equipe = _context.Equipes.Find(id);
            if (equipe.Id != null)
                {
                    equipe.Id = equipeDetails.Id;
                    equipe.NomEquipe = equipeDetails.NomEquipe;
                    equipe.Joueurs= equipeDetails.Joueurs;  
                }
                else
                {
                    return;
                }
                _context.Equipes.Update(equipe);
                _context.SaveChanges();


        }
    }
}
