using GraphQLDemo.Models;

namespace GraphQLDemo.Interfaces;

public interface ICategoryRepository
{
    List<Category> GetCategories();
    Category CreateCategory(Category category);
    Category UpdateCategory(int id, Category category);
    void DeleteCategory(int id);
}