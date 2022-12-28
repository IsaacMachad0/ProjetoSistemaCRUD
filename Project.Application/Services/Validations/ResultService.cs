using FluentValidation.Results;

namespace Project.Application.Services.Validations
{
    public class ResultService
    {
        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public ICollection<ErrorValidation> Errors { get; set; }

        public static ResultService RequestError(string messageError, ValidationResult validationResult)
        {
            return new ResultService
            {
                IsSucess = false,
                Message = messageError,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage}).ToList()
            };
        }
        public static ResultService<T> RequestError<T>(string messageError, ValidationResult validationResult)
        {
            return new ResultService<T>
            {
                IsSucess = false,
                Message = messageError,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }
        public static ResultService Error(string messageError)
        {
            return new ResultService
            {
                IsSucess = false,
                Message = messageError
            };
        }
        public static ResultService<T> Error<T>(string messageError)
        {
            return new ResultService<T>
            {
                IsSucess = false,
                Message = messageError
            };
        }
        public static ResultService Ok(string messageError)
        {
            return new ResultService
            {
                IsSucess = true,
                Message = messageError
            };
        }
        public static ResultService<T> Ok<T>(T data)
        {
            return new ResultService<T>
            {
                IsSucess = true,
                Data = data
            };
        }
    }

    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}
