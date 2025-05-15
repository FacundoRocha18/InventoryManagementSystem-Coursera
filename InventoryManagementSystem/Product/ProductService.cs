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

	public static ValidationResult RestockProductByName(string name, int amount)
	{
		Product? product = Inventory.FindProductByName(name);

		if (product == null)
		{
			return new ValidationResult
			{
				IsValid = false,
				ErrorMessage = $"Product '{name}' not found."
			};
		}

		return product.Restock(amount);
	}

	public static ValidationResult<double> SellProductByName(string name, int quantity)
	{
		Product? product = Inventory.FindProductByName(name);

		if (product == null)
		{
			return new ValidationResult<double>
			{
				IsValid = false,
				ErrorMessage = $"Product '{name}' not found."
			};
		}

		return product.Sell(quantity);
	}
}