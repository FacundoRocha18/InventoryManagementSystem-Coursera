public static class ProductService
{
	public static Product Build(ProductInput input) => new(input.Name, input.Price, input.Stock);

	public static Product? FindByName(string name) => Inventory.FindProductByName(name);

	public static bool IsDuplicate(Product product) => Inventory.FindProductByName(product.Name) != null;

	public static bool TryAdd(Product product)
	{
		Inventory.AddProduct(product);

		return Inventory.FindProductByName(product.Name) != null;
	}

	public static bool TryRemove(Product product)
	{
		Inventory.RemoveProduct(product);

		return Inventory.FindProductByName(product.Name) == null;
	}

	public static bool RestockProductByName(string name, int amount)
	{
		Product? product = Inventory.FindProductByName(name);

		if (product == null)
		{
			return false;
		}

		try
		{
			product.Restock(amount);
			return true;
		}
		catch (ArgumentException)
		{
			return false;
		}
	}
}