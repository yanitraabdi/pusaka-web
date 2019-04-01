using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Pusaka.Web.NetCore.Classes;
using Pusaka.Web.NetCore.Interfaces;
using Pusaka.Web.NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pusaka.Web.NetCore.Services
{
    public class UserService : IUserService
    {
        private IConfiguration _configs;
        private IHttpClientFactory _httpClientFactory;
        public UserService(IHttpClientFactory httpClientFactory, IConfiguration configs)
        {
            _configs = configs;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<UserModel>> GetUserAsync(GetPostParamModel param)
        {
            try
            {
                string returnValue = string.Empty;
                string functionBaseURI = string.Empty;
                string url = string.Format(string.Format(_configs[Constants.PusakaAzureFunctionUrl] + _configs[Constants.GetUserAzureFunctionConfig]));

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
                    request.Headers.Add(Constants.AzureFunctionKeyHeader, _configs[Constants.GetUserAzureFunctionKeyConfig]);

                    using (var response = await httpClient.SendAsync(request).ConfigureAwait(false))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            returnValue = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
                return JsonConvert.DeserializeObject<List<UserModel>>(returnValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            try
            {
                string returnValue = string.Empty;
                string functionBaseURI = string.Empty;
                string url = string.Format(_configs[Constants.PusakaAzureFunctionUrl] + string.Format(_configs[Constants.GetUserByIdAzureFunctionConfig], id));

                HttpClient httpClient = _httpClientFactory.CreateClient(Constants.AzureFunctionClient);
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, functionBaseURI))
                {
                    request.Headers.Add(Constants.AzureFunctionKeyHeader, _configs[Constants.GetUserByIdAzureFunctionKeyConfig]);

                    using (var response = await httpClient.SendAsync(request).ConfigureAwait(false))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            returnValue = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
                return JsonConvert.DeserializeObject<UserModel>(returnValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserModel> InsertUserAsync(UserModel payload)
        {
            try
            {
                string returnValue = string.Empty;
                string functionBaseURI = string.Empty;
                string url = string.Format(string.Format(_configs[Constants.PusakaAzureFunctionUrl] + _configs[Constants.InsertUserAzureFunctionConfig]));

                HttpClient httpClient = _httpClientFactory.CreateClient(Constants.AzureFunctionClient);
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, functionBaseURI))
                {
                    request.Headers.Add(Constants.AzureFunctionKeyHeader, _configs[Constants.InsertUserAzureFunctionKeyConfig]);

                    string json = JsonConvert.SerializeObject(payload);
                    using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        request.Content = stringContent;

                        using (var response = await httpClient.SendAsync(request).ConfigureAwait(false))
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                returnValue = await response.Content.ReadAsStringAsync();
                            }
                        }
                    }
                }

                return JsonConvert.DeserializeObject<UserModel>(returnValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserModel> UpdateUserAsync(UserModel payload)
        {
            try
            {
                string returnValue = string.Empty;
                string functionBaseURI = string.Empty;
                string url = string.Format(string.Format(_configs[Constants.PusakaAzureFunctionUrl] + _configs[Constants.UpdateUserAzureFunctionConfig]));

                HttpClient httpClient = _httpClientFactory.CreateClient(Constants.AzureFunctionClient);
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, functionBaseURI))
                {
                    request.Headers.Add(Constants.AzureFunctionKeyHeader, _configs[Constants.UpdateUserAzureFunctionKeyConfig]);

                    string json = JsonConvert.SerializeObject(payload);
                    using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        request.Content = stringContent;

                        using (var response = await httpClient.SendAsync(request).ConfigureAwait(false))
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                returnValue = await response.Content.ReadAsStringAsync();
                            }
                        }
                    }
                }

                return JsonConvert.DeserializeObject<UserModel>(returnValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                string returnValue = string.Empty;
                string functionBaseURI = string.Empty;
                string url = string.Format(string.Format(_configs[Constants.PusakaAzureFunctionUrl] + _configs[Constants.DeleteUserAzureFunctionConfig], id));

                HttpClient httpClient = _httpClientFactory.CreateClient(Constants.AzureFunctionClient);
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, functionBaseURI))
                {
                    request.Headers.Add(Constants.AzureFunctionKeyHeader, _configs[Constants.DeleteUserAzureFunctionKeyConfig]);

                    using (var response = await httpClient.SendAsync(request).ConfigureAwait(false))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            returnValue = await response.Content.ReadAsStringAsync();
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
