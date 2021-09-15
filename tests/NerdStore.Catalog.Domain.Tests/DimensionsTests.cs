using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NerdStore.Catalog.Domain.Tests
{
    public class DimensionsTests
    {
        [Fact]
        public void Dimensions_Validate_ValidationsShouldReturnExceptions()
        {
            // Arrange & Act & Assert

            var ex = Assert.Throws<DomainException>(() => new Dimensions(0, 1, 1));

            Assert.Equal("O campo Altura do produto não pode ser menor ou igual a 0", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Dimensions(1, 0, 1));

            Assert.Equal("O campo Largura do produto não pode ser menor ou igual a 0", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Dimensions(1, 1, 0));

            Assert.Equal("O campo Profundidade do produto não pode ser menor ou igual a 0", ex.Message);
        }
    }
}
