using NerdStore.Core.DomainObjects;
using System.Collections.Generic;

namespace NerdStore.Catalog.Domain
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public int Code { get; private set; }
        public ICollection<Product> Products { get; set; }

        protected Category() { }

        public Category(string name, int code)
        {
            Name = name;
            Code = code;

            Validate();
        }

        public override string ToString()
        {
            return $"{Name} - {Code}";
        }

        public void Validate()
        {
            AssertConcern.ValidateIfEmpty(Name, "O campo Nome da categoria não pode estar vazio");
            AssertConcern.ValidateIfEqual(Code, 0, "O campo Código da categoria não pode ser 0");
        }
    }
}
