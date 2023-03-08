using LojaMVC.Domain.Infra.Database;
using LojaMVC.Domain.Product;

namespace LojaMVC.EndPoints.Categories;

public class CategoryPost
{

        public static string Template => "/categories";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        if (string.IsNullOrEmpty(categoryRequest.Name))
            return Results.BadRequest("Name is required");
        
        var category = new Category {
            Name = categoryRequest.Name,
            CreatedBy = categoryRequest.CreatedBy

        };

        context.Categories.Add(category);
        context.SaveChanges();

        return Results.Created($"/categories{category.Id}", category.Id);
        }
    
}
