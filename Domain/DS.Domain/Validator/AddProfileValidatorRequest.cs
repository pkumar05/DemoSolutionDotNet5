using DS.Domain.DTO;
using FluentValidation;

namespace DS.Domain.Validator
{
    public class AddProfileValidatorRequest : AbstractValidator<AddProfileRequest>
    {
        public AddProfileValidatorRequest()
        {
            RuleFor(model => model.Name).NotEmpty();

            RuleFor(model=>model.Code).NotEmpty();
            
            RuleFor(model => model.Descriptions).NotEmpty();   
        }
    }
}
