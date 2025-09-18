using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProviderAbstract.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProviderAbstract.Helpers
{
    public static class RequestHelper
    {
        public static async Task<RequestResult<T>> GetResultFromResponse<T>(HttpResponseMessage response)
        {
            var isSuccess = response.IsSuccessStatusCode;
            var content = await response.Content.ReadAsStringAsync();
            var hasContent = content != null;

            if (isSuccess && hasContent)
            {
                var data = JsonConvert.DeserializeObject<T>(content!,new JsonSerializerSettings()
                {
                    
                });
                return new RequestResult<T>() { Result = data };
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
    }
}
