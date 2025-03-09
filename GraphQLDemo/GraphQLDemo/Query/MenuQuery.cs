using GraphQL;
using GraphQL.Types;
using GraphQLDemo.Interfaces;
using GraphQLDemo.Types;

namespace GraphQLDemo.Query;

public sealed class MenuQuery : ObjectGraphType
{
    public MenuQuery(IMenuRepository menuRepository)
    {
        Field<ListGraphType<MenuType>>("menus").Resolve(_ => menuRepository.GetMenus());
        Field<MenuType>("menu")
            .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" }))
            .Resolve(context => menuRepository.GetMenu(context.GetArgument<int>("menuId", 0)));
    }
}