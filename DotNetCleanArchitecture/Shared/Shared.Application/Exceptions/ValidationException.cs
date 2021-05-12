
using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Shared.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("One or more validation failures have occurred.") 
        {
            Errors = new List<string>();
        }
        public ValidationException(IEnumerable<ValidationFailure> failures) : this() 
        {
            Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage).Select(x => x.Key).ToList();
        }
        
        public List<string> Errors {get;}
        
    }
}