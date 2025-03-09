using GraphQLDemo.Data;
using GraphQLDemo.Interfaces;
using GraphQLDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Services;

public class MenuRepository(AppDbContext dbContext) : IMenuRepository
{
   
    public List<Menu> GetMenus()
    {
        return dbContext.Menus.AsNoTracking().AsQueryable().ToList();
    }

    public Menu GetMenu(int id)
    {
        return dbContext.Menus.AsNoTracking().AsQueryable().FirstOrDefault(m => m.Id == id);
    }

    public Menu CreateMenu(Menu menu)
    {
        dbContext.Menus.Add(menu);
        dbContext.SaveChanges();
        return menu;
    }

    public Menu UpdateMenu(int id, Menu menu)
    {
        var menuToUpdate = dbContext.Menus.FirstOrDefault(m => m.Id == id);
        if (menuToUpdate == null) return null;
        
        menuToUpdate.Name = menu.Name;
        menuToUpdate.Description = menu.Description;
        menuToUpdate.Price = menu.Price;
            
        dbContext.Menus.Update(menuToUpdate);
        dbContext.SaveChanges();
        
        return menuToUpdate;
    }

    public void DeleteMenu(int id)
    {
        var menu = dbContext.Menus.AsNoTracking().FirstOrDefault(m => m.Id == id);
        if (menu == null) return;
        
        dbContext.Menus.Remove(menu);
        dbContext.SaveChanges();
    }
}