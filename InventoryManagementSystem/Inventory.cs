public class Inventory
{
	private static readonly List<Product> products = [];

	public static void AddProduct(Product product)
	{
		products.Add(product);
	}

	public static List<Product> GetProducts()
	{
		return products;
	}

	public static Product GetProductByName(string name)
	{
		return products.FirstOrDefault(product => product.name.Equals(name, StringComparison.OrdinalIgnoreCase))!;
	}
}