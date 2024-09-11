namespace Inventory_Management_System.ProductManagement;
public class Product : IComparable<Product>
{
    private static int _currentId = 0;
    private readonly int _id;
    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Product name cannot be null or whitespace.");
            if (value.Length < 2)
                throw new ArgumentException("Product name cannot be less than 2 characters.");
            _name = value;
        }
    }
    private int _quantity;
    public int Quantity
    {
        get => _quantity;
        set
        {
            if (value < 0)
                throw new ArgumentException("Product quantity cannot be negative.");
            _quantity = value;
        }
    }
    public Price Price { get; private set; }
    public Product(string name, int quantity, Price price)
    {
        _id = ++_currentId;
        Name = name;
        Quantity = quantity;
        Price = price ?? throw new ArgumentNullException(nameof(price), "Price cannot be null.");
    }
    public bool IncreaseQuantity(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative.");
        Quantity += amount;
        return true;
    }
    public bool DecreaseQuantity(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative.");
        if (amount > Quantity)
            throw new ArgumentException("Not enough amount available in stock.");
        Quantity -= amount;
        return true;
    }
    public bool UpdatePrice(Price newPrice)
    {
        ArgumentNullException.ThrowIfNull(newPrice, nameof(newPrice));
        Price = newPrice;
        return true;
    }
    public int CompareTo(Product other)
    {
        ArgumentNullException.ThrowIfNull(other, nameof(other));

        // First compare by name, then by price if names are the same
        int nameComparison = string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        if (nameComparison != 0) return nameComparison;

        return Price.CompareTo(other.Price);
    }
    public override string ToString()
    {
        return $"ID: {_id}, Name: {Name}, Quantity: {Quantity}, {Price}";
    }
}

