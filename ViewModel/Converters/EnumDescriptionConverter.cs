using System;
using System.Globalization;
using System.Windows;
using ViewModel.Extensions;

namespace ViewModel.Converters
{
    public class EnumDescriptionConverter : ConvertorBase<EnumDescriptionConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Enum)
                return (value as Enum).GetDescription();

            return DependencyProperty.UnsetValue;
        }
    }
}
