using AutoMapper;
using GlobaTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQueryHandler : IRequestHandler<GetCategoriesListWithEventsQuery, List<CategoryEventListVm>>
    {
        private readonly IMapper _mapper;
        private readonly ICatergoryRepository _categoryRepository;

        public GetCategoriesListWithEventsQueryHandler(IMapper mapper, ICatergoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryEventListVm>> Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
            return _mapper.Map<List<CategoryEventListVm>>(list); 
        }

    }
    
}
