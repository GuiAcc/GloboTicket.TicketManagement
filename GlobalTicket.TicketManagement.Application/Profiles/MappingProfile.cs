using AutoMapper;
using GlobaTicket.TicketManagement.Application.Features.Events;
using GlobaTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GlobaTicket.TicketManagement.Application.Features.Events.Queries.GetEventList;
using GlobaTicket.TicketManagement.Application.Features.Events.Queries.GetEventsList;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetCategoriesListWithEvents;
using GloboTicket.TicketManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobaTicket.TicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();

            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, DeleteEventCommand>().ReverseMap();
        }
    }
}
