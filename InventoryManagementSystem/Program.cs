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
					var (name, price, stock) = UserInterface.PromptForProductDetails();
					
					Product newProduct = new Product(name, price, stock);

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
					Product? createdProduct = Inventory.GetProductByName(newProduct.Name);

					if (createdProduct == null)
					{
						// If the new product is not present, print an error and early return
						UserInterface.DisplayError("An error occurred while saving the product.");
						break;
					}

					UserInterface.DisplaySuccess($"Operation successful. Product added: {createdProduct.Name}");
					break;
				case 2:
					Product productToRemove = UserInterface.PromptForProductToRemove();

					if (productToRemove == null)
					{
						UserInterface.DisplayError("Failed to collect product details.");
						break;
					}

					Inventory.RemoveProduct(productToRemove);

					Product? removedProduct = Inventory.GetProductByName(productToRemove.Name);

					if (removedProduct != null)
					{
						UserInterface.DisplayError($"Failed to remove product: {removedProduct.Name}");
						break;
					}

					UserInterface.DisplaySuccess($"Operation successful. Product removed: {productToRemove.Name}");
					break;
				case 3:
					UserInterface.DisplayError("Method not implemented.");
					break;
				case 4:
					IReadOnlyList<Product> products = Inventory.GetProducts();

					if (products.Count == 0)
					{
						Console.WriteLine("No products available.");
						break;
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