using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IJoueurRepository
    {
        IEnumerable<JoueurEntity> GetAll();
        JoueurEntity GetById(int id);
        void Create(JoueurEntity joueur);
        void Update(JoueurEntity joueurDetails, int id);
        void Delete(JoueurEntity joueur);

    }
}
