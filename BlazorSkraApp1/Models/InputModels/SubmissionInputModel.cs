using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;

namespace BlazorSkraApp1.Models.InputModels
{
    public class SubmissionInputModel
    {
        public int FormId;
        public string[] Answers;
        public int[] AnswersOrderNum;
        public List<string> MultipleAnswers;
        public bool Confirmation;
        public DateTime SelectedDate;

    }
}