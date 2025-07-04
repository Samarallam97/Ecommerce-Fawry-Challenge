using FawryChallenge.Interfaces;
namespace FawryChallenge.Entities.Products;
internal class ShippableProduct : Product, IShippable
{
    public double Weight { get; set; }

    public ShippableProduct(string name, decimal price, int quantity, double weight) : base(name, price, quantity)
    {
        Weight = weight;
    }

    public string GetName() => Name;
    public double GetWeight() => Weight;
}
