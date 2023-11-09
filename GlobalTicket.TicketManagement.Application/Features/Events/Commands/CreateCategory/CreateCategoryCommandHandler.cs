using AutoMapper;
using GlobaTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICatergoryRepository _catergoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IMapper mapper, ICatergoryRepository catergoryRepository)
        {
            _mapper = mapper;
            _catergoryRepository = catergoryRepository;
        }
        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandResponse request, CancellationToken cancellationToken)
        {
            var createCategoryCommandResponse = new CreateCategoryCommandResponse();

            var validator = new CreateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createCategoryCommandResponse.Success = false;
                createCategoryCommandResponse.ValidationErrors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    createCategoryCommandResponse.ValidationErrors.Add(error.Message);
                }
            }
            if (createCategoryCommandResponse.Success)
            {
                var category = new Category() { Name = request.Name };
                category = await _categoryRepository.AddAsync(category);
                createCategoryCommandResponse.Category = _mapper.Map<CreateCategoryDto>(category);
            }
            return createCategoryCommandResponse;
        }
        

        
    }
}
