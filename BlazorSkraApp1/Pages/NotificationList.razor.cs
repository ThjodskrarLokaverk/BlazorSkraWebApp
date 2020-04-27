using System.Collections.Generic;
using BlazorSkraApp1.Data;
using Microsoft.AspNetCore.Components;
namespace BlazorSkraApp1.Pages
{
    public partial class NotificationList : ComponentBase
    {
        [Parameter]
        public string id { get; set; }
        private int categoryId;
        List<CategoriesAssignments> categoriesAssignmentsList;
        Categories category = new Categories();
        CategoriesAssignments selectedCategoryAssignment;
        //int count = 0;

        
        private void SelectCategoryAssignment(CategoriesAssignments categoryassignment)
        {
            selectedCategoryAssignment = categoryassignment;
        }

        protected async void DeleteNotificationHandler()
        {
            //Remove the notification/form from the list of notifications in this category
            await catAssignService.Delete(selectedCategoryAssignment);

            //Delete the notification/form from the database
            await formservice.Delete(selectedCategoryAssignment.FormId);

            //remove the notification/form from the list on this page
            categoriesAssignmentsList.Remove(selectedCategoryAssignment);

            //refresh UI
            StateHasChanged();
        }

        public int IncrementCount(int a, int b)
        {
            return a + b;
        }

    }
}