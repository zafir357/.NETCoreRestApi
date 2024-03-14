using EquipeDTO;
using GraphQL.Types;

namespace JoueurQL.GraphQL
{
    public class JoueurType : ObjectGraphType<JoueurDTO>
    {
        public JoueurType()
        {
            Field(x => x.Id);
            Field(x => x.NomJoueur);
            Field(x => x.PrenomJoueur);
        }
    }
}
