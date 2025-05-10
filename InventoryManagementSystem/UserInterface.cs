public class UserInterface
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

	public static int PromptUser(string message)
	{
		int choice;

		Console.Write(message);

		string? input = Console.ReadLine();

		if (string.IsNullOrEmpty(input))
		{
			throw new ArgumentException("Input cannot be null or empty.");
		}

		choice = int.Parse(input);

		return choice;
	}

	public static void Prompt(string message)
	{
		Console.Write(message);
	}

	public static void DisplayError(string? error)
	{
		Console.WriteLine($"Error: {error}" ?? "Unknown error occurred.");
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
			Prompt("Please select an option: ");

			input = Console.ReadLine();

			if (!Validation.IsValidMenuOption(input, out string? error))
			{
				DisplayError(error ?? "Unknown error occurred.");
				continue;
			}

			break;
		}

		return int.Parse(input ?? throw new InvalidOperationException("Price input cannot be null."));
	}

	public static Product PromptForProductDetails()
	{
		string name = PromptForProductName();
		double price = PromptForProductPrice();
		int stock = PromptForProductStock();

		return new Product(name, price, stock);
	}

	private static string PromptForProductName()
	{
		string? input;

		while (true)
		{
			Prompt("Please enter the product name: ");

			input = Console.ReadLine();

			if (!Validation.IsValidProductName(input, out string? nameError))
			{
				DisplayError(nameError);
				continue;
			}

			if (!Validation.IsUniqueProductName(input, Inventory.GetProducts(), out string? uniqueError))
			{
				DisplayError(uniqueError);
				continue;
			}

			break;
		}

		return input;
	}

	private static double PromptForProductPrice()
	{
		string? input;
		double price;

		while (true)
		{
			Prompt("Please enter the Product Price: ");

			input = Console.ReadLine();

			ValidationResult result = Validation.IsValidPrice(input);

			if (!result.IsValid)
			{
				DisplayError(result.ErrorMessage);
				continue;
			}

			break;
		}

		price = double.Parse(input ?? throw new InvalidOperationException("Price input cannot be null."));

		return price;
	}

	private static int PromptForProductStock()
	{
		string? input;
		int stock;

		while (true)
		{
			Prompt("Please enter the Product Stock: ");

			input = Console.ReadLine();

			ValidationResult result = Validation.IsValidStock(input);

			if (!result.IsValid)
			{
				DisplayError(result.ErrorMessage);
				continue;
			}

			break;
		}

		stock = int.Parse(input ?? throw new InvalidOperationException("Stock input cannot be null."));

		return stock;
	}

	public static void DisplayProducts(List<Product> products)
	{
		Console.WriteLine("Products in inventory:");
		Console.WriteLine(new string('-', 40));
		Console.WriteLine($"{"Name",-20} {"Price",-10} {"Stock",-10}");
		Console.WriteLine(new string('-', 40));

		foreach (Product product in products)
		{
			Console.WriteLine($"{product.name,-20} {product.price,-10:C} {product.stock,-10}");
			Console.WriteLine(new string('-', 40));
		}

	}
}