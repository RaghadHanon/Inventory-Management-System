namespace Inventory_Management_System.ProductManagement;
internal class ProductValidator
{
    public static void Validate(Product product, string? name = null, decimal? price = null, Currency? currency = null, int? quantity = null)
    {

        if (!string.IsNullOrWhiteSpace(name))
        {
            product.Name = name;
        }
        if (price != null && currency != null)
        {
            var newProductPrice = new Price(price.Value, currency.Value);
            product.UpdatePrice(newProductPrice);
        }
        if (quantity != null)
        {
            product.Quantity = quantity.Value;
        }
    }
}
