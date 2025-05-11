public static class InventoryManagementSystem
{
	public static void Main(string[] args)
	{
		int option;

		while (true)
		{
			UserInterface.DisplayMainMenu();

			option = UserInterface.PromptForMenuOption();

			switch (option)
			{
				case 1: HandleAddProduct(); break;
				case 2: HandleRemoveProduct(); break;
				case 3: HandleRestockProduct(); break;
				case 4: HandleViewProducts(); break;
				case 0:
					Console.WriteLine("Bye!");
					return;
				default:
					UserInterface.DisplayError("Invalid option. Please try again.");
					break;
			}
		}
	}

	private static void HandleAddProduct()
	{
		ProductInput input = UserInterface.PromptForProductDetails();
		Product product = ProductService.Build(input);

		if (ProductService.IsDuplicate(product))
		{
			UserInterface.DisplayError("A product with this name already exists.");
			return;
		}

		if (!ProductService.TryAdd(product))
		{
			UserInterface.DisplayError("An error occurred while saving the product.");
			return;
		}

		UserInterface.DisplaySuccess($"Product added: {product.Name}");
	}

	private static void HandleRemoveProduct()
	{
		string name = UserInterface.PromptForProductName();
		Product? product = ProductService.FindByName(name);

		if (product == null)
		{
			UserInterface.DisplayError($"Product '{name}' not found.");
			return;
		}

		if (!ProductService.TryRemove(product))
		{
			UserInterface.DisplayError($"Failed to remove product: {product.Name}");
			return;
		}

		UserInterface.DisplaySuccess($"Product removed: {product.Name}");
	}

	private static void HandleRestockProduct()
	{
		string name = UserInterface.PromptForProductName();
		int amount = UserInterface.PromptForRestockAmount();

		if (!ProductService.RestockProductByName(name, amount))
		{
			UserInterface.DisplayError("Failed to restock product.");
			return;
		}

		UserInterface.DisplaySuccess($"Product '{name}' restocked by {amount} units.");
	}

	private static void HandleViewProducts()
	{
		IReadOnlyList<Product> products = Inventory.GetProducts();

		if (products.Count == 0)
		{
			Console.WriteLine("No products available.");
			return;
		}

		UserInterface.DisplayProductList(products);
	}
}