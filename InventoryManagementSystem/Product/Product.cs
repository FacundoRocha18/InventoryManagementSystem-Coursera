public class Product(string name, double price, int stock)
{
	public string Name { get; set; } = name;
	public double Price { get; set; } = price;
	public int Stock { get; set; } = stock;

	public void Restock(int amount)
	{
		if (amount <= 0){
			throw new ArgumentException("Restock amount must be greater than 0.");
		}

		Stock += amount;
	}
}