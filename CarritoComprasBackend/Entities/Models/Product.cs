namespace CarritoComprasBackend.Entities.Models;
public class Product {
    public int id { get; set; }
    public string sku { get; set; }
    public string name { get; set; }
    public string? description { get; set; }
    public int availableUnits { get; set; }
    public float unitPrice { get; set; }
    public string? image { get; set; }
}