using NHibernate;
using ScrumBoard.Persistence.Implementation;

namespace ScrumBoard.Tests.Persistence.Mappings
{
    public static class SessionUtil
    {
        public static ISession GetNewSession()
        {
            var sessionFactoryBuilder = new SessionFactoryBuilder();
            return sessionFactoryBuilder.GetSessionFactory().OpenSession();
        }
    }
}
