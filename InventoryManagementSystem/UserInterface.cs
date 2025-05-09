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

	public static void DisplayError(string error)
	{
		Console.WriteLine($"Error: {error}");
	}

	public static void DisplaySuccess(string message)
	{
		Console.WriteLine($"Success: {message}");
	}

	public static Product PromptForProductDetails()
	{
		string name;
		do
		{
			Prompt("Please enter the product name: ");
			name = Console.ReadLine() ?? string.Empty;

			int digitCount = name.Count(char.IsDigit);
			if (string.IsNullOrWhiteSpace(name))
			{
				DisplayError("Product name cannot be empty. Please try again.");
			}
			else if (digitCount > 3)
			{
				DisplayError("Product name contains too many numbers. Please try again.");
			}
			else if (name.Length < 3 || name.Length > 50)
			{
				DisplayError("Product name must be between 3 and 50 characters. Please try again.");
			}
			else if (!name.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
			{
				DisplayError("Product name contains invalid characters. Please try again.");
			}
			else if (Inventory.GetProducts().Any(product => product.name.Equals(name, StringComparison.OrdinalIgnoreCase)))
			{
				DisplayError("A product with this name already exists. Please try again.");
			}
		} while (string.IsNullOrWhiteSpace(name) || name.Count(char.IsDigit) > 3 || name.Length < 3 || name.Length > 50 || !name.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)) || Inventory.GetProducts().Any(product => product.name.Equals(name, StringComparison.OrdinalIgnoreCase)));

		double price;
		while (true)
		{
			Prompt("Please enter the Product Price: ");
			if (double.TryParse(Console.ReadLine(), out price) && price >= 0 && price <= 1000000)
			{
				break;
			}
			DisplayError("Invalid price. Please enter a non-negative number not exceeding $1,000,000.");
		}

		int stock;
		while (true)
		{
			Prompt("Please enter the Product Stock: ");
			if (int.TryParse(Console.ReadLine(), out stock) && stock >= 0 && stock <= 10000)
			{
				break;
			}
			DisplayError("Invalid stock. Please enter a non-negative integer not exceeding 10,000.");
		}

		return new Product(name, price, stock);
	}
}