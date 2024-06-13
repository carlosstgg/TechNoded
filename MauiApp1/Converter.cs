using Microsoft.Maui.Controls.Xaml;
using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using MauiApp1.MVVM.Models;

namespace MauiApp1.Converters
{
    public class SelectedItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SelectionChangedEventArgs eventArgs)
            {
                if (eventArgs.CurrentSelection.FirstOrDefault() is Compo selectedCompo)
                {
                    return selectedCompo;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
