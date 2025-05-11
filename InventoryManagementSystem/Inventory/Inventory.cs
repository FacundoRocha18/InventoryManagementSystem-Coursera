public static class Inventory
{
	private static readonly List<Product> products = [];

	public static void AddProduct(Product product)
	{
		products.Add(product);
	}

	public static void RemoveProduct(Product product)
	{
		products.Remove(product);
	}

	public static IReadOnlyList<Product> GetProducts() => products;

	public static Product? FindProductByName(string name)
	{
		return products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
	}
}