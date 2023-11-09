using FluentValidation;
using GlobaTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator :AbstractValidator<CreateCategoryCommand>
    {
       
        public CreateCategoryCommandValidator()
        {

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PrepertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");
        }
    }
}
