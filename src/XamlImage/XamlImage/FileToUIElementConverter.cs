using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Resources;

namespace XamlImage
{
    public class FileToUIElementConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string path = parameter.ToString();

            StreamResourceInfo sri = Application.GetResourceStream(new Uri(path, UriKind.Relative));
            if (sri != null)
            {
                using (Stream stream = sri.Stream)
                {
                    var logo = XamlReader.Load(stream) as DrawingImage;

                    if (logo != null)
                    {
                        return logo;
                    }
                }
            }

            throw new Exception("Resource not found");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
