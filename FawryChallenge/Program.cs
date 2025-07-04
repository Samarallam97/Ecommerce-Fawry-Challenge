using FawryChallenge.Entities;
using FawryChallenge.Entities.Products;
using FawryChallenge.Services;

namespace FawryChallenge;

internal class Program
{
	static void Main(string[] args)
	{

			#region Create products
			var cheese = new ExpirableShippableProduct("Cheese", 100, 5, DateTime.Now.AddDays(10), 100);
			
			var biscuit = new ExpirableShippableProduct("Biscuit", 200, 2, DateTime.Now.AddDays(-3), 200); // expired
			
			var tv = new ShippableProduct("Tv" , 20000 , 3 , 2000);
			
			var scratchCard = new Product("Scratch Card", 50, 20);
			#endregion

			#region Create Customer , Cart , Checkout Service
			var customer = new Customer("Samar Allam", 10000);

			var cart = new Cart();

			var checkoutService = new CheckoutService();
		#endregion

		#region Test case 1: Normal checkout

		//try
		//{
		//	cart.Add(cheese, 2);


		//	cart.Add(scratchCard, 1);

		//	checkoutService.Checkout(customer, cart);
		//}
		//catch (Exception ex)
		//{
		//	Console.WriteLine($"Error: {ex.Message}");
		//}

		#endregion

		#region Test Case 2: Empty cart
		//try
		//{
		//	checkoutService.Checkout(customer, cart);
		//}
		//catch (Exception ex)
		//{
		//	Console.WriteLine($"Error: {ex.Message}");
		//}
		#endregion


		#region Test case 3: Insufficient balance
		//cart.Add(tv, 1);

		//try
		//{
		//	checkoutService.Checkout(customer, cart);
		//}
		//catch (Exception ex)
		//{
		//	Console.WriteLine($"Error: {ex.Message}");
		//}
		#endregion

		#region Test case 4: Expired product
		//try
		//{
		//	cart.Add(biscuit, 1);

		//	checkoutService.Checkout(customer, cart);
		//}
		//catch (Exception ex)
		//{
		//	Console.WriteLine($"Error: {ex.Message}");
		//}
		#endregion

		#region Test Case 5: Out of stock
		try
		{
			cart.Add(cheese, 10);
		}
		catch (InvalidOperationException ex)
		{
			Console.WriteLine($"Error: {ex.Message}");
		}
		#endregion

	}
}
