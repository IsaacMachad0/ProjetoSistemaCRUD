namespace Project.Domain.Validation
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string error) : base(error)
        {

        }

        public static void When(bool hasError, string messageError)
        {
            if (hasError)
                throw new DomainValidationException(messageError);
        }
    }
}
