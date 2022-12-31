using FluentValidation;

namespace Seventh.Domain.Entities.Servers.Validation
{
    public class ServerValidation : AbstractValidator<Server>
    {
        public ServerValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("colocar resource aqui");
        }
    }
}