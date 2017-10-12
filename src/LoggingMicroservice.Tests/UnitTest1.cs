using LoggingMicroservice.Controllers;
using System;
using Xunit;

namespace LoggingMicroservice.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var controller = new ValuesController();
            var result = controller.Get(1);
            Assert.Equal("value", result);
        }
    }
}
