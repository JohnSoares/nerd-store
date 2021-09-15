using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Catalog.Domain
{
    public class Dimensions
    {
        public decimal Height { get; private set; }
        public decimal Width { get; private set; }
        public decimal Depth { get; private set; }

        public Dimensions(decimal height, decimal width, decimal depth)
        {
            AssertConcern.ValidateIfLessThan(height, 1, "O campo Altura do produto não pode ser menor ou igual a 0");
            AssertConcern.ValidateIfLessThan(width, 1, "O campo Largura do produto não pode ser menor ou igual a 0");
            AssertConcern.ValidateIfLessThan(depth, 1, "O campo Profundidade do produto não pode ser menor ou igual a 0");

            Height = height;
            Width = width;
            Depth = depth;
        }

        public string FormattedDescription()
        {
            return $"LxAxP: {Width} x {Height} x {Depth}";
        }

        public override string ToString()
        {
            return FormattedDescription();
        }
    }
}
