using System;
using EquipeDTO;

namespace Services.Interface
{
	public interface IEquipeService
	{
        IEnumerable<EquipeDTO.EquipeDTO> GetAll();
        EquipeDTO.EquipeDTO GetById(int id);
/*        EquipeDTO.EquipeDTO GetById(int id);*/
        void Create(EquipeDTO.EquipeDTO equipe);
        void Update(EquipeDTO.EquipeDTO equipe,int id);
        void Delete(EquipeDTO.EquipeDTO equipe);
        dynamic GetJoueurByEquipe(int id, int joueurId);

    }
}

