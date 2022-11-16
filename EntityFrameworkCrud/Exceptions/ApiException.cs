using System.Collections.Generic;
using System;
using FluentValidation.Results;

namespace EntityFrameworkCrud.Exceptions
{
    public class ApiException : Exception
    {
        public IList<ValidationFailure> Errors { get; private set; }

        public ApiException()
        {
            this.Errors = new List<ValidationFailure>();
        }

        public ApiException(string message) : base(message)
        {
            this.Errors = new List<ValidationFailure>();
        }

        public ApiException(string message, IList<ValidationFailure> errors) : base(message)
        {
            this.Errors = errors;
        }

        public static void ThrowException(ApiException ex)
        {
            if (ex.Errors.Count > 0)
            {
                throw new ApiException(ex.Message, ex.Errors);
            }
            else
            {
                throw new ApiException(ex.InnerException == null ? ex.Message :
                        ex.InnerException.InnerException == null ? ex.InnerException.Message :
                        ex.InnerException.InnerException.Message);
            }
        }
        public static void ThrowException(Exception ex)
        {
            throw new ApiException(ex.InnerException == null ? ex.Message :
                        ex.InnerException.InnerException == null ? ex.InnerException.Message :
                        ex.InnerException.InnerException.Message);
        }
    }
}
