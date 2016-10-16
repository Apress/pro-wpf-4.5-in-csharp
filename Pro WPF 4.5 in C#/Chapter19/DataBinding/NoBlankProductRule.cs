using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Globalization;
using System.Windows.Data;
using StoreDatabase;

namespace DataBinding
{
    public class NoBlankProductRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            BindingGroup bindingGroup = (BindingGroup)value;
            
            // This product has the original values.
            Product product = (Product)bindingGroup.Items[0];                     
            
            // Check the new values.
            string newModelName = (string)bindingGroup.GetValue(product, "ModelName");
            string newModelNumber = (string)bindingGroup.GetValue(product, "ModelNumber");

            if ((newModelName == "") && (newModelNumber == ""))
            {
                return new ValidationResult(false,
                    "A product requires a ModelName or ModelNumber.");
            }
            else
            {
                return new ValidationResult(true, null);                
            }
        }
    }
}
