using GraphQL;
using GraphQL.Types;
using Services.Interface;

namespace JoueurQL.GraphQL
{
    public class JoueurQuery:ObjectGraphType
    {

        public JoueurQuery(IJoueurService joueurService)
        {
            // GET

            Field<ListGraphType<JoueurType>>(
              "joueurs",
              resolve: context => joueurService.GetAll()
          );

            // GETBYID
            Field<JoueurType>(
             "joueurs",
             arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "joueurId" }),
             resolve: context =>
             {
                 int id;
                 if (!int.TryParse(context.GetArgument<string>("joueurId"), out id))
                 {
                     context.Errors.Add(new ExecutionError("Wrong value"));
                     return null;
                 }
                 return joueurService.GetById(id);
             }
         );
        }
    }
}

