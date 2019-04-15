using System.ComponentModel.DataAnnotations;

namespace Application.Frontal.ViewModel.Login
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Número de teléfono")]
        public string Number { get; set; }
    }
}