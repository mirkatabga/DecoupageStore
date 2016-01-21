namespace DecoupageStore.Common.ValidationAttributes
{
    using System.Web;
    using System.ComponentModel.DataAnnotations;

    public class FileSizeAttribute : ValidationAttribute
    {
        private readonly int maxSize;

        public FileSizeAttribute(int maxSize)
        {
            this.maxSize = maxSize;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true; 
            }

            return ((HttpPostedFileBase)value).ContentLength <= maxSize;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("The file size should not exceed {0}MB", maxSize / (1024 * 1024));
        }
    }
}
