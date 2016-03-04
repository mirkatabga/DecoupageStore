namespace DecoupageStore.Common.Constants
{
    public static class ValidationConstants
    {
        public const int productNameMaxLenght = 80;
        public const int minDaysToManufacture = 1;
        public const int maxDaysToManufacture = 1000;
        public const int maxMaterialLenght = 30;
        public const int maxFileSize = 8388608; //bytes -> 8192 KB -> 8 MB
        public const int minFileSize = 0;
        public const int maxImageCount = 9;
        public const int minProductPrice = 0;
        public const int minCategoryNameLength = 2;
        public const int maxCategoryNameLength = 32;
        public const int minMaterialLength = 2;
        public const int maxMaterialLength = 32;
    }
}
