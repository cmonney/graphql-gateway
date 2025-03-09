using GraphQL.Types;

namespace GraphQLDemo.Types;

public sealed class CategoryInputType : InputObjectGraphType
{
    public CategoryInputType()
    {
        Field<StringGraphType>("name");
        Field<StringGraphType>("imageUrl");
    }
}