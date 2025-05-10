
public static class Validation
{
	private const int MaxStock = 10000;
	private const double MaxPrice = 1_000_000;
	private const int MaxMenuOption = 4;
	private const int MinNameChars = 3;
	private const int MaxNameChars = 75;
	private const int MaxNameDigits = 3;

	public static bool IsValidMenuOption(string? input, out string? errorMessage)
	{
		errorMessage = null;

		if (string.IsNullOrWhiteSpace(input))
		{
			errorMessage = "Option cannot be empty.";
			return false;
		}

		// Checks if the options contains any invalid character like letters
		if (!input.All(char.IsDigit))
		{
			errorMessage = $"Option must contain only digits (0-{MaxMenuOption}).";
			return false;
		}

		if (!double.TryParse(input, out double option))
		{
			errorMessage = "Option must be a valid number.";
			return false;
		}

		if (option < 0 || option > MaxMenuOption)
		{
			errorMessage = "Price must be a non-negative number (0-4).";
			return false;
		}

		return true;
	}
	public static ValidationResult IsValidProductName(string? input)
	{
		if (string.IsNullOrWhiteSpace(input))
		{
			return new ValidationResult {
				IsValid = false,
				ErrorMessage = "Name cannot be empty."
			};
		}

		int digitCount = input.Count(char.IsDigit);

		if (digitCount > MaxNameDigits)
		{
			return new ValidationResult {
				IsValid = false,
				ErrorMessage = "Product name contains too many numbers."
			};
		}

		if (input.Length < MinNameChars || input.Length > MaxNameChars)
		{
			return new ValidationResult {
				IsValid = false,
				ErrorMessage = "Product name must be between 3 and 50 characters."
			};
		}
		
		if (!input.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
		{
			return new ValidationResult {
				IsValid = false,
				ErrorMessage = "Product name contains invalid characters."
			};
		}

		if (Inventory.GetProducts().Any(product => product.name.Equals(input, StringComparison.OrdinalIgnoreCase)))
		{
			return new ValidationResult
			{
				IsValid = false,
				ErrorMessage = "A product with this name already exists."
			};
		}

		return new ValidationResult { IsValid = true };
	}

	public static ValidationResult IsValidPrice(string? input)
	{
		if (string.IsNullOrWhiteSpace(input))
		{
			return new ValidationResult
			{
				IsValid = false,
				ErrorMessage = "Price cannot be empty."
			};
		}

		if (input.Any(c => !char.IsDigit(c)))
		{
			return new ValidationResult
			{
				IsValid = false,
				ErrorMessage = "Price must contain only digits (0-9)."
			};
		}

		// Checks if the price contains any invalid character like letters
		if (input.Any(char.IsLetter))
		{
			return new ValidationResult
			{
				IsValid = false,
				ErrorMessage = "Price cannot contain letters or invalid characters."
			};
		}

		if (!double.TryParse(input, out double price))
		{
			return new ValidationResult
			{
				IsValid = false,
				ErrorMessage = "Price must be a valid number."
			};
		}

		if (price < 0 || price > MaxPrice)
		{
			return new ValidationResult
			{
				IsValid = false,
				ErrorMessage = "Price must be a non-negative number not exceeding $1,000,000."
			};
		}

		return new ValidationResult { IsValid = true };
	}

	public static ValidationResult IsValidStock(string? input)
	{
		// Checks if the input is null or empty
		if (string.IsNullOrWhiteSpace(input))
		{
			return new ValidationResult
			{
				IsValid = false,
				ErrorMessage = "Stock cannot be empty."
			};
		}

		// Checks if the stock contains any invalid character like letters
		if (input.Any(c => !char.IsDigit(c)))
		{
			return new ValidationResult
			{
				IsValid = false,
				ErrorMessage = "Stock must contain only digits."
			};
		}

		// Tries to parse the string input into an integer
		if (!int.TryParse(input, out int stock))
		{
			return new ValidationResult
			{
				IsValid = false,
				ErrorMessage = "Stock must be a valid number."
			};
		}

		// Checks if the value is between the allowed stock range
		if (stock < 0 || stock > MaxStock)
		{
			return new ValidationResult
			{
				IsValid = false,
				ErrorMessage = "Stock must be a non-negative integer not exceeding 10,000."
			};
		}

		return new ValidationResult { IsValid = true };
	}
}