using System.Collections.Generic;
using BlazorSkraApp1.Data;
using System.ComponentModel.DataAnnotations;

namespace BlazorSkraApp1.Models.InputModels
{
    public class UserInputModel
    {
        [Required(ErrorMessage = "Netfang notanda vantar")]
        [EmailAddress(ErrorMessage = "Netfang er ekki til")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lykilorð notanda vantar")]
        [MinLength(6, ErrorMessage = "Lykilorð þarf að innihalda að minnsta kosti 6 stafi")]
        public string Password { get; set; }
        public string UserRole { get; set; }
    }
}