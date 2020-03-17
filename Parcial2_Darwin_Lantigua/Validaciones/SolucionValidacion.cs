using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;

namespace Parcial2_Darwin_Lantigua.Validaciones
{
    public class SolucionValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string cadena = value as string;

            if (cadena != null)
            {

                if (cadena.Length <= 0)
                    return new ValidationResult(false, "Debes poner una solución");

                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "Debes poner una solución");
        }
    }
}
