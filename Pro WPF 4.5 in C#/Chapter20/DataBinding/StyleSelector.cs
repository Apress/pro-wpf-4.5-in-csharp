using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using StoreDatabase;
using System.Reflection;

namespace DataBinding
{
    public class ProductByCategoryStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            Product product = (Product)item;
            Window window = Application.Current.MainWindow;

            if (product.CategoryName == "Travel")
            {
                return (Style)window.FindResource("TravelProductStyle");
            }
            else
            {
                return (Style)window.FindResource("DefaultProductStyle");
            }
        }
    }

    public class SingleCriteriaHighlightStyleSelector : StyleSelector
    {
        public Style DefaultStyle
        {
            get;
            set;
        }

        public Style HighlightStyle
        {
            get;
            set;
        }

        public string PropertyToEvaluate
        {
            get;
            set;
        }

        public string PropertyValueToHighlight
        {
            get;
            set;
        }

        public override Style SelectStyle(object item,
          DependencyObject container)
        {
            Product product = (Product)item;

            // Use reflection to get the property to check.
            Type type = product.GetType();
            PropertyInfo property = type.GetProperty(PropertyToEvaluate);

            // Decide if this product should be highlighted
            // based on the property value.
            if (property.GetValue(product, null).ToString() == PropertyValueToHighlight)
            {
                return HighlightStyle;
            }
            else
            {
                return DefaultStyle;
            }
        }
    }


}
