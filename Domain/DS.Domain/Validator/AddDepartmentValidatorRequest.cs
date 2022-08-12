using DS.Domain.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Domain.Validator
{
    public class AddDepartmentValidatorRequest : AbstractValidator<AddDepartmentRequest>
    {
        public AddDepartmentValidatorRequest()
        {
            RuleFor(model => model.Name).NotEmpty();

            RuleFor(model=>model.Code).NotEmpty();
            
            RuleFor(model => model.Descriptions).NotEmpty();   
        }
    }
}
