using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorSkraApp1.Models.InputModels
{
    public class FormsInputModel
    {
        [Required(ErrorMessage = "Velja þarf heiti eyðublaðs")]
        [StringLength(20, ErrorMessage = "Heiti eyðublaðs má ekki innihalda fleiri en 20 stafi")]
        public string FormName { get; set; }
        [Required(ErrorMessage = "Velja þarf netfang sem tekur við útfylltum eyðublöðum")]
        [EmailAddress(ErrorMessage = "Þetta tölvupóstfang er ekki til")]
        public string DestinationEmail { get; set; }
        [Required(ErrorMessage = "Velja þarf flokk")]
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Eyðublaðið þarf að hafa spurningar. Bættu við spurningu")]
        [ValidateComplexType]
        public List<QuestionsInputModel> Questions { get; set; }
    }
}
