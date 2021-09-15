using NerdStore.Core.DomainObjects;
using System;
using Xunit;

namespace NerdStore.Catalog.Domain.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Product_Validate_ValidationsShouldReturnExceptions()
        {
            // Arrange & Act & Assert

            var ex = Assert.Throws<DomainException>(() =>
                new Product(" ", "Description", false, 100, Guid.NewGuid(), Guid.NewGuid(), new Dimensions(1, 1, 1))
            );

            Assert.Equal("O campo Nome do produto n�o pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Name", " ", false, 100, Guid.NewGuid(), Guid.NewGuid(), new Dimensions(1, 1, 1))
            );

            Assert.Equal("O campo Descri��o do produto n�o pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Name", "Description", false, 0, Guid.NewGuid(), Guid.NewGuid(), new Dimensions(1, 1, 1))
            );

            Assert.Equal("O campo Valor do produto n�o pode ser menor ou igual a 0", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Name", "Description", false, 100, Guid.Empty, Guid.NewGuid(), new Dimensions(1, 1, 1))
            );

            Assert.Equal("O campo ImagemId do produto n�o pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Name", "Description", false, 100, Guid.NewGuid(), Guid.Empty, new Dimensions(1, 1, 1))
            );

            Assert.Equal("O campo CategoriaId do produto n�o pode estar vazio", ex.Message);
        }
    }
}
