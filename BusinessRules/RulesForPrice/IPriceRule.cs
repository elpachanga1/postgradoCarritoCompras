namespace BusinessRules.RulesForPrice;

public interface IPriceRule
{
    public bool isApplicable(string sku);

    public float calculatePrice(float quantity, float price);
}