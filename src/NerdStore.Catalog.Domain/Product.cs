using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Catalog.Domain
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; }
        public decimal Value { get; private set; }
        public int AmountStock { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid ImageId { get; private set; }
        public File Image { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }
        public Dimensions Dimensions { get; private set; }

        //EF ctor
        public Product() { }

        public Product(string name, string description, bool isActive, decimal value, Guid imageId, Guid categoryId, Dimensions dimensions)
        {
            Name = name;
            Description = description;
            IsActive = isActive;
            Value = value;
            CreatedAt = DateTime.Now;
            ImageId = imageId;
            CategoryId = categoryId;
            Dimensions = dimensions;

            Validate();
        }

        public void Activate() => IsActive = true;

        public void Deactivate() => IsActive = false;

        public void ChangeCategory(Category category)
        {
            Category = category;
            CategoryId = category.Id;
        }

        public void ChangeDescription(string description)
        {
            AssertConcern.ValidateIfEmpty(Description, "O campo Descrição do produto não pode estar vazio");
            Description = description;
        }

        public void DebitStock(int amount)
        {
            if (amount < 0) amount *= -1;
            if (!HaveStock(amount)) throw new DomainException("Estoque insuficiente");
            AmountStock -= amount;
        }

        public void ReplenishStock(int amount)
        {
            AmountStock += amount;
        }

        public bool HaveStock(int amount)
        {
            return AmountStock >= amount;
        }

        public void Validate()
        {
            AssertConcern.ValidateIfEmpty(Name, "O campo Nome do produto não pode estar vazio");
            AssertConcern.ValidateIfEmpty(Description, "O campo Descrição do produto não pode estar vazio");
            AssertConcern.ValidateIfEqual(CategoryId, Guid.Empty, "O campo CategoriaId do produto não pode estar vazio");
            AssertConcern.ValidateIfLessThan(Value, 1, "O campo Valor do produto não pode ser menor ou igual a 0");
            AssertConcern.ValidateIfEqual(ImageId, Guid.Empty, "O campo ImagemId do produto não pode estar vazio");
        }
    }
}
