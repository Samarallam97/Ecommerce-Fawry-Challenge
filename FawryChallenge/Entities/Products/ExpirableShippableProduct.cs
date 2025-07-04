using FawryChallenge.Interfaces;
namespace FawryChallenge.Entities.Products;
internal class ExpirableShippableProduct : Product, IExpirable , IShippable
{
    public double Weight { get; }
	public bool IsExpired { get ; set; }
	public DateTime ExpiryDate { get ; set ; }

	public ExpirableShippableProduct(string name, decimal price, int quantity, DateTime expiryDate, double weight)
        : base(name, price, quantity)
    {
        ExpiryDate = expiryDate;
		IsExpired = DateTime.Now > expiryDate;
		Weight = weight;
    }

    public string GetName() => Name;
    public double GetWeight() => Weight;
}
