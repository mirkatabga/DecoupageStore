namespace DecoupageStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Constants;
    using System.ComponentModel;
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        [Range(ValidationConstants.minFileSize, ValidationConstants.maxFileSize)]
        public long Size { get; set; }

        [Required]
        public string ContentType { get; set; }

        [DefaultValue(false)]
        public bool IsMain { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
