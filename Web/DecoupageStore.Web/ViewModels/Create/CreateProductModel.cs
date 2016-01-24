namespace DecoupageStore.Web.ViewModels.Create
{
    using System.Web;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    using Common.Constants;
    using Infrastructure.ValidationAttributes;

    public class CreateProductModel
    {
        [Required]
        [StringLength(ValidationConstants.productNameMaxLenght,
            ErrorMessage = "The name of the product must be between {1} and {2} characters.", MinimumLength = 3)]
        public string Name { get; set; }

        [Range(ValidationConstants.minProductPrice, int.MaxValue)]
        public decimal Price { get; set; }

        [DefaultValue(false)]
        public bool Negotiable { get; set; }

        [Required]
        [StringLength(ValidationConstants.maxMaterialLenght)]
        public string Material { get; set; }

        [Required]
        [StringLength(ValidationConstants.maxCategoryLenght)]
        public string Category { get; set; }

        [Required]
        [Range(ValidationConstants.minDaysToManufacture, ValidationConstants.maxDaysToManufacture)]
        public int DaysToManufacture { get; set; }

        [ElementsItemsCount(ValidationConstants.maxImageCount)]
        [ElementsFileSize(ValidationConstants.maxFileSize)]
        [ElementsTypes("jpg,jpeg,png", "image/jpg,image/jpeg,image/png")]
        public IEnumerable<HttpPostedFileBase> Images { get; set; }
    }
}