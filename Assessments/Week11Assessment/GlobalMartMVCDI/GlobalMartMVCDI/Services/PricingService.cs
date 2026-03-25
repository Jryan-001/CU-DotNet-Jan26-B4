namespace GlobalMartMVCDI.Services
{
    public class PricingService: IPricingService
    {
        public decimal CalculatePrice(decimal price, string promoCode)
        {
            if(string.IsNullOrEmpty(promoCode))
            {
                return price;
            }
            decimal finalPrice = price;
            switch (promoCode.ToUpper())
            {
                case "WINTER25":
                    finalPrice = price * 0.85m;
                    break;

                case "FREESHIP":
                    finalPrice = price - 5.00m;
                    break;

                default:
                    finalPrice = price;
                    break;
            }
            return finalPrice < 0 ? 0 : finalPrice;

        }

    }
}
