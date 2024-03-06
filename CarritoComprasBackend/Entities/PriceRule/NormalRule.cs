namespace CarritoComprasBackend.Entities.PriceRule;

using Entities.Constants;

public class NormalRule : PriceRule
{
    public override bool isApplicable(string sku) {
        return sku.StartsWith(SkuPrefix.NORMAL_PRODUCT_PREFIX);
    }

    public override float calculatePrice(float quantity, float price) {
        return quantity * price;
    }
}
