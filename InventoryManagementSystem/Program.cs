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
					// Prompts the user for the product details, and assigns the input values to the variable newProduct
					Product newProduct = UserInterface.PromptForProductDetails();

					// Validates that newProduct is an instance of the class Product
					if (!typeof(Product).IsInstanceOfType(newProduct))
					{
						// If newProduct is not an instance of Product, print an error and early return
						UserInterface.DisplayError("An error occurred with the operation.");
						return;
					}

					// Add the new product to the Inventory products list
					Inventory.AddProduct(newProduct);

					// Validates that newProduct is present in Inventory.products
					if (!Inventory.GetProducts().Contains(newProduct))
					{
						// If the new product is not present, print an error and early return
						UserInterface.DisplayError("An error occurred with the operation.");
						return;
					}

					// Gets the created product to display it to the user
					Product createdProduct = Inventory.GetProductByName(newProduct.name);

					// Display a success message and the created product
					UserInterface.DisplaySuccess($"Operation successful. Product added: {createdProduct.name}");

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
					UserInterface.DisplaySuccess("Bye!");
					return;
			}
		}
	}
}