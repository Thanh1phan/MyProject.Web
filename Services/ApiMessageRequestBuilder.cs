using MyProject.Web.Models;
using MyProject.Web.Services.IServices;
using MyProject.Web.Utility;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System.Text;
using static MyProject.Web.Utility.CConst;

namespace MyProject.Web.Services
{
    public class ApiMessageRequestBuilder : IApiMessageRequestBuilder
    {
        public HttpRequestMessage Build(APIRequest apiRequest)
        {
            HttpRequestMessage message = new();
            if (apiRequest.ContentType == ContentType.MultipartFormData)
            {
                message.Headers.Add("Accept", "*/*");
            }
            else
            {
                message.Headers.Add("Accept", "application/json");
            }
            message.RequestUri = new Uri(apiRequest.Url);

            if (apiRequest.ContentType == ContentType.MultipartFormData)
            {
                var content = new MultipartFormDataContent();

                foreach (var prop in apiRequest.Data.GetType().GetProperties())
                {
                    var value = prop.GetValue(apiRequest.Data);
                    if (value is IFormFile)
                    {
                        var file = (IFormFile)value;
                        if (file != null)
                        {
                            content.Add(new StreamContent(file.OpenReadStream()), prop.Name, file.FileName);
                        }
                    }
                    else if (value is IEnumerable<IFormFile>)
                    {
                        var files = (IEnumerable<IFormFile>)value;
                        foreach (var fileItem in files)
                        {
                            if (fileItem != null)
                            {
                                var streamContent = new StreamContent(fileItem.OpenReadStream());
                                streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(fileItem.ContentType);

                                string formFileName = prop.Name;
                                content.Add(streamContent, formFileName, fileItem.FileName);
                            }
                        }
                    }
                    else if (value is IEnumerable<string> || value is IEnumerable<int> || value is IEnumerable<bool>)
                    {
                        Func<IEnumerable<string>> list = () =>
                        {
                            if (value is IEnumerable<string> stringList)
                            {
                                return stringList;
                            }
                            else if (value is IEnumerable<int> intList)
                            {
                                return intList.Select(x => x.ToString()); 
                            }
                            else if (value is IEnumerable<bool> boolList)
                            {
                                return boolList.Select(x => x.ToString());
                            }    
                            return null;
                        };

                        foreach (var item in list())
                        {
                            content.Add(new StringContent(item == null ? null : item.ToString()), prop.Name);
                        }
                    }    
                    else
                    {
                        if(value != null)
                        {
                            content.Add(new StringContent(value.ToString()), prop.Name);
                        }
                    }
                }

                message.Content = content;
            }
            else
            {
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }
            }


            switch (apiRequest.ApiType)
            {
                case CConst.ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case CConst.ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case CConst.ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;

            }

            return message;
        }
    }
}
