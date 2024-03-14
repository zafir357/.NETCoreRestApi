using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GraphRepo
    {
        private readonly EquipeContext _context;
        
        public GraphRepo(EquipeContext equipeContext)
        {
            this._context = equipeContext;
        }
        
        public IQueryable<EquipeEntity> Equipes => _context.Equipes;
    
    
    }


}
