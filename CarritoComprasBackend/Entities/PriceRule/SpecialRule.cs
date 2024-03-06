namespace CarritoComprasBackend.Entities.PriceRule;

using Entities.Constants;

public class SpecialRule: PriceRule
{
    public override bool isApplicable(string sku) {
        return sku.StartsWith(SkuPrefix.SPECIAL_PRODUCT_PREFIX);
    }

    public override float calculatePrice(float quantity, float price) {
        // TODO: polish this condition
        return quantity * price;
    }
}
