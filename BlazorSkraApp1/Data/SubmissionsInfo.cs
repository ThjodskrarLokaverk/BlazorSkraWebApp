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
        public string UserId { get; set; }
    }
}
