namespace FawryChallenge.Entities;
internal class Customer
{
    public string Name { get; set; }
    public decimal Balance { get; set; }

    public Customer(string name , decimal balance)
    {
        Name = name;
        Balance = balance;
    }

    public void Deduct(decimal amount)
    {
        Balance -= amount;
    }
}
