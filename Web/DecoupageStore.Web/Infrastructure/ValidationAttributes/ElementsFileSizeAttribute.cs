namespace DecoupageStore.Web.Infrastructure.ValidationAttributes
{
    using System.Web;
    using System.ComponentModel.DataAnnotations;

    public class ElementsFileSizeAttribute : ValidationAttribute
    {
        private readonly int maxSize;
        private string fileNameForError;

        public ElementsFileSizeAttribute(int maxSize)
        {
            this.maxSize = maxSize;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            HttpPostedFileBase[] postedFiles = (HttpPostedFileBase[])value;

            foreach (var file in postedFiles)
            {
                if (file == null)
                {
                    continue;
                }

                if (file.ContentLength > maxSize)
                {
                    this.fileNameForError = file.FileName;
                    return false;
                }
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("The file with name {0} size should not exceed {1}MB",
                this.fileNameForError, maxSize / (1024 * 1024));
        }
    }
}
