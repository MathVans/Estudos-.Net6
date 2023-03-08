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


        var category = new Category(categoryRequest.Name,
                                    categoryRequest.CreatedBy,
                                    categoryRequest.EditedBy
                                                            );

        if (!category.IsValid)
        {
            return Results.BadRequest(category.Notifications);
        }

        context.Categories.Add(category);
        context.SaveChanges();

        return Results.Created($"/categories{category.Id}", category.Id);
        }
    
}
