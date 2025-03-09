using GraphQL;
using GraphQL.Types;
using GraphQLDemo.Interfaces;
using GraphQLDemo.Models;
using GraphQLDemo.Types;

namespace GraphQLDemo.Mutation;

public sealed class MenuMutation : ObjectGraphType
{
    public MenuMutation(IMenuRepository menuRepository)
    {
        Field<MenuType>("createMenu")
            .Arguments(new QueryArguments(new QueryArgument<MenuInputType> { Name = "menu" }))
            .Resolve(context => menuRepository.CreateMenu(context.GetArgument<Menu>("menu")));
        
        Field<MenuType>("updateMenu")
            .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" }, new QueryArgument<MenuInputType> { Name = "menu" }))
            .Resolve(context => menuRepository.UpdateMenu(context.GetArgument<int>("menuId", 0), context.GetArgument<Menu>("menu")));
        
        Field<StringGraphType>("deleteMenu")
            .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" }))
            .Resolve(context =>
            {
                menuRepository.DeleteMenu(context.GetArgument<int>("menuId", 0));
                return "Menu deleted";
            });
    }
}