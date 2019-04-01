using Microsoft.Extensions.Configuration;
using Pusaka.Web.NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Pusaka.Web.NetCore.Classes;
using Pusaka.Web.NetCore.Interfaces;
using Newtonsoft.Json;
using Microsoft.AspNetCore.WebUtilities;

namespace Pusaka.Web.NetCore.Services
{
    public class SchoolService : ISchoolService
    {
        private IConfiguration _configs;
        private IHttpClientFactory _httpClientFactory;
        public SchoolService(IHttpClientFactory httpClientFactory, IConfiguration configs)
        {
            _configs = configs;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<SchoolModel>> GetSchoolAsync(GetPostParamModel param)
        {
            try
            {
                string returnValue = string.Empty;
                string functionBaseURI = string.Empty;
                string url = string.Format(string.Format(_configs[Constants.PusakaAzureFunctionUrl] + _configs[Constants.GetSchoolAzureFunctionConfig]));

                var queryArguments = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(param.Page)) queryArguments.Add("page", param.Page);
                if (!string.IsNullOrEmpty(param.Size)) queryArguments.Add("size", param.Size);
                if (!string.IsNullOrEmpty(param.Keyword)) queryArguments.Add("keyword", param.Keyword);
                if (!string.IsNullOrEmpty(param.Sort)) queryArguments.Add("sort", param.Sort);
                if (!string.IsNullOrEmpty(param.OrderBy)) queryArguments.Add("orderby", param.OrderBy);

                functionBaseURI = QueryHelpers.AddQueryString(url, queryArguments);

                HttpClient httpClient = _httpClientFactory.CreateClient(Constants.AzureFunctionClient);
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, functionBaseURI))
                {
                    request.Headers.Add(Constants.AzureFunctionKeyHeader, _configs[Constants.GetSchoolAzureFunctionKeyConfig]);

                    using (var response = await httpClient.SendAsync(request).ConfigureAwait(false))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            returnValue = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
                return JsonConvert.DeserializeObject<List<SchoolModel>>(returnValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
