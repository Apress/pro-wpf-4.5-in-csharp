using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Reflection;
using StoreDatabase;

namespace DataBinding
{
    public class SingleCriteriaHighlightTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate
        {
            get;
            set;
        }

        public DataTemplate HighlightTemplate
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


        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Product product = (Product)item;

            Type type = product.GetType();
            PropertyInfo property = type.GetProperty(PropertyToEvaluate);
            if (property.GetValue(product, null).ToString() == PropertyValueToHighlight)
            {
                return HighlightTemplate;
            }
            else
            {
                return DefaultTemplate;
            }
        }

    }
}
