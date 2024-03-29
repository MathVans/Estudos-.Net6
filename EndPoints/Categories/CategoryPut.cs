﻿using LojaMVC.Domain.Infra.Database;
using LojaMVC.Domain.Product;
using Microsoft.AspNetCore.Mvc;

namespace LojaMVC.EndPoints.Categories;

public class CategoryPut
{

        public static string Template => "/categories/{id}";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute]Guid id, CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();

        category.Name = categoryRequest.Name;
        category.Active = categoryRequest.Active;
   
        context.SaveChanges();

        return Results.Ok();
        }
    
}
