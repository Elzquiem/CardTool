using System;
using System.Globalization;
using System.Windows.Controls;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CardTool
{
    public class IntFieldRule : ValidationRule
    {

            public IntFieldRule()
            {
            }

   
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                

                try
                {
                    int fieldValue = Convert.ToInt32(value.ToString());
                    
                }
                catch (Exception e)
                {
                    //return new ValidationResult(false, "Illegal characters or " + e.Message);
                    return new ValidationResult(false, "Not a number");
                }
                

                return new ValidationResult(true, null);
                //return ValidationResult.ValidResult;

               /* if ((age < Min) || (age > Max))
                {
                    return new ValidationResult(false,
                      "Please enter an age in the range: " + Min + " - " + Max + ".");
                }
                else
                {
                    return new ValidationResult(true, null);
                }*/
            }
        }
 
}
