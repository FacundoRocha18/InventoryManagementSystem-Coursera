public class Product(string name, double price, int stock)
{
	public string Name { get; set; } = name;
	public double Price { get; set; } = price;
	public int Stock { get; set; } = stock;

	public ValidationResult Restock(int quantity)
	{
		if (quantity <= 0)
		{
			return new ValidationResult
			{
				IsValid = false,
				ErrorMessage = "Product Restock Quantity must be greater than 0."
			};
		}

		Stock += quantity;

		return new ValidationResult { IsValid = true };
	}

	public ValidationResult<double> Sell(int quantity)
	{
		if (quantity <= 0)
		{
			return new ValidationResult<double> { IsValid = false, ErrorMessage = "Product Quantity must be greater than zero." };
		}

		if (quantity > Stock)
		{
			return new ValidationResult<double> { IsValid = false, ErrorMessage = "Not enough stock available." };
		}

		Stock -= quantity;

		return new ValidationResult<double> { IsValid = true, Value = Price * quantity };
	}
}