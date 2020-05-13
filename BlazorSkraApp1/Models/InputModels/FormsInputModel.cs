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
        [StringLength(100, ErrorMessage = "Nafn eyðublaðs má ekki innihalda fleiri en 100 stafi")]
        public string FormName { get; set; }
        [Required(ErrorMessage = "Velja þarf netfang sem tekur við útfylltum eyðublöðum")]
        [StringLength(320, ErrorMessage = "Netfang má ekki innihalda fleiri en 320 stafi")]
        [EmailAddress(ErrorMessage = "Þetta netfang er ekki til")]
        public string DestinationEmail { get; set; }
        [Required(ErrorMessage = "Velja þarf flokk")]
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Eyðublaðið þarf að hafa spurningar. Bættu við spurningu")]
        [ValidateComplexType]
        public List<QuestionsInputModel> Questions { get; set; }
        public bool IsAnonymous { get; set; }
    }
}
