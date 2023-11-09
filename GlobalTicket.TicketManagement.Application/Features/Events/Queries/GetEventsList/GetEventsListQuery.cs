using AutoMapper;
using GlobaTicket.TicketManagement.Application.Contracts.Persistence;
using GlobaTicket.TicketManagement.Application.Features.Events.Queries.GetEventsList;
using GloboTicket.TicketManagement.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobaTicket.TicketManagement.Application.Features.Events.Queries.GetEventList
{
    public class GetEventsListQuery : IRequest<List<EventListVm>>
    {

    }
}
