namespace FawryChallenge.Interfaces;
internal interface IExpirable
{
     DateTime ExpiryDate { get; set; }
     bool IsExpired { get; set; }
}
