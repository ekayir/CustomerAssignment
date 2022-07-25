using AssignmentSigortamNet.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSigortamNet.Integration
{
    public class ApiManager : IApiManager
    {
        public async Task<Result<String>> MakePostRequest(string fullPath, Dictionary<string, string> headerParams, string jsonSerializeBody)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(fullPath)
                };

                if (jsonSerializeBody != null) request.Content = new StringContent(jsonSerializeBody, Encoding.UTF8, "application/json");

                if (headerParams != null) headerParams.ToList().ForEach(x => request.Headers.Add(x.Key, x.Value));

                var response = await client.SendAsync(request);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode == false) return new Result<String> { Data = null, IsSuccess = false, Message = response.ReasonPhrase + " : " + jsonResponse };

                return new Result<String> { Data = jsonResponse, IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new Result<String> { Data = null, IsSuccess = false, Message = Result.FromException(ex).Message };
            }
        }
        public async Task<Result<HttpResponseMessage>> MakeGetRequest(string fullPath, Dictionary<string, string> headerParams, Dictionary<string, string> bodyParams)
        {
            try
            {
                HttpClient client = null;

                HttpClientHandler handler = new HttpClientHandler();

                client = new HttpClient(handler);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (headerParams != null) headerParams.ToList().ForEach(x => client.DefaultRequestHeaders.Add(x.Key, x.Value));

                if (bodyParams != null && bodyParams.Count > 0)
                {
                    fullPath += "?";
                    bodyParams.ToList().ForEach(x => fullPath += x.Key + "=" + x.Value + "&");
                }

                var response = await client.GetAsync(fullPath);
                var jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode == false) return new Result<HttpResponseMessage> { Data = null, IsSuccess = false, Message = response.ReasonPhrase + " : " + jsonResponse };

                return new Result<HttpResponseMessage> { Data = response, IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new Result<HttpResponseMessage> { Data = null, IsSuccess = false, Message = Result.FromException(ex).Message };
            }
        }

    }
}
