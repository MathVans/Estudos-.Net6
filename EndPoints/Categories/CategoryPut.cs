using LojaMVC.Domain.Infra.Database;
using LojaMVC.Domain.Product;
using Microsoft.AspNetCore.Mvc;

namespace LojaMVC.EndPoints.Categories;

public class CategoryPut
{

        public static string Template => "/categories/{id:guid}";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute]Guid id, CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();
        if (category == null) 
            return Results.NotFound();

        category.EditInfo(categoryRequest.Name, categoryRequest.Active);

        if (!category.IsValid)
        {
            return Results.ValidationProblem(category.Notifications.ConvertProblemDetails());
        }

        context.SaveChanges();

        return Results.Ok();
        }
    
}
