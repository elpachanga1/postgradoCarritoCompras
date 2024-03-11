namespace BusinessRules.RulesForPrice;

public class NormalRule : IPriceRule
{
    public bool isApplicable(string sku) {
        return sku.StartsWith(SkuPrefix.NORMAL_PRODUCT_PREFIX);
    }

    public float calculatePrice(float quantity, float price) {
        return quantity * price;
    }
}
