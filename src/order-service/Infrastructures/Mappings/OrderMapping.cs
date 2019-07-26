using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using order_service.Domains;

namespace order_service.Infrastructures.Mappings
{
    public class OrderMapping : ClassMap<Order>
    {
        public OrderMapping()
        {
            Table("Orders");
            Id(o => o.Id).GeneratedBy.Native();
            HasMany(o => o.OrderItems).KeyColumn("OrderId").Cascade.AllDeleteOrphan();
        }
    }
}
