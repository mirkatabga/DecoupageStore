namespace DecoupageStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Common.Constants;

    public class Product
    {
        private ICollection<ProductImage> images;

        public Product()
        {
            this.images = new HashSet<ProductImage>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.productNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [StringLength(ValidationConstants.maxMaterialLenght)]
        public string Material { get; set; }

        [Required]
        [StringLength(ValidationConstants.maxCategoryLenght)]
        public string Category { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool FinishedGoodsFlag { get; set; }

        [Required]
        [Range(ValidationConstants.minDaysToManufacture, ValidationConstants.maxDaysToManufacture)]
        public int DaysToManufacture { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<ProductImage> Images
        {
            get
            {
                return this.images;
            }
            set
            {
                this.images = value;
            }
        }
    }
}