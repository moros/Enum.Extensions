using System.ComponentModel;

namespace Enum.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescription<TEnum>(this TEnum enumValue) where TEnum : struct
        {
            return DescriptionAttr(enumValue);
        }

        private static string DescriptionAttr<T>(this T source)
        {
            var field = source.GetType().GetField(source.ToString());
            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : source.ToString();
        }
    }
}
