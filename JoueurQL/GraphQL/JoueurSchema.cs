using GraphQL.Types;

namespace JoueurQL.GraphQL
{
    public class JoueurSchema:Schema
    {
        public JoueurSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<JoueurQuery>();
        }
    }
}
