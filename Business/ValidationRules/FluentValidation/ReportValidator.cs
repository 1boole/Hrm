using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ReportValidator:AbstractValidator<Report>
    {
        public ReportValidator()
        {
            RuleFor(r => r.ImportanceLevel).LessThanOrEqualTo(5).GreaterThanOrEqualTo(1).WithMessage("değer aralığı 1 ve 5 arasında olmalıdır.");
        }
    }
}
