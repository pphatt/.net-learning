namespace Server.Domain.Exceptions;

public class NotFoundException : Exception
{
    public string _resourceType { get; set; }
    public string _resourceIdentifier { get; set; }

    public NotFoundException(string resourceType, string resourceIdentifier) : base($"{resourceIdentifier} with id: {resourceType} does not exist.")
    {
        _resourceType = resourceType;
        _resourceIdentifier = resourceIdentifier;
    }
}
