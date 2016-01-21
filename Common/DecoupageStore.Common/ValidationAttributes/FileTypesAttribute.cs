namespace DecoupageStore.Common.ValidationAttributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class FileTypesAttribute : ValidationAttribute
    {
        private readonly string allowedTypes;
        private IList<string> extensions;

        /// <param name="allowedTypes">Pass allowed types separated with comma exampl: "jpg,jpeg,png"</param>
        public FileTypesAttribute(string allowedTypes)
        {
            this.allowedTypes = allowedTypes;
            this.extensions = new List<string>();
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            this.extensions = this.allowedTypes
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string extension = (value as HttpPostedFileBase).FileName
                .Split('.')
                .LastOrDefault();

            return this.extensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("Invalid file type. Only the following types {0} are supported.", 
                String.Join(", ", this.extensions));
        }
    }
}
