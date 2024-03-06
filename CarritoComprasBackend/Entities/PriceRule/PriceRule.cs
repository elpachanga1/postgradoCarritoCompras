namespace CarritoComprasBackend.Entities.PriceRule;

public abstract class PriceRule
{
    public abstract bool isApplicable(string sku);

    public abstract float calculatePrice(float quantity, float price);
}
