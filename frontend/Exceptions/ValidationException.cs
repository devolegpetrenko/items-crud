namespace frontend.Exceptions;

public class ValidationException : Exception
{
    public string[] Errors { get; set; }

    public ValidationException(string[] errors)
    {
        Errors = errors;
    }
}