using FluentValidation;
using RowerOwO.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RowerOwO.Areas.Users.Models
{
    public class RentalModel
    {
        public Guid Id { get; set; }

        public virtual VehicleModel Vehicle { get; set; }
        public virtual RentalPointModel RentalPoint { get; set; }
        public DateOnly? RentFrom { get; set; }
        public DateOnly? RentTill { get; set; }
        public bool IsActive { get; set; }
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
