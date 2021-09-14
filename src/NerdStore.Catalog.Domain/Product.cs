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

        public DateTime CreatedAt { get; private set; }

        public File Image { get; private set; }

        public int AmountStock { get; private set; }

        public Guid CategoryId { get; private set; }

        public Category Category { get; private set; }

        public Product(string name, string description, bool isActive, decimal value, DateTime createdAt, File image, Guid categoryId)
        {
            Name = name;
            Description = description;
            IsActive = isActive;
            Value = value;
            CreatedAt = createdAt;
            Image = image;
            CategoryId = categoryId;
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
            Description = description;
        }

        public void DebitStock(int amount)
        {
            if (amount < 0) amount *= -1;
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
        }
    }

    public class Category : Entity
    {
        public string Name { get; private set; }

        public int Code { get; private set; }

        public Category(string name, int code)
        {
            Name = name;
            Code = code;
        }

        public override string ToString()
        {
            return $"{Name} - {Code}";
        }
    }

    public class File : Entity
    {
        public string FileName { get; set; }

        public byte[] DataFiles { get; set; }
    }
}
