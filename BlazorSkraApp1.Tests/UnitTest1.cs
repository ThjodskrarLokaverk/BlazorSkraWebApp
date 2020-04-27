using System;
using Xunit;
using BlazorSkraApp1.Pages;

namespace BlazorSkraApp1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void IsBoughtBy_UserIsCustomer_ReturnTrue()
        {
            var bought = new BlazorSkraApp1.Data.Bought();
            var result = bought.IsBoughtBy(new BlazorSkraApp1.Data.User { customer = true });
            Assert.True(result);
        }
        [Fact]
        public void IncrementCount_ReturnTrue()
        {
            var notification = new BlazorSkraApp1.Pages.NotificationList();
            //var result = notification.IncrementCount(2);
            Assert.Equal(5, notification.IncrementCount(2, 3));

        }
    }
}
