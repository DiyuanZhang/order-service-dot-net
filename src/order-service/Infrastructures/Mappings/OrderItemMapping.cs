using FluentNHibernate.Mapping;
using order_service.Domains;

namespace order_service.Infrastructures.Mappings
{
    public class OrderItemMapping : ClassMap<OrderItem>
    {
        public OrderItemMapping()
        {
            Table("OrderItems");
            Id(o => o.Id).GeneratedBy.Native();
            Map(o => o.Name).Column("Name").Not.Nullable();
            References(o => o.Order).Column("OrderId");
        }
    }
}
