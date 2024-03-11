namespace BusinessRules.RulesForPrice;

public class WeightRule: IPriceRule
{
    public bool isApplicable(string sku) {
        return sku.StartsWith(SkuPrefix.WEIGHT_PRODUCT_PREFIX);
    }

    public float calculatePrice(float quantity, float price) {
        // TODO: polish this condition
        return quantity * price;
    }
}
