using GraphQLDemo.Data;
using GraphQLDemo.Interfaces;
using GraphQLDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Services;

public class CategoryRepository(AppDbContext dbContext) : ICategoryRepository
{
    public List<Category> GetCategories()
    {
        return dbContext.Categories.AsNoTracking().AsQueryable().ToList();
    }

    public Category CreateCategory(Category category)
    {
        dbContext.Categories.Add(category);
        dbContext.SaveChanges();
        return category;
    }

    public Category UpdateCategory(int id, Category category)
    {
        var categoryToUpdate = dbContext.Categories.FirstOrDefault(c => c.Id == id);
        
        if (categoryToUpdate == null) return null;

        categoryToUpdate.Name = category.Name;
        categoryToUpdate.ImageUrl = category.ImageUrl;
        dbContext.Categories.Update(categoryToUpdate);
        dbContext.SaveChanges();
        
        return categoryToUpdate;
    }

    public void DeleteCategory(int id)
    {
        var category = dbContext.Categories.AsNoTracking().FirstOrDefault(c => c.Id == id);
        if (category == null) return;
        
        dbContext.Categories.Remove(category);
        dbContext.SaveChanges();
    }
}