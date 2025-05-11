public static class ProductService
{
	public static Product Build(ProductInput input) => new(input.Name, input.Price, input.Stock);

	public static bool IsDuplicate(Product product) => Inventory.GetProductByName(product.Name) != null;

	public static Product? GetProductToRemove()
	{
		string name = UserInterface.PromptForProductName();

		return Inventory.GetProductByName(name);
	}

	public static bool TryAdd(Product product)
	{
		Inventory.AddProduct(product);

		return Inventory.GetProductByName(product.Name) != null;
	}

	public static bool TryRemove(Product product)
	{
		Inventory.RemoveProduct(product);

		return Inventory.GetProductByName(product.Name) == null;
	}

	public static bool RestockProductByName(string name, int amount)
	{
		Product? product = Inventory.GetProductByName(name);

		if (product == null) {
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