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
            var image = new byte[10];

            var ex = Assert.Throws<DomainException>(() =>
                new Product(" ", "Description", false, 100, new File("File Name", image), Guid.NewGuid(), new Dimensions(1, 1, 1))
            );

            Assert.Equal("O campo Nome do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Name", " ", false, 100, new File("File Name", image), Guid.NewGuid(), new Dimensions(1, 1, 1))
            );

            Assert.Equal("O campo Descrição do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Name", "Description", false, 0, new File("File Name", image), Guid.NewGuid(), new Dimensions(1, 1, 1))
            );

            Assert.Equal("O campo Valor do produto não pode ser menor ou igual a 0", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Name", "Description", false, 100, new File("File Name", null), Guid.NewGuid(), new Dimensions(1, 1, 1))
            );

            Assert.Equal("O campo Imagem não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Name", "Description", false, 100, new File("File Name", image), Guid.Empty, new Dimensions(1, 1, 1))
            );

            Assert.Equal("O campo CategoriaId do produto não pode estar vazio", ex.Message);
        }
    }
}
