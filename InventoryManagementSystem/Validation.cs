using System.Reflection.PortableExecutable;

public static class Validation
{
	public static bool IsValidMenuOption(string? input, out string? errorMessage)
	{
		errorMessage = null;

		errorMessage = null;

		if (string.IsNullOrWhiteSpace(input))
		{
			errorMessage = "Option cannot be empty.";
			return false;
		}

		if (input.Any(c => !char.IsDigit(c)))
		{
			errorMessage = "Option must contain only digits (0-4).";
			return false;
		}

		// Checks if the options contains any invalid character like letters
		if (input.Any(char.IsLetter))
		{
			UserInterface.DisplayError("Option cannot contain letters or invalid characters.");
			return false;
		}

		if (!double.TryParse(input, out double option))
		{
			errorMessage = "Option must be a valid number.";
			return false;
		}

		if (option < 0 || option > 4)
		{
			UserInterface.DisplayError("Price must be a non-negative number (0-4).");
			return false;
		}

		return true;
	}
	public static bool IsValidProductName(string name, out string errorMessage)
	{
		errorMessage = string.Empty;
		int digitCount = name.Count(char.IsDigit);

		if (string.IsNullOrWhiteSpace(name))
		{
			errorMessage = "Product name cannot be empty.";
			return false;
		}
		if (digitCount > 3)
		{
			errorMessage = "Product name contains too many numbers.";
			return false;
		}
		if (name.Length < 3 || name.Length > 50)
		{
			errorMessage = "Product name must be between 3 and 50 characters.";
			return false;
		}
		if (!name.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
		{
			errorMessage = "Product name contains invalid characters.";
			return false;
		}

		return true;
	}

	public static bool IsUniqueProductName(string name, List<Product> products, out string errorMessage)
	{
		errorMessage = string.Empty;

		if (products.Any(product => product.name.Equals(name, StringComparison.OrdinalIgnoreCase)))
		{
			errorMessage = "A product with this name already exists.";
			return false;
		}

		return true;
	}

	public static bool IsValidPrice(string? input, out string? errorMessage)
	{
		errorMessage = null;

		if (string.IsNullOrWhiteSpace(input))
		{
			errorMessage = "Price cannot be empty.";
			return false;
		}

		if (input.Any(c => !char.IsDigit(c)))
		{
			errorMessage = "Price must contain only digits (0-9).";
			return false;
		}

		// Checks if the price contains any invalid character like letters
		if (input.Any(char.IsLetter))
		{
			UserInterface.DisplayError("Price cannot contain letters or invalid characters.");
			return false;
		}

		if (!double.TryParse(input, out double price))
		{
			errorMessage = "Price must be a valid number.";
			return false;
		}

		if (price < 0 || price > 1000000)
		{
			UserInterface.DisplayError("Price must be a non-negative number not exceeding $1,000,000.");
			return false;
		}

		return true;
	}

	public static bool IsValidStock(string? input, out string? errorMessage)
	{
		errorMessage = null;

		// Checks if the input is null or empty
		if (string.IsNullOrWhiteSpace(input))
		{
			errorMessage = "Stock cannot be empty.";
			return false;
		}

		// Checks if the stock contains any invalid character like letters
		if (input.Any(c => !char.IsDigit(c)))
		{
			errorMessage = "Stock must contain only digits (0-9).";
			return false;
		}

		// Tries to parse the string input into an integer
		if (!int.TryParse(input, out int stock))
		{
			errorMessage = "Stock must be a valid number.";
			return false;
		}

		// Checks if the value is between the allowed range
		if (stock < 0 || stock > 10000)
		{
			errorMessage = "Stock must be a non-negative integer not exceeding 10,000.";
			return false;
		}

		return true;
	}
}