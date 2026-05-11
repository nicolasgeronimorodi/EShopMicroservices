namespace BuildingBlocks.Exceptions;
public class InternalServerException : Exception
{
    public string? Details { get; set; }

    public InternalServerException(string message): base (message)
	{

	}

    protected InternalServerException(string message, string details) : base(message)
    {
        Details = details;
    }
}
