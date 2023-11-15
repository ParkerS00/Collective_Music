using System.Runtime.Serialization;

[Serializable]
internal class UnableToCreateDefaultAdminUserException : Exception
{
    public UnableToCreateDefaultAdminUserException()
    {
    }

    public UnableToCreateDefaultAdminUserException(string? message) : base(message)
    {
    }

    public UnableToCreateDefaultAdminUserException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UnableToCreateDefaultAdminUserException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}