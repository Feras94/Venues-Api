using FluentValidation;
using Venues.Api.ViewModels;

namespace Venues.Api.Validators
{
    public class VenueVmValidator : AbstractValidator<VenueVM>
    {
        public VenueVmValidator()
        {
            RuleFor(model => model.Name).NotEmpty();
            RuleFor(model => model.Address).NotEmpty();
            RuleFor(model => model.Type).NotEmpty();
            RuleFor(model => model.Capacity).GreaterThan(0);
        }
    }
}