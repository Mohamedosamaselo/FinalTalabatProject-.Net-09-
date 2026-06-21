public class ProductCategory : BaseAuditableEntity<int>
{
    public string Name { get; set; } = string.Empty;

    // public virtual ICollection<Products> products { get; set; } = new HashSet<Products>(); // Navogational Property
}