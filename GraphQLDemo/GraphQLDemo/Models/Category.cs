using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLDemo.Models;

public class Category
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public ICollection<Menu> Menus { get; set; }
}