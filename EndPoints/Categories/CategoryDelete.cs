using LojaMVC.Domain.Infra.Database;
using LojaMVC.Domain.Product;

namespace LojaMVC.EndPoints.Categories;

public class CategoryDelete
{

        public static string Template => "/categories/{Id}";
        public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(Guid Id, ApplicationDbContext context)
    {
        var category = context.Categories.Where(c => c.Id == Id).FirstOrDefault();
        if (category != null)
        {
            context.Categories.Remove(category);
        }
        context.SaveChanges();

        return Results.Ok();
        }
    
}
