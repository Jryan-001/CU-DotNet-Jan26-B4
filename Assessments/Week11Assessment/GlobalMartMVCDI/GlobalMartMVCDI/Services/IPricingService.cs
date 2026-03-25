namespace GlobalMartMVCDI.Services
{
    public interface IPricingService
    {
        decimal CalculatePrice(decimal price, string promoCode);
    }
}
