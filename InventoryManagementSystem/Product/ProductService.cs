public static class ProductService
{
	public static Product Build(ProductInput input) => new(input.Name, input.Price, input.Stock);

	public static bool IsDuplicate(Product product) => Inventory.GetProductByName(product.Name) != null;

	public static Product? GetProductToRemove()
	{
		return UserInterface.PromptForProductToRemove();
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
}