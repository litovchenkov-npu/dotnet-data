using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Product> inventory = new List<Product>
        {
            new Product("Laptop", "Electronics", 1200),
            new Product("Phone", "Electronics", 800),
            new Product("Desk", "Furniture", 300),
            new Product("Chair", "Furniture", 150),
            new Product("Mouse", "Electronics", 50),
            new Product("Keyboard", "Electronics", 100)
        };

        var electronics = inventory.Where(p => p.Category == "Electronics");
        var firstExpensiveItem = inventory.FirstOrDefault(p => p.Price > 1000);
        var productNames = inventory.Select(p => p.Name);

        var sortedByName = inventory.OrderBy(p => p.Name);
        var sortedByCategoryAndPrice = inventory.OrderBy(p => p.Category).ThenByDescending(p => p.Price);
        var reversedInventory = inventory.AsEnumerable().Reverse();

        var uniqueCategories = inventory.Select(p => p.Category).Distinct();
        var groupedByCategory = inventory.GroupBy(p => p.Category);
        var parallelProcessing = inventory.AsParallel().Where(p => p.Price > 100);

        Console.WriteLine("Electronics:");
        foreach (var item in electronics) Console.WriteLine(item);

        Console.WriteLine($"First expensive item: {firstExpensiveItem}");

        Console.WriteLine("Sorted by Name:");
        foreach (var item in sortedByName) Console.WriteLine(item);

        Console.WriteLine("Sorted by Category and Price:");
        foreach (var item in sortedByCategoryAndPrice) Console.WriteLine(item);

        Console.WriteLine("Unique Categories:");
        foreach (var category in uniqueCategories) Console.WriteLine(category);
    }
}

class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }

    public Product(string name, string category, double price)
    {
        Name = name;
        Category = category;
        Price = price;
    }

    public override string ToString() => $"{Name} ({Category}) - ${Price}";
}