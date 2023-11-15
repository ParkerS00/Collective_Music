using System.Runtime.Serialization;

[Serializable]
internal class MissingDefaultAdminConfigException : Exception
{
    public MissingDefaultAdminConfigException()
    {
    }

    public MissingDefaultAdminConfigException(string? message) : base(message)
    {
    }

    public MissingDefaultAdminConfigException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected MissingDefaultAdminConfigException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}