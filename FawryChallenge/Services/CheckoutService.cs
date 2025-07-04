using FawryChallenge.Entities;
using FawryChallenge.Interfaces;

namespace FawryChallenge.Services;

internal class CheckoutService
{
	private const decimal SHIPPING_FEES_FOR_KG = 30;

	public void Checkout(Customer customer, Cart cart)
	{
		if (cart.Items.Count == 0)
			throw new InvalidOperationException("Cart is empty");

		ValidateStockAndExpiration(cart);

		#region Calculate Fees

		decimal subtotal, shippingFee, total;
		CalculateCost(cart, out subtotal, out shippingFee, out total);

		#endregion

		#region Check balance coverage

		if (total > customer.Balance)
			throw new InvalidOperationException($"Insufficient balance => Required: {total} , Available: {customer.Balance}");

		#endregion

		#region Shipping
		var shippableItems = cart.Items.Where(i => i.Product is IShippable)
													 .Select(i => i.Product as IShippable)
													 .ToList();

		if (shippableItems.Count > 0)
		{
			var shippingService = new ShippingService();

			shippingService.Ship(shippableItems!);
		}
		#endregion

		#region Update balance
		customer.Deduct(total);
		#endregion

		#region Print receipt
		Console.WriteLine("*************  Checkout Receipt **************");
		foreach (var item in cart.Items)
		{
			Console.Write($"{item.Quantity}x {item.Product.Name,-15} {item.Product.Price * item.Quantity,15}\n");
		}
		Console.WriteLine("------------------------------------------------");
		Console.WriteLine($"{"Order Subtotal:",-30} {subtotal} $");
		Console.WriteLine($"{"Shipping Fees:",-30} {shippingFee} $");
		Console.WriteLine($"{"Paid Amount:",-30} {total} $");
		Console.WriteLine($"{"Customer Remaining Balance:",-30} {customer.Balance} $"); 
		#endregion

		cart.Clear();
	}

	private static void CalculateCost(Cart cart, out decimal subtotal, out decimal shippingCost, out decimal total)
	{
		subtotal = cart.Items.Sum(i => i.Product.Price  * i.Quantity);
		
		double totalWeight = cart.Items.Where(i => i.Product is IShippable)
					                  .Sum(i => (i.Product as IShippable).GetWeight()* i.Quantity);

		shippingCost =(decimal) (totalWeight/1000) *SHIPPING_FEES_FOR_KG;

		total = subtotal + shippingCost;
	}

	private static void ValidateStockAndExpiration(Cart cart)
	{
		foreach (var item in cart.Items)
		{
			if (item.Quantity  >  item.Product.Quantity)
				throw new InvalidOperationException($"There is no enough {item.Product.Name} in the stock ,  Available: {item.Product.Quantity} Only");
			
			if (item.Product is IExpirable expirable &&  expirable.IsExpired)
				throw new InvalidOperationException($"{item.Product.Name} has expired");
		}
	}
}
