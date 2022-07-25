using AssignmentSigortamNet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSigortamNet.Integration
{
    public interface IApiManager
    {
        Task<Result<String>> MakePostRequest(string fullPath, Dictionary<string, string> headerParams, string jsonSerializeBody);
        Task<Result<HttpResponseMessage>> MakeGetRequest(string fullPath, Dictionary<string, string> headerParams, Dictionary<string, string> bodyParams);
    }
}
