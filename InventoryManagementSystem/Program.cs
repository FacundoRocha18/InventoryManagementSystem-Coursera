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
				case 1:
					// Prompts the user for the product details
					Product newProduct = UserInterface.PromptForProductDetails();

					// Null-check in case PromptForProductDetails() returns null explicitly
					if (newProduct == null)
					{
						// If newProduct is not an instance of Product, print an error and early return
						UserInterface.DisplayError("Failed to collect product details.");
						break;
					}

					// Try to add product to inventory
					Inventory.AddProduct(newProduct);

					// Confirm that product was added
					Product? createdProduct = Inventory.GetProductByName(newProduct.name);

					if (createdProduct == null)
					{
						// If the new product is not present, print an error and early return
						UserInterface.DisplayError("An error occurred while saving the product.");
						break;
					}

					UserInterface.DisplaySuccess($"Operation successful. Product added: {createdProduct.name}");
					break;
				case 2:
					UserInterface.DisplayError("Method not implemented.");
					break;
				case 3:
					UserInterface.DisplayError("Method not implemented.");
					break;
				case 4:
					List<Product> products = Inventory.GetProducts();

					if (products.Count == 0)
					{
						Console.WriteLine("No products available.");
						return;
					}

					UserInterface.DisplayProducts(products);

					break;
				case 0:
					Console.WriteLine("Bye!");
					return;
			}
		}
	}
}