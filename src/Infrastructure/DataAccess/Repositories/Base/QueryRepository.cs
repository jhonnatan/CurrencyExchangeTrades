using Domain.Repositories.Query.Base;

namespace Infrastructure.DataAccess.Repositories.Base
{
    public class QueryRepository<T> : DbConnector, IQueryRepository<T> where T : class
    {        

    }
}
