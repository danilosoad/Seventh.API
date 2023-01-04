using FluentValidation;
using Seventh.Domain.Resources;

namespace Seventh.Domain.Entities.Servers.Validation
{
    public class ServerValidation : AbstractValidator<Server>
    {
        public const string UpdateRole = "UpdateRole";
        public const string InsertRole = "InsertRole";

        public ServerValidation()
        {
            //RuleSet(UpdateRole, () => Update());
            //RuleSet(InsertRole, () => Insert());
            CommonPropertiesValidate();
        }

        public void Update()
        {
            CommonPropertiesValidate();
        }

        public void Insert()
        {
            CommonPropertiesValidate();
        }

        public void CommonPropertiesValidate()
        {
            Id();
            Name();
            EnderecoIp();
            PortaIp();
        }

        public void Id()
        {
            RuleFor(x => x.Id).NotEmpty()
                                .WithMessage(MessagesResource.RequiredField);
        }

        public void Name()
        {
            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage(MessagesResource.RequiredField);
        }

        public void EnderecoIp()
        {
            RuleFor(x => x.EnderecoIp).NotEmpty()
                                .WithMessage(MessagesResource.RequiredField);
        }

        public void PortaIp()
        {
            RuleFor(x => x.PortaIp).NotEmpty()
                                .WithMessage(MessagesResource.RequiredField);
        }
    }
}