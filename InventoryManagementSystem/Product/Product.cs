public class Product(string name, double price, int stock)
{
	public string Name { get; set; } = name;
	public double Price { get; set; } = price;
	public int Stock { get; set; } = stock;

	public ValidationResult Restock(int amount)
	{
		if (amount <= 0)
		{
			return new ValidationResult
			{
				IsValid = false,
				ErrorMessage = "Restock amount must be greater than 0."
			};
		}

		Stock += amount;

		return new ValidationResult { IsValid = true };
	}

	public ValidationResult Sell(int quantity)
	{
		if (quantity <= 0)
		{
			return new ValidationResult { IsValid = false, ErrorMessage = "Quantity must be greater than zero." };
		}

		if (quantity > Stock)
		{
			return new ValidationResult { IsValid = false, ErrorMessage = "Not enough stock available." };
		}

		Stock -= quantity;

		return new ValidationResult { IsValid = true };
	}
}