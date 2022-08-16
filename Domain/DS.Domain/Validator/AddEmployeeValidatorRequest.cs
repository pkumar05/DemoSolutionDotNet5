using DS.Domain.DTO;
using FluentValidation;

namespace DS.Domain.Validator
{
    public class AddEmployeeValidatorRequest : AbstractValidator<AddEmployeeRequest>
    {
        public AddEmployeeValidatorRequest()
        {
           // RuleFor(model => model.EmployeeID).NotEmpty();
            RuleFor(model => model.FirstName).NotEmpty();

            RuleFor(model=>model.LastName).NotEmpty();
            
            RuleFor(model => model.Email).NotEmpty();   
        }
    }
}
