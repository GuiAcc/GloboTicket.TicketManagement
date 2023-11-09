using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace GloboTicket.TicketManagement.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> ValidationErros { get; set; }

        public ValidationException(ValidationResult validationResult)
        {
            ValidationErros = new List<string>();

            foreach(var validationError in validationResult.Errors)
            {
                ValidationErros.Add(validationError.ErrorMessage);
            }
        }
    }
}
