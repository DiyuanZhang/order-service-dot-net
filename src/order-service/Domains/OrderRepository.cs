using NHibernate;

namespace order_service.Domains
{
    public class OrderRepository
    {
        private readonly ISession session;

        public OrderRepository(ISession session)
        {
            this.session = session;
        }

        public void Save(Order order)
        {
            session.Save(order);
        }
    }
}
