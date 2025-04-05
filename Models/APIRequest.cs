using static MyProject.Web.Utility.CConst;

namespace MyProject.Web.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public ContentType ContentType { get; set; } = ContentType.Json;
    }
}
