namespace DecoupageStore.Web.ViewModels.Create
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using Common.Constants;
    using Common.ValidationAttributes;

    public class CreateProductModel
    {
        [Required]
        [StringLength(ValidationConstants.productNameMaxLenght, 
            ErrorMessage ="The name of the product must be between {1} and {2} characters.", MinimumLength = 3)]
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

        [FileSize(ValidationConstants.maxFileSize, 
            ErrorMessage = "The file is too large, allowed max sie - 8 MB")]
        [FileTypes("jpg,jpeg,png", ErrorMessage = "Not supported file format, upload image in \" jpg, jpeg or png format\"")]
        public HttpPostedFileBase File { get; set; }
    }
}