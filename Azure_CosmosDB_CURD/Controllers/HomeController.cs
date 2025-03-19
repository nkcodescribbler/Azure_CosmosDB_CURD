using Azure_CosmosDB_CURD.Model;
using Azure_CosmosDB_CURD.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Azure_CosmosDB_CURD.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        ICosmosData _cosmosData;
        public HomeController(ICosmosData cosmosData) {
            _cosmosData = cosmosData;
        }
        // GET: HomeController

        [HttpGet("createdb")]
        public async Task<IActionResult> CreateDatabase()
        {
            var result =  _cosmosData.CreateDatabase("test-db");
            return Ok(result);
        }

        [HttpGet("createcollection")]
        public async Task<IActionResult> CreateCollection()
        {
            var result =  _cosmosData.CreateCollection("test-db", "test-collection");
            return Ok(result);
        }

        [HttpPost("createdocument")]
        public async Task<IActionResult> CreateDocument([FromBody] UserInfo user)
        {
            var result =  _cosmosData.CreateDocument("test-db", "test-collection", user);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, string partitionKey)
        {
            var result = _cosmosData.DeleteUserDocument("test-db", "test-collection", id, partitionKey);
            return Ok(result);
        }
    }
}
