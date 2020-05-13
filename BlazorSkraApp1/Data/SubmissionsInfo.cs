using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSkraApp1.Data
{
    public class SubmissionsInfo
    {
        [Key]
        public int SubmissionId { get; set; }
        public DateTime SubmissionDate { get; set; }  // To be able to identify submissions by date, and delete old submissions
        [Required]
        public string UserId { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Nafn eyðublaðs má ekki innihalda fleiri en 250 stafi")]
        public string FormName { get; set; }
        [Required]
        [StringLength(320, ErrorMessage = "Netfang má ekki innihalda fleiri en 320 stafi")]
        [EmailAddress]
        public string DestinationEmail { get; set; }
    }
}
