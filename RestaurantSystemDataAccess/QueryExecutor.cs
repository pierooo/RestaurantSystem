using RestaurantSystemDataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly OrdersStorageContext context;
        public QueryExecutor(OrdersStorageContext context) => this.context = context;
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.context);
        }
    }
}
