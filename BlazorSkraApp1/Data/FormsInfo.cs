﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSkraApp1.Data
{
    public class FormsInfo
    {
        [Key]
        public int FormId { get; set; }
        [Required(ErrorMessage = "Velja þarf nafn eyðublaðs")]
        [StringLength(200, ErrorMessage = "Nafn eyðublaðs má ekki innihalda fleiri en 200 stafi")]
        public string FormName { get; set; }
        [Required]
        [StringLength(320, ErrorMessage = "Netfang má ekki innihalda fleiri en 320 stafi")]
        [EmailAddress]
        public string DestinationEmail { get; set; }
        [Required]
        public bool IsAnonymous { get; set; }
    }
}
