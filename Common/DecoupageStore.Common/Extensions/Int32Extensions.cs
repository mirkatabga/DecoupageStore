namespace DecoupageStore.Common.Extensions
{
    using System;

    public static class Int32Extensions
    {
        public static bool IsPositiveOrZero(this Int32 number)
        {
            return number >= 0;
        }
    }
}
