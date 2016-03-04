namespace DecoupageStore.Data.Models
{
    using Common.Constants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private ICollection<Product> products;

        public Category()
        {
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.minCategoryNameLength)]
        [MaxLength(ValidationConstants.maxCategoryNameLength)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
