
public static class Validation
{
	private const int MaxStock = 10000;
	private const double MaxPrice = 1_000_000;
	private const int MaxMenuOption = 4;
	private const int MinNameChars = 3;
	private const int MaxNameChars = 75;
	private const int MaxNameDigits = 3;

	public static ValidationResult IsValidMenuOption(string? input)
	{
		// Checks if the option is null or empty
		if (string.IsNullOrWhiteSpace(input))
		{
			return new ValidationResult {
				IsValid = false,
				ErrorMessage = "Option cannot be empty."
			};
		}

		// Checks if the option contains any invalid character
		if (!input.All(char.IsDigit))
		{
			return new ValidationResult {
				IsValid = false,
				ErrorMessage = $"Option must contain only digits (0-{MaxMenuOption})."
			};
		}

		// Tries to parse the option string into a double
		if (!double.TryParse(input, out double option))
		{
			return new ValidationResult {
				IsValid = false,
				ErrorMessage =  "Option must be a valid number."
			};
		}

		// Checks if the option is between the allowed range
		if (option < 0 || option > MaxMenuOption)
		{
			return new ValidationResult {
				IsValid = false,
				ErrorMessage = "Price must be a non-negative number (0-4)."
			};
		}

		return new ValidationResult { IsValid = true };
	}
	public static ValidationResult IsValidProductName(string? input)
	{
		// Checks if the input is null or empty
		if (string.IsNullOrWhiteSpace(input))
		{
			return new ValidationResult {
				IsValid = false,
				ErrorMessage = "Name cannot be empty."
			};
		}

		// Gets the digit count in the input 
		int digitCount = input.Count(char.IsDigit);

		// Checks if the input digit count is under the max allowed sequential digits
		if (digitCount > MaxNameDigits)
		{
			return new ValidationResult {
				IsValid = false,
				ErrorMessage = "Name contains too many numbers."
			};
		}

		// Checks if the input lenght is between the allowed range
		if (input.Length < MinNameChars || input.Length > MaxNameChars)
		{
			return new ValidationResult {
				IsValid = false,
				ErrorMessage = "Name must be between 3 and 50 characters."
			};
		}
		
		// Checks if the input contains any character other than letter, digits or white spaces
		if (!input.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
		{
			return new ValidationResult {
				IsValid = false,
				ErrorMessage = "Name contains invalid characters."
			};
		}

		// Checks if the name already exists in the list of products
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
		// Checks if the input is null or empty
		if (string.IsNullOrWhiteSpace(input))
		{
			return new ValidationResult
			{
				IsValid = false,
				ErrorMessage = "Price cannot be empty."
			};
		}

		// Checks if the input contains any invalid character like letters
		if (input.Any(c => !char.IsDigit(c)))
		{
			return new ValidationResult
			{
				IsValid = false,
				ErrorMessage = "Price cannot contain letters or special characters."
			};
		}

		// Tries to parse the input from string to double and assigns the value to the price variable
		if (!double.TryParse(input, out double price))
		{
			return new ValidationResult
			{
				IsValid = false,
				ErrorMessage = "Price must be a non-negative valid number."
			};
		}

		// Checks if the price is between the allowed range
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