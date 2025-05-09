public class Product {
	public string name { get; set; }
	public double price { get; set; }
	public int stock { get; set; }

	public Product (string name, double price, int stock) {
		this.name = name;
		this.price = price;
		this.stock = stock;
	}
}