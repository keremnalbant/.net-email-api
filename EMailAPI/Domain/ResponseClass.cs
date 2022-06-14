namespace EMailAPI.Domain;

public class ResponseClass
{
    public bool success { get; set; }

    public string Message { get; set; }

    public object data { get; set; }

    public ResponseClass Successfull(string message, object returnData)
    {
        this.success = true;
        this.Message = message;
        this.data = returnData;
        return this;
    }

    public ResponseClass Failure(string message)
    {
        this.success = false;
        this.Message = message;
        return this;
    }
}