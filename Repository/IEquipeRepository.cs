using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IEquipeRepository
    {
        IEnumerable<EquipeEntity> GetAll();
  /*      EquipeEntity GetById(int id);*/
        dynamic GetJoueurEquipeById(int id, int joueurId);
        EquipeEntity GetById(int id);
        void Create(EquipeEntity eq);
        void Update(EquipeEntity eq,int id);
        void Delete(EquipeEntity eq);
    }
}
