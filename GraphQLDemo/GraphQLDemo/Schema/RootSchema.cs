using GraphQLDemo.Mutation;
using GraphQLDemo.Query;

namespace GraphQLDemo.Schema;

public class RootSchema : GraphQL.Types.Schema
{
    public RootSchema(IServiceProvider serviceProvider): base(serviceProvider)
    {
        Query = serviceProvider.GetService<RootQuery>();
        Mutation = serviceProvider.GetService<RootMutation>();
    }
}