using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.IO;


namespace WPFXamlIslands.Converters
{
    public class StringToImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string imagePath = $"{AppDomain.CurrentDomain.BaseDirectory}Photos\\{value}.jpg";
            BitmapImage bitmapImage = !string.IsNullOrWhiteSpace(value?.ToString()) &&
                                      File.Exists(imagePath) ?
                new BitmapImage(new Uri(imagePath)) :
                null;
            return bitmapImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

}
