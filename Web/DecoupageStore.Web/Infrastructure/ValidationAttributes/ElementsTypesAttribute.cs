namespace DecoupageStore.Web.Infrastructure.ValidationAttributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Drawing;
    using System.Linq;
    using System.Web;

    public class ElementsTypesAttribute : ValidationAttribute
    {
        private readonly string allowedFormatExtensions;
        private readonly string allowedContentTypes;
        private IList<string> extensions;
        private IList<string> contentTypes;

        /// <param name="allowedFormatExtensions">Pass allowed types separated with comma exampl: "jpg,jpeg,png"</param>
        /// <param name="allowedContentTypes">Pass allowed types separated with comma exampl: "image/jpg,image/jpeg,image/png"</param>
        public ElementsTypesAttribute(string allowedFormatExtensions, string allowedContentTypes)
        {
            this.allowedFormatExtensions = allowedFormatExtensions;
            this.allowedContentTypes = allowedContentTypes;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            HttpPostedFileBase[] postedFiles = (HttpPostedFileBase[])value;

            this.extensions = GetListFromString(allowedFormatExtensions, ',');
            this.contentTypes = GetListFromString(this.allowedContentTypes, ',');

            foreach (HttpPostedFileBase file in postedFiles)
            {
                string extension = file.FileName
                    .Split('.')
                    .LastOrDefault();

                bool isFormatExtensionValid = this.extensions.Contains(extension, StringComparer.OrdinalIgnoreCase);

                if (!isFormatExtensionValid)
                {
                    return false;
                }

                bool isContentTypeValid = this.contentTypes.Contains(file.ContentType);

                if (!isContentTypeValid)
                {
                    return false;
                }

                try
                {
                    using (var bitmap = new Bitmap(file.InputStream))
                    {
                        return !bitmap.Size.IsEmpty;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return true;
        }



        public override string FormatErrorMessage(string name)
        {
            return string.Format("Invalid file type. Only the following format extensions {0} and the following content-types {1} are supported.",
                String.Join(", ", this.extensions),
                String.Join(",", this.contentTypes));
        }

        private IList<string> GetListFromString(string strToSplit, char separator)
        {
            return strToSplit
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }
    }
}
