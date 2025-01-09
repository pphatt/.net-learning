namespace Server.API.Wrappers;

public class ResponseWrapper : IResponseWrapper
{
    public List<string> Messages { get; set; } = new();
    public bool IsSuccessful { get; set; }

    // Fail.
    public static IResponseWrapper Fail()
        => new ResponseWrapper { IsSuccessful = false };

    public static IResponseWrapper Fail(string message)
        => new ResponseWrapper { IsSuccessful = false, Messages = { message } };

    public static IResponseWrapper Fail(List<string> messages)
        => new ResponseWrapper { IsSuccessful = true, Messages = messages };

    public static Task<IResponseWrapper> FailAsync()
        => Task.FromResult(Fail());

    public static Task<IResponseWrapper> FailAsync(string message)
        => Task.FromResult(Fail(message));
    public static Task<IResponseWrapper> FailAsync(List<string> messages)
        => Task.FromResult(Fail(messages));

    // Success.
    public static IResponseWrapper Success()
        => new ResponseWrapper() { IsSuccessful = true };

    public static IResponseWrapper Success(string message)
        => new ResponseWrapper() { IsSuccessful = true, Messages = { message } };

    public static IResponseWrapper Success(List<string> messages)
        => new ResponseWrapper() { IsSuccessful = true, Messages = messages };

    public static Task<IResponseWrapper> SuccessAsync()
        => Task.FromResult(Success());

    public static Task<IResponseWrapper> SuccessAsync(string message)
        => Task.FromResult(Success(message));
    public static Task<IResponseWrapper> SuccessAsync(List<string> messages)
        => Task.FromResult(Success(messages));
}

public class ResponseWrapper<T> : ResponseWrapper, IResponseWrapper<T>
{
    public T ResponseData { get; set; }

    // Fail.
    public static new IResponseWrapper<T> Fail()
        => new ResponseWrapper<T>() { IsSuccessful = false };

    public static new IResponseWrapper<T> Fail(string message)
        => new ResponseWrapper<T>() { IsSuccessful = false, Messages = { message } };

    public static new IResponseWrapper<T> Fail(List<string> messages)
        => new ResponseWrapper<T>() { IsSuccessful = false, Messages = messages };

    public static new Task<IResponseWrapper<T>> FailAsync()
        => Task.FromResult(Fail());

    public static new Task<IResponseWrapper<T>> FailAsync(string message)
        => Task.FromResult(Fail(message));

    public static new Task<IResponseWrapper<T>> FailAsync(List<string> messages)
        => Task.FromResult(Fail(messages));

    // Success.
    public static new IResponseWrapper<T> Success()
        => new ResponseWrapper<T>() { IsSuccessful = true };

    public static IResponseWrapper<T> Success(T responseData)
        => new ResponseWrapper<T>() { IsSuccessful = true, ResponseData = responseData };

    public static IResponseWrapper<T> Success(T responseData, string message)
        => new ResponseWrapper<T>() { IsSuccessful = true, Messages = { message }, ResponseData = responseData };

    public static IResponseWrapper<T> Success(T responseData, List<string> messages)
        => new ResponseWrapper<T>() { IsSuccessful = true, Messages = messages, ResponseData = responseData };

    public static new Task<IResponseWrapper<T>> SuccessAsync()
        => Task.FromResult(Success());

    public static Task<IResponseWrapper<T>> SuccessAsync(T responseData)
        => Task.FromResult(Success(responseData));

    public static Task<IResponseWrapper<T>> SuccessAsync(string message, T responseData)
        => Task.FromResult(Success(responseData, message));
    public static Task<IResponseWrapper<T>> SuccessAsync(List<string> messages, T responseData)
        => Task.FromResult(Success(responseData, messages));
}
