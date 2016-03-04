namespace DecoupageStore.Data.Models
{
    using Common.Constants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Material
    {
        private ICollection<Product> products;

        public Material()
        {
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.minMaterialLength)]
        [MaxLength(ValidationConstants.maxMaterialLength)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
