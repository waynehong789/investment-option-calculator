using System;
using System.Collections.Generic;
using System.Linq;
using DotNetCleanArchitecture.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shared.Application.Exceptions;
using Shared.Core.Constants;

namespace DotNetCleanArchitecture.API.Filters
{
    public class ApiExceptionFilterAttribute: ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceprionHandlers;
        public ApiExceptionFilterAttribute()
        {
            // Register know exception types and handlers.
            _exceprionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(NotFoundException), HandleNotFoundException }
            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);
            base.OnException(context);
        }

        public void HandleException (ExceptionContext context)
        {
            Type type = context.Exception.GetType();

            if (_exceprionHandlers.ContainsKey(type))
            {
                _exceprionHandlers[type].Invoke(context);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
                return;
            }

            HandleUnknownException(context);
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            var response = new Response<List<string>>
            {
                Success = false,
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = MessageDetailsType.InternalServerError,
                Errors = new List<string>{"An error occurred while processing your request"}
            };

            context.Result = new BadRequestObjectResult(response)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }

        private void HandleValidationException(ExceptionContext context)
        {
            var exception = context.Exception as ValidationException;

            var response = new Response<List<string>>
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest,
                Message = MessageDetailsType.InvalidRequest,
                Errors = exception.Errors
            };

            context.Result = new BadRequestObjectResult(response);
            context.ExceptionHandled = true;
        }

        private void HandleInvalidModelStateException(ExceptionContext context)
        {
            var errors = context.ModelState.Values.SelectMany(m => m.Errors)
                                 .Select(e => e.ErrorMessage)
                                 .ToList();

            var response = new Response<List<string>>
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest,
                Message = MessageDetailsType.InvalidRequest,
                Errors = errors
            };

            context.Result = new BadRequestObjectResult(response);
            context.ExceptionHandled = true;
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as NotFoundException;

            var response = new Response<List<string>>
            {
                Success = false,
                StatusCode = StatusCodes.Status404NotFound,
                Message = MessageDetailsType.ResourceNotFound,
                Errors = new List<string> { exception.Message }
            };

            context.Result = new NotFoundObjectResult(response);
            context.ExceptionHandled = true;
        }
    }
}