namespace MyRESTServices.Models
{
    public class ResponseResult
    {
        public int ErrNumber { get; set; }
        public string ErrMessage { get; set; } = string.Empty;
        public object ResultObject { get; set; }
    }
}
