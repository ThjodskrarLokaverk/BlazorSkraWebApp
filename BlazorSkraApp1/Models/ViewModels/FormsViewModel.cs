using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorSkraApp1.Data;

namespace BlazorSkraApp1.Models.ViewModels
{
    public class FormsViewModel
    {
        public string FormName { get; set; }
        public string DestinationEmail { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsAnonymous { get; set; }

        public List<QuestionsViewModel> Questions { get; set; }
    }
}
