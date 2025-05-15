public static class Menu
{
	public static void Execute()
	{
		int option;

		UserInterface.DisplayWelcome();

		while (true)
		{
			UserInterface.DisplayMenuOptions();

			option = UserInterface.PromptForMenuOption();

			switch (option)
			{
				case 1: HandleAddProductOption(); break;
				case 2: HandleRemoveProductOption(); break;
				case 3: HandleRestockProductOption(); break;
				case 4: HandleViewProductsOption(); break;
				case 5: HandleSellProductOption(); break;
				case 0:
					Console.WriteLine("Bye!");
					return;
				default:
					UserInterface.DisplayError("Invalid option. Please try again.");
					break;
			}
		}
	}

	private static void HandleAddProductOption()
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

	private static void HandleRemoveProductOption()
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

	private static void HandleRestockProductOption()
	{
		string name = UserInterface.PromptForProductName();
		int quantity = UserInterface.PromptForProductQuantity();

		ValidationResult result = ProductService.RestockProductByName(name, quantity);

		if (!result.IsValid)
		{
			UserInterface.DisplayError("Failed to restock product.");
			return;
		}

		UserInterface.DisplaySuccess($"Product '{name}' restocked by {quantity} units.");
	}

	private static void HandleViewProductsOption()
	{
		IReadOnlyList<Product> products = Inventory.GetProducts();

		if (products.Count == 0)
		{
			Console.WriteLine("No products available.");
			return;
		}

		UserInterface.DisplayInventory(products);
	}

	private static void HandleSellProductOption()
	{
		string name = UserInterface.PromptForProductName();
		int quantity = UserInterface.PromptForProductQuantity();

		ValidationResult<double> result = ProductService.SellProductByName(name, quantity);

		if (!result.IsValid)
		{
			UserInterface.DisplayError(result.ErrorMessage!);
			return;
		}

		UserInterface.DisplaySuccess($"Sold {quantity} unit(s) of '{name}' for USD{result.Value}.");
	}
}