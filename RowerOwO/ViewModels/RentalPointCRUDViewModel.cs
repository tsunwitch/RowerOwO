using System.ComponentModel.DataAnnotations;

namespace RowerOwO.ViewModels
{
    public class RentalPointCRUDViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Wprowadź imię")]
        [StringLength(32, ErrorMessage = "Wprowadzona nazwa nie może mieć więcej niż 32 znaki")]
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
    }
}
