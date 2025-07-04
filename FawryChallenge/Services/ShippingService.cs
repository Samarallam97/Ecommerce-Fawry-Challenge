using FawryChallenge.Interfaces;

namespace FawryChallenge.Services;
internal  class ShippingService
{
	public  void Ship( List<IShippable>  items)
	{
		Console.WriteLine("*************  Shipment notice  *************");

		double totalWeight = 0;

		foreach (var item in items)
		{
			Console.Write($"{ item.GetName() , -15} ");

			Console.Write($" {item.GetWeight(), 5}g \n ");

            totalWeight +=  item.GetWeight();
		}

		Console.WriteLine($" Total weight { totalWeight/1000} kg \n");

	}
}