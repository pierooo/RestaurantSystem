using RestaurantSystemDataAccess.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemDataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly OrdersStorageContext context;

        public CommandExecutor(OrdersStorageContext context) => this.context = context;
        public Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command)
        {
            return command.Execute(this.context);
        }
    }
}
