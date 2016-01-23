namespace DecoupageStore.Web.Infrastructure.ValidationAttributes
{
    using System.Web;
    using System.ComponentModel.DataAnnotations;

    public class ElementsItemsCountAttribute : ValidationAttribute
    {
        private readonly int maxCount;

        public ElementsItemsCountAttribute(int maxCount)
        {
            this.maxCount = maxCount;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            HttpPostedFileBase[] postedFiles = (HttpPostedFileBase[])value;

            return postedFiles.Length <= this.maxCount;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("You cannot upload more then {0} images.", this.maxCount);
        }
    }
}
