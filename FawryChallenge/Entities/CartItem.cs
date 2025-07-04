using FawryChallenge.Entities.Products;
namespace FawryChallenge.Entities;

internal class CartItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public CartItem(Product product , int quantity)
    {
		Product = product;
        Quantity = quantity;
	}
}
