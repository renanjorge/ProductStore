using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsPerishable { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual ProductCategory ProductCategory { get; set; }
    }
}