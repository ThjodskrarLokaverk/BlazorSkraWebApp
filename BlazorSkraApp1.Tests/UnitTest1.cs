using System;
using Xunit;

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
    }
}
