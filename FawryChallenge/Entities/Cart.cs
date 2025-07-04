using FawryChallenge.Entities.Products;
using FawryChallenge.Interfaces;

namespace FawryChallenge.Entities;

internal class Cart
{
	private List<CartItem> items = new List<CartItem>();

	public void Add(Product product, int quantity)
	{
		if (quantity <= 0)
			throw new InvalidOperationException("Quantity must be > zero");
		
		if (quantity > product.Quantity)
			throw new InvalidOperationException($"There is no enough {product.Name} in the stock , Available: {product.Quantity} only");

		if (product is IExpirable expirable && expirable.IsExpired)
			throw new InvalidOperationException($"{product.Name} expired");

		var existingItem = items.FirstOrDefault(i => i.Product == product);
		
		if (existingItem is not null)
		{
			existingItem.Quantity += quantity;
		}
		else
		{
			items.Add(new CartItem(product , quantity));
		}

		product.Quantity -= quantity;
	}

	public IReadOnlyList<CartItem> Items => items.AsReadOnly();
	public void Clear() => items.Clear();
}