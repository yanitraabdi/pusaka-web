using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Pusaka.Web.NetCore.Classes;
using Pusaka.Web.NetCore.Interfaces;
using Pusaka.Web.NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pusaka.Web.NetCore.Services
{
    public class LookupService : ILookupService
    {
        private IConfiguration _configs;
        private IHttpClientFactory _httpClientFactory;
        public LookupService(IHttpClientFactory httpClientFactory, IConfiguration configs)
        {
            _configs = configs;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<LookupModel>> GetGenderAsync()
        {
            try
            {
                string returnValue = string.Empty;
                string functionBaseURI = string.Format(string.Format(_configs[Constants.PusakaAzureFunctionUrl] + _configs[Constants.GetGenderAzureFunctionConfig]));

                HttpClient httpClient = _httpClientFactory.CreateClient(Constants.AzureFunctionClient);
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, functionBaseURI))
                {
                    request.Headers.Add(Constants.AzureFunctionKeyHeader, _configs[Constants.GetAzureDefaultHostKeyConfig]);

                    using (var response = await httpClient.SendAsync(request).ConfigureAwait(false))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            returnValue = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
                return JsonConvert.DeserializeObject<List<LookupModel>>(returnValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<LookupModel>> GetReligionAsync()
        {
            try
            {
                string returnValue = string.Empty;
                string functionBaseURI = string.Format(string.Format(_configs[Constants.PusakaAzureFunctionUrl] + _configs[Constants.GetReligionAzureFunctionConfig]));

                HttpClient httpClient = _httpClientFactory.CreateClient(Constants.AzureFunctionClient);
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, functionBaseURI))
                {
                    request.Headers.Add(Constants.AzureFunctionKeyHeader, _configs[Constants.GetAzureDefaultHostKeyConfig]);

                    using (var response = await httpClient.SendAsync(request).ConfigureAwait(false))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            returnValue = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
                return JsonConvert.DeserializeObject<List<LookupModel>>(returnValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<LookupModel>> GetSchoolTypeAsync()
        {
            try
            {
                string returnValue = string.Empty;
                string functionBaseURI = string.Format(string.Format(_configs[Constants.PusakaAzureFunctionUrl] + _configs[Constants.GetSchoolTypeAzureFunctionConfig]));

                HttpClient httpClient = _httpClientFactory.CreateClient(Constants.AzureFunctionClient);
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, functionBaseURI))
                {
                    request.Headers.Add(Constants.AzureFunctionKeyHeader, _configs[Constants.GetAzureDefaultHostKeyConfig]);

                    using (var response = await httpClient.SendAsync(request).ConfigureAwait(false))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            returnValue = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
                return JsonConvert.DeserializeObject<List<LookupModel>>(returnValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
