using GloboTicket.TicketManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobaTicket.TicketManagement.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {

    }
}
