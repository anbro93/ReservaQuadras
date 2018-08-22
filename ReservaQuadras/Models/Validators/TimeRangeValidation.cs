using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservaQuadras.Models.Validators
{
    public class TimeRangeValidation : ValidationAttribute
    {
        protected override ValidationResult
                IsValid(object value, ValidationContext validationContext)
        {
            var model = (Models.Horario)validationContext.ObjectInstance;
            var HoraFim = model.HoraFim;
            var HoraInicio = (TimeSpan) value;

            if (HoraInicio >= HoraFim)
            {
                return new ValidationResult
                    ("A hora inicial deve ser menor que a hora final");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
