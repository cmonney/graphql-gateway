using GraphQL.Types;
using GraphQLDemo.Interfaces;
using GraphQLDemo.Models;

namespace GraphQLDemo.Types;

public sealed class CategoryType : ObjectGraphType<Category>
{
    public CategoryType(IMenuRepository menuRepository)
    {
        Field(c => c.Id);
        Field(c => c.Name);
        Field(c => c.ImageUrl);
        Field<ListGraphType<MenuType>>("menus").Resolve(context => menuRepository.GetMenus());
    }
}