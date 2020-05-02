using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorSkraApp1.Models.InputModels
{
    public class FormsInputModel
    {
        [Required(ErrorMessage = "Velja þarf heiti tilkynningar")]
        [StringLength(50, ErrorMessage = "Heiti tilkynningar má ekki innihalda fleiri en 50 stafi")]
        public string FormName { get; set; }
        [Required(ErrorMessage = "Velja þarf netfang sem tekur við útfylltum eyðublöðum")]
        [EmailAddress(ErrorMessage = "Þetta tölvupóstfang er ekki til")]
        public string DestinationEmail { get; set; }
        [Required(ErrorMessage = "Velja þarf flokk")]
        public string CategoryId { get; set; }
        //[Required] //Athuga hvort þetta virki þegar rest virkar
        [ValidateComplexType]
        public List<QuestionsInputModel> Questions { get; set; }
    }
}
