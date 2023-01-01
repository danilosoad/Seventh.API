using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;

namespace Seventh.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsValid { get; private set; }

        public bool IsInvalid => !IsValid;

        public ValidationResult ValidationResult { get; set; }

        public virtual bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return IsValid = ValidationResult.IsValid;
        }

        public virtual bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator, Action<ValidationStrategy<TModel>> options)
        {
            ValidationResult = validator.Validate(model, options);
            return IsValid = ValidationResult.IsValid;
        }
    }
}