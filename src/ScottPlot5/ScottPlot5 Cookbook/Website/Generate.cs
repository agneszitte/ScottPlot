﻿namespace ScottPlotCookbook.Website;

internal class Generate
{
    [Test]
    public void Generate_Website()
    {
        Dictionary<ICategory, IEnumerable<WebRecipe>> rbc = Query.GetWebRecipesByCategory();
        GenerateHomePage(rbc);
        GenerateCategoryPages(rbc);
        GenerateRecipePages(rbc);
        Console.WriteLine(Paths.OutputFolder);
    }

    private static void GenerateHomePage(Dictionary<ICategory, IEnumerable<WebRecipe>> rbc)
    {
        new FrontPage(rbc).Generate(Paths.OutputFolder);
    }

    private static void GenerateCategoryPages(Dictionary<ICategory, IEnumerable<WebRecipe>> rbc)
    {
        string categoryOutputFolder = Path.Combine(Paths.OutputFolder, "category");
        foreach (ICategory category in rbc.Keys)
        {
            new CategoryPage(rbc, category).Generate(categoryOutputFolder);
        }
    }

    private static void GenerateRecipePages(Dictionary<ICategory, IEnumerable<WebRecipe>> rbc)
    {
        string recipeOutputFolder = Path.Combine(Paths.OutputFolder, "recipe");
        foreach (ICategory category in rbc.Keys)
        {
            foreach (WebRecipe recipe in rbc[category])
            {
                new RecipePage(recipe).Generate(recipeOutputFolder);
            }
        }
    }
}
