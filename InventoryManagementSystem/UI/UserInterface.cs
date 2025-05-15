public static class UserInterface
{
	public static void DisplayWelcome()
	{
		Console.Clear();
		Console.WriteLine(new string('-', 80));
		Console.WriteLine("Welcome to the Inventory Management System!");
		Console.WriteLine(new string('-', 80));
	}
	public static void DisplayMenuOptions()
	{
		Console.WriteLine("1. Add Product");
		Console.WriteLine("2. Remove Product");
		Console.WriteLine("3. Update Stock");
		Console.WriteLine("4. View Products");
		Console.WriteLine("5. Sell Product");
		Console.WriteLine("0. Exit");
	}

	public static void DisplayInventory(IReadOnlyList<Product> products)
	{
		Console.WriteLine("Products in inventory:");
		Console.WriteLine(new string('-', 80));
		Console.WriteLine($"{"Name",-40} {"Price",-10} {"Stock",-10}");
		Console.WriteLine(new string('-', 80));

		foreach (Product product in products)
		{
			Console.WriteLine($"{product.Name,-40} {product.Price,-10:C} {product.Stock,-10}");
			Console.WriteLine(new string('-', 80));
		}
	}

	public static void DisplayError(string? error)
	{
		Console.WriteLine(new string('-', 80));
		Console.WriteLine(error != null ? $"Error: {error}" : "Unknown error occurred.");
		Console.WriteLine(new string('-', 80));
	}

	public static void DisplaySuccess(string message)
	{
		Console.WriteLine(new string('-', 80));
		Console.WriteLine($"Success: {message}");
		Console.WriteLine(new string('-', 80));
	}

	public static int PromptForMenuOption()
	{
		string? input;

		while (true)
		{
			Console.Write("Please select an option: ");

			input = Console.ReadLine();

			ValidationResult<int> result = Validation.IsValidMenuOption(input);

			if (!result.IsValid)
			{
				DisplayError(result.ErrorMessage);
				continue;
			}

			break;
		}

		return int.Parse(input ?? throw new InvalidOperationException("Price input cannot be null."));
	}

	public static ProductInput PromptForProductDetails()
	{
		string name = PromptForUniqueProductName();
		double price = PromptForProductPrice();
		int stock = PromptForProductStock();

		return new ProductInput(
			name,
			price,
			stock
		);
	}

	public static string PromptForProductName() => Prompt(
		"Please enter the Product Name: ",
		Validation.IsValidProductName,
		"Invalid Product Name input."
	);

	public static double PromptForProductPrice() => Prompt(
		"Please enter the Product Price: ",
		Validation.IsValidPrice,
		"Invalid Product Price input."
	);

	public static int PromptForProductStock() => Prompt(
		"Please enter the Product Stock: ",
		Validation.IsValidStock,
		"Invalid Product Stock input."
	);

	public static int PromptForProductQuantity() =>
	Prompt(
		"Please enter the Product Quantity: ",
		Validation.IsValidQuantity,
		"Invalid Product Quantity entered."
	);

	private static string PromptForUniqueProductName()
	{
		while (true)
		{
			string name = PromptForProductName();

			var uniquenessResult = Validation.IsUniqueProductName(name);
			if (!uniquenessResult.IsValid)
			{
				DisplayError(uniquenessResult.ErrorMessage!);
				continue;
			}

			return name;
		}
	}

	private static T Prompt<T>(
	string message,
	Func<string?, ValidationResult<T>> validate,
	string fallbackError = "Invalid input."
)
	{
		while (true)
		{
			Console.Write(message);
			string? input = Console.ReadLine();

			var result = validate(input);
			if (!result.IsValid)
			{
				DisplayError(result.ErrorMessage ?? fallbackError);
				continue;
			}

			return result.Value!;
		}
	}
}