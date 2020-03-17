using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;
using Parcial2_Darwin_Lantigua.Entidades;
using System.Windows.Data;

namespace Parcial2_Darwin_Lantigua.Validaciones
{
    public class DetalleValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                List<LlamadasDetalle> detalle = (List<LlamadasDetalle>)value;

                if(detalle.Count>0)
                {
                    return ValidationResult.ValidResult;
                }
                return new ValidationResult(false, "Debes poner algun problema con solución");
            }
            return new ValidationResult(false, "Debes poner algun problema con solución");
        }
    }
}
