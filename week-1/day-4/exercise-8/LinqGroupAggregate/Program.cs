namespace LinqGroupAggregate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of Product objects
            List<Product> products = new List<Product>
        {
            new Product { Name = "Laptop", Category = "Electronics", Price = 1200.00M },
            new Product { Name = "Smartphone", Category = "Electronics", Price = 800.00M },
            new Product { Name = "Headphones", Category = "Electronics", Price = 200.00M },
            new Product { Name = "Shirt", Category = "Clothing", Price = 30.00M },
            new Product { Name = "Jeans", Category = "Clothing", Price = 60.00M },
            new Product { Name = "Sneakers", Category = "Footwear", Price = 100.00M }
        };

            // Use LINQ to perform the following operations:
            // 1. Group products by category
            var groupByCategory = products.GroupBy(x => x.Category).ToList();
            foreach (var categoryGroup in groupByCategory)
            {
                Console.WriteLine("Category: "+categoryGroup.Key);

                //foreach (var product in categoryGroup) {
                //    Console.WriteLine("Product: "+product.Name);
                //}

                // 2. Count the number of products in each category
                int productCount = categoryGroup.Count();
                Console.WriteLine("Product count: "+productCount);
                // 3. Calculate the total price of products in each category
                decimal totalPrice = categoryGroup.Sum(x => x.Price);
                Console.WriteLine("Total price: "+totalPrice);
                // 4. Find the most expensive product in each category
                decimal expensiveProduct = categoryGroup.Max(x => x.Price);
                Console.WriteLine("Most Expensive Product: " + expensiveProduct);
            }

            Console.ReadLine();
        }
    }
}