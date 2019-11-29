using System;
using System.Collections.Generic;
using System.Fabric;
using System.Fabric.Query;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Client;
using Newtonsoft.Json;

namespace GetwayApplication.Controllers
{
    [Route("Gateway/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly GatewayConfigSettings settings;
        private readonly StatelessServiceContext serviceContext;
        private readonly HttpClient httpClient;
        private readonly string reverseProxyBaseUri;
        private readonly FabricClient fabricClient;

        public DataController(GatewayConfigSettings settings, StatelessServiceContext serviceContext, HttpClient httpClient, FabricClient fabricClient)
        {
            this.settings = settings;
            this.serviceContext = serviceContext;
            this.httpClient = httpClient;
            this.fabricClient = fabricClient;
            this.reverseProxyBaseUri = Environment.GetEnvironmentVariable("ReverseProxyBaseUri");
        }

        [HttpGet("{serv}")]
        [ActionName("Get ")]
        public async Task<IActionResult> GetAsync(string serv)
        {
            Uri serviceUri = null;
            Uri proxyUrl = null;
            string actualServiceUrl = "";
            try
            {
                if (serv == "product")
                { 
                    serviceUri = new Uri(this.serviceContext.CodePackageActivationContext.ApplicationName + "/ProductsService");
                    proxyUrl = new Uri($"{this.reverseProxyBaseUri}{serviceUri.AbsolutePath}");
                    actualServiceUrl = $"{proxyUrl}/api/Product";
                }
                if (serv == "category")
                {
                    serviceUri = new Uri(this.serviceContext.CodePackageActivationContext.ApplicationName + "/CategoryService");
                    proxyUrl = new Uri($"{this.reverseProxyBaseUri}{serviceUri.AbsolutePath}");
                    actualServiceUrl = $"{proxyUrl}/api/Category";
                }
               // var actualServiceUrl = $"{proxyUrl}/api/Category";
                // var proxyUrl = $"http://localhost:8081/api/Product";
                //  HttpResponseMessage response = await this.httpClient.GetAsync(proxyUrl);
                HttpResponseMessage response = await this.httpClient.GetAsync(actualServiceUrl);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return this.StatusCode((int)response.StatusCode);
                }
                return this.Ok(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}