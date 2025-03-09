using GraphQL.Types;
using GraphQLDemo.Models;

namespace GraphQLDemo.Types;

public sealed class MenuType : ObjectGraphType<Menu>
{
    public MenuType()
    {
        Field(m => m.Id);
        Field(m => m.Name);
        Field(m => m.Description);
        Field(m => m.Price);
        Field(m => m.CategoryId);
        Field(m => m.ImageUrl);
    }
}