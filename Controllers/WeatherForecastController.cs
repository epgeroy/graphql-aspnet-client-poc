using System.Threading.Tasks;
using aspnet_core.Controllers.Dto;
using GraphQL;
using GraphQL.Client.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IGraphQLClient _client;
        public WeatherForecastController(IGraphQLClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task Get()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                query AllProducts {
                    products {
                        id
                        name
                        description {
                            html
                        }
                    }
                }"
            };

            var response = await _client.SendQueryAsync<ResponseAllProductsCollectionType>(query);
        }
    }
}
