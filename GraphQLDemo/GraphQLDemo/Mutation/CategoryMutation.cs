using GraphQL;
using GraphQL.Types;
using GraphQLDemo.Interfaces;
using GraphQLDemo.Models;
using GraphQLDemo.Types;

namespace GraphQLDemo.Mutation;

public sealed class CategoryMutation : ObjectGraphType
{
    public CategoryMutation(ICategoryRepository categoryRepository)
    {
        Field<CategoryType>("createCategory")
            .Arguments(new QueryArguments(new QueryArgument<CategoryInputType> { Name = "category" }))
            .Resolve(context => categoryRepository.CreateCategory(context.GetArgument<Category>("category")));
        
        Field<CategoryType>("updateCategory")
            .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "categoryId" }, new QueryArgument<CategoryInputType> { Name = "category" }))
            .Resolve(context => categoryRepository.UpdateCategory(context.GetArgument<int>("categoryId", 0), context.GetArgument<Category>("category")));
        
        Field<StringGraphType>("deleteCategory")
            .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "categoryId" }))
            .Resolve(context =>
            {
                categoryRepository.DeleteCategory(context.GetArgument<int>("categoryId", 0));
                return "Category deleted";
            });
    }
}