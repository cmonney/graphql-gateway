using GraphQL.Types;

namespace GraphQLDemo.Types;

public sealed class MenuInputType : InputObjectGraphType
{
    public MenuInputType()
    {
        Field<StringGraphType>("name");
        Field<StringGraphType>("description");
        Field<DecimalGraphType>("price");
        Field<StringGraphType>("imageUrl");
        Field<IntGraphType>("categoryId");
    }
}