using FawryChallenge.Interfaces;

namespace FawryChallenge.Entities.Products;
internal class ExpirableProduct : Product, IExpirable
{
    public DateTime ExpiryDate { get; set; }
    public bool IsExpired { get; set; } 


	public ExpirableProduct(string name, decimal price, int quantity, DateTime expireDate)
        : base(name, price, quantity)
    {
        ExpiryDate = expireDate;
        IsExpired = DateTime.Now > expireDate;
	}
}
