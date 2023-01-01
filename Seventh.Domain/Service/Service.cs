using FluentValidation;
using FluentValidation.Internal;
using Seventh.Domain.Entities;

namespace Seventh.Domain.Service
{
    public abstract class Service
    {
        protected bool IsInvalid<T>(T entity, AbstractValidator<T> validator, Action<ValidationStrategy<T>> options) where T : BaseEntity
        {
            entity.Validate(entity, validator, options);
            
            //if (entity.IsInvalid)
            //    throw new Exception(entity.ValidationResult.Errors);

            return entity.IsInvalid;
        }

        protected bool IsInvalid<T>(List<T> entities, AbstractValidator<T> validator, Action<ValidationStrategy<T>> options) where T : BaseEntity
        {
            var isInvalid = false;

            foreach (var entity in entities)
            {
                isInvalid = IsInvalid(entity, validator, options);

                if (isInvalid)
                    break;
            }

            return isInvalid;
        }
    }
}