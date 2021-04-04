using System;
using System.ComponentModel;
using System.Reflection;

namespace ViewModel.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = fi.GetCustomAttribute<DescriptionAttribute>(false);
            return attribute != null ? attribute.Description : value.ToString();
        }
    }
}
