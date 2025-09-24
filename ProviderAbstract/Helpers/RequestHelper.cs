using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProviderAbstract.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProviderAbstract.Helpers
{
    public static class RequestHelper
    {
        public static async Task<RequestResult<T>> GetResultFromResponse<T>(HttpResponseMessage response,string? scecificTokenData = null!)
        {
            var isSuccess = response.IsSuccessStatusCode;
            var content = await GetData(response,scecificTokenData);
            var hasContent = content != null;

            if (isSuccess && hasContent)
            {
                var data = JsonConvert.DeserializeObject<T>(content!,new JsonSerializerSettings()
                {
                    DefaultValueHandling = DefaultValueHandling.Populate,
                    NullValueHandling = NullValueHandling.Include
                });
                return new RequestResult<T>() { Result = data! };
            }
            else
            {
                return new RequestResult<T>() { ErrorMessage = content };
            }
        }
        public static RequestResult<TData> CloneWithNewResult<TData,TRequest>(RequestResult<TRequest> obj,TData data)
        {
            return new RequestResult<TData>()
            {
                ErrorMessage = obj.ErrorMessage,
                Exception = obj.Exception,
                Result = data
            };
        }
        public static string GetEndPointWithParameters(string endPoint,Dictionary<string,string> endPointParameters = null!,Dictionary<string,string> requestParameters = null!)
        {
            StringBuilder sb = new StringBuilder(endPoint);

            if (endPointParameters != null)
            {
                foreach (var item in endPointParameters)
                {
                    sb = sb.Replace("{" + $"{item.Key}" + "}", item.Value);
                }
            }
            if(requestParameters!=null)
            {
                sb = sb.Append("?");
                foreach (var item in requestParameters)
                {
                    sb = sb.Append($"{item.Key}={item.Value}&");
                }
                sb = sb.Remove(sb.Length - 1, 1);
            }
            var result = sb.ToString();
            return result;
        }
        private static async Task<string> GetData(HttpResponseMessage response,string? specificTokenData = null!)
        {
            var content = await response.Content.ReadAsStringAsync();

            try
            {
                if (specificTokenData == null)
                {
                    return content;
                }
                else
                {
                    JToken jToken = JObject.Parse(content);
                    var dataToken = jToken.SelectToken(specificTokenData == null ? "data" : specificTokenData);
                    if(dataToken == null)
                    {
                        return content;
                    }
                    else
                    {
                        return jToken.ToString();
                    }
                }
            }
            catch 
            {
                return "Error";
            }
        }
    }
}
