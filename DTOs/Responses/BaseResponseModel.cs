namespace Misoso.Api.DTOs.Responses
{
    public class BaseResponseModel
    {
        public BaseResponseModel(bool sucess,object data)
        {
            Success = sucess;
            Data = data;
        }

        public bool Success { get;  private set; }
        public object? Data { get; private set; }
    }
}
