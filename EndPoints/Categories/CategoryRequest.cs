﻿namespace LojaMVC.EndPoints.Categories;

public class CategoryRequest
{
    public string Name { get; set; }
    public bool Active { get; set; }
    public string CreatedBy { get; set; }
    public string EditedBy { get; set; }
}