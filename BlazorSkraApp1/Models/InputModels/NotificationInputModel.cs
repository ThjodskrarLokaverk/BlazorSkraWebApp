using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;
using System.ComponentModel.DataAnnotations;

namespace BlazorSkraApp1.Models.InputModels
{
    public class NotificationInputModel
    {
        [Required(ErrorMessage = "Velja þarf flokk")]
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Velja þarf heiti tilkynningar")]
        [StringLength(50, ErrorMessage = "Heiti tilkynningar má ekki innihalda fleiri en 50 stafi")]
        public string NewFormName { get; set; }
        [Required(ErrorMessage = "Velja þarf netfang sem tekur við útfylltum eyðublöðum")]
        public string DestinationEmail { get; set; }
        [Required(ErrorMessage = "Velja þarf titil spurningar")]
        [StringLength(50, ErrorMessage = "Spurning má ekki innihalda fleiri en 50 stafi")]
        public string QuestionName { get; set; }
        [Required(ErrorMessage = "Velja þarf spurningategund")]
        public string QuestionTypeId { get; set; }
        public List<Options> Options { get; set; }
    }
}