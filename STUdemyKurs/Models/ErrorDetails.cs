using Newtonsoft.Json;

namespace STUdemyKurs.Models
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public string StatusCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
