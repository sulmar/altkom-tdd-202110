using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestApp.xUnitTests
{
    public class FakeCustomerRepositoryTests
    {


        [Fact]
        public void Get_WhenCalled_ShouldReturnsCustomers()
        {
            // Arrange
            FakeCustomerRepository fakeCustomerRepository = new FakeCustomerRepository();

            // Act
            var result = fakeCustomerRepository.Get();

            var removedCount = result.Where(p => p.IsRemoved).Count();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(100, result.Count);
            Assert.Equal(27, removedCount);
            
            
        }
    }
}
