using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;

namespace DataBinding
{
    public class PositivePriceRule : ValidationRule
    {
        private decimal min = 0;
        private decimal max = Decimal.MaxValue;
        
        public decimal Min
        {
            get { return min; }
            set { min = value; }
        }

        public decimal Max
        {
            get { return max; }
            set { max = value; }
        }
              

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal price = 0;

            try
            {
                if (((string)value).Length > 0)
                    // Allow number styles with currency symbols like $.
                    price = Decimal.Parse((string)value, System.Globalization.NumberStyles.Any);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Illegal characters.");
            }

            if ((price < Min) || (price > Max))
            {
                return new ValidationResult(false,
                  "Not in the range " + Min + " to " + Max + ".");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
