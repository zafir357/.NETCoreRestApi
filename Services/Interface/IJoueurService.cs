using System;
using EquipeDTO;
namespace Services.Interface
{
	public interface IJoueurService
	{
        IEnumerable<JoueurDTO> GetAll();
        JoueurDTO GetById(int id);
        void Create(JoueurDTO joueur);
        void Update(JoueurDTO joueur, int id);
        void Delete(JoueurDTO joueur);
    }
}

