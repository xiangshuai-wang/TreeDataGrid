using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using TreeDataGrid.CustomControls;

namespace TreeDataGrid.Converters
{
    public class DepthConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double colunwidth = 35;
            double left = 0.0;

            UIElement element = value as UIElement;
            while (element != null && !(element is CupertinoTreeView))
            {
                element = VisualTreeHelper.GetParent(element) as UIElement;
                if (element is CupertinoTreeItem)
                {
                    left += colunwidth;
                }
            }

            return new Thickness(left, 0, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
