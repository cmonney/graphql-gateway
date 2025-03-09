using GraphQLDemo.Models;

namespace GraphQLDemo.Interfaces;

public interface IMenuRepository
{   
    List<Menu> GetMenus();
    Menu GetMenu(int id);
    Menu CreateMenu(Menu menu);
    Menu UpdateMenu(int id, Menu menu);
    void DeleteMenu(int id);
}