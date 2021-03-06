using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Catalog.Domain.Events
{
    public class ProductBelowStockEvent : DomainEvent
    {
        public int RemainingQuantity { get; private set; }

        public ProductBelowStockEvent(Guid aggregateId, int remainingQuantity) : base(aggregateId)
        {
            RemainingQuantity = remainingQuantity;
        }
    }
}
