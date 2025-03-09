using GraphQL.Types;
using GraphQLDemo.Interfaces;
using GraphQLDemo.Types;

namespace GraphQLDemo.Query;

public sealed class CategoryQuery : ObjectGraphType
{
    public CategoryQuery(ICategoryRepository categoryRepository)
    {
        Field<ListGraphType<CategoryType>>("categories").Resolve(_ => categoryRepository.GetCategories());
    }
}