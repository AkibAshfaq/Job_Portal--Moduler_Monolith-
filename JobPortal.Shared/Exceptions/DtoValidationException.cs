namespace JobPortal.Shared.Exceptions
{
    public class DtoValidationException: Exception
    {
        public IReadOnlyDictionary<string, string[]> Errors { get; }

        public DtoValidationException()
            : this("One or more validation errors occurred.") { }

        public DtoValidationException(string message)
            : base(message)
            => Errors = new Dictionary<string, string[]>();

        public DtoValidationException(IDictionary<string, string[]> errors)
            : base("One or more validation errors occurred.")
            => Errors = new Dictionary<string, string[]>(errors);

        public DtoValidationException(string field, string error)
            : this(new Dictionary<string, string[]> { [field] = [error] }) { }
    }
}
