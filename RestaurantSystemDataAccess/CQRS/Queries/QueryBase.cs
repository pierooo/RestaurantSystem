using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS.Queries
{
    public abstract class QueryBase <TResult>
    {
        public abstract Task<TResult> Execute(OrdersStorageContext context);
    }
}
