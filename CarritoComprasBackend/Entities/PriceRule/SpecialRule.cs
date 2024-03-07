namespace CarritoComprasBackend.Entities.PriceRule;

using Entities.Constants;

public class SpecialRule: IPriceRule
{
    public bool isApplicable(string sku) {
        return sku.StartsWith(SkuPrefix.SPECIAL_PRODUCT_PREFIX);
    }

    public float calculatePrice(float quantity, float price) {
        // TODO: polish this condition
        return quantity * price;
    }
}
