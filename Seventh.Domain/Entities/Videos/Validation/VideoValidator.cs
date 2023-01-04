using FluentValidation;
using Seventh.Domain.Resources;

namespace Seventh.Domain.Entities.Videos.Validation
{
    public class VideoValidator : AbstractValidator<Video>
    {
        public VideoValidator()
        {
            CommonPropertiesValidate();
        }

        public void CommonPropertiesValidate()
        {
            Id();
            Description();
            Content();
        }

        public void Id()
        {
            RuleFor(x => x.Id).NotEmpty()
                                .WithMessage(MessagesResource.RequiredField);
        }

        public void Description()
        {
            RuleFor(x => x.Description).NotEmpty()
                                .WithMessage(MessagesResource.RequiredField);
        }

        public void Content()
        {
            RuleFor(x => x.VideoContent).NotEmpty()
                                .WithMessage(MessagesResource.RequiredField);
        }
    }
}