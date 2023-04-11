using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace RowerOwO.Models
{
    public class RentalModel
    {
        public Guid Id{ get; set; }
        public virtual VehicleModel? Vehicle { get; set; }
        public virtual RentalPointModel? Point { get; set; }
        public DateOnly? RentFrom { get; set; }
        public DateOnly? RentTill { get; set; }

    }

    public class RentalModelValidator : AbstractValidator<RentalModel>
    {
        public RentalModelValidator() 
        {
            RuleFor(x => x.RentFrom).LessThan(x => x.RentTill).
                WithMessage("Data wypożyczenia musi być mniejsza od daty końca rezerwacji");
            RuleFor(x => x.RentTill).GreaterThan(x => x.RentFrom).
                WithMessage("Data końca rezerwacji musy być większa od daty wypożyczenia");
        }
    }

}
