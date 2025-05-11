public static class UserInterface
{
	public static void DisplayMainMenu()
	{
		Console.WriteLine("Inventory Management System");
		Console.WriteLine("1. Add Product");
		Console.WriteLine("2. Remove Product");
		Console.WriteLine("3. Update Stock");
		Console.WriteLine("4. View Products");
		Console.WriteLine("0. Exit");
	}

	public static void DisplayProductList(IReadOnlyList<Product> products)
	{
		Console.WriteLine("Products in inventory:");
		Console.WriteLine(new string('-', 40));
		Console.WriteLine($"{"Name",-20} {"Price",-10} {"Stock",-10}");
		Console.WriteLine(new string('-', 40));

		foreach (Product product in products)
		{
			Console.WriteLine($"{product.Name,-20} {product.Price,-10:C} {product.Stock,-10}");
			Console.WriteLine(new string('-', 40));
		}
	}

	public static void DisplayError(string? error)
	{
		Console.WriteLine(error != null ? $"Error: {error}" : "Unknown error occurred.");
	}

	public static void DisplaySuccess(string message)
	{
		Console.WriteLine($"Success: {message}");
	}

	public static int PromptForMenuOption()
	{
		string? input;

		while (true)
		{
			Console.Write("Please select an option: ");

			input = Console.ReadLine();

			ValidationResult result = Validation.IsValidMenuOption(input);

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
		string name = PromptAndValidateProductName();
		double price = PromptForProductPrice();
		int stock = PromptForProductStock();

		return new ProductInput(
			name,
			price,
			stock
		);
	}

	public static string PromptForProductName() => PromptWithValidation(
		"Please enter the Product Name: ",
		Validation.IsValidProductName,
		name => name,
		"Invalid name input."
	);

	public static double PromptForProductPrice() => PromptWithValidation(
		"Please enter the Product Price: ",
		Validation.IsValidPrice,
		double.Parse,
		"Invalid price input."
	);

	public static int PromptForProductStock() => PromptWithValidation(
		"Please enter the Product Stock: ",
		Validation.IsValidStock,
		int.Parse,
		"Invalid stock input."
	);

	public static int PromptForRestockAmount() => PromptWithValidation(
		"Please enter the Restock amount: ",
		Validation.IsValidStock,
		int.Parse,
		"Invalid stock input."
	);

	private static string PromptAndValidateProductName()
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

	private static T PromptWithValidation<T>(
		string message,
		Func<string?, ValidationResult> validate,
		Func<string, T> parse,
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

			return parse(input!);
		}
	}
}