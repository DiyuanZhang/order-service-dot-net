namespace order_service.Domains
{
    public class OrderItem
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual long OrderId { get; set; }
    }
}
