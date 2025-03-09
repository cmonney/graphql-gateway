using GraphQLDemo.Mutation;
using GraphQLDemo.Query;

namespace GraphQLDemo.Schema;

public class MenuSchema : GraphQL.Types.Schema
{
    public MenuSchema(MenuQuery menuQuery, MenuMutation menuMutation)
    {
        Query = menuQuery;
        Mutation = menuMutation;
    }
}