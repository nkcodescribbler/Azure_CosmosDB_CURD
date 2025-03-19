using Azure_CosmosDB_CURD.Model;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Serialization.HybridRow.Schemas;
using System.ComponentModel;
using System.Xml.Linq;
using PartitionKey = Microsoft.Azure.Cosmos.PartitionKey;

namespace Azure_CosmosDB_CURD.Repo
{
    public class CosmosData : ICosmosData
    {
        private readonly CosmosClient cosmosClient;
        private readonly string _accountUrl;
        private readonly string _primarykey;
        public CosmosData(IConfiguration config) {
            _accountUrl = config.GetValue<string>("Cosmos:AccountURL");
            _primarykey = config.GetValue<string>("Cosmos:AuthKey");
            cosmosClient = new CosmosClient(_accountUrl, _primarykey);
        }
       public bool CreateCollection(string dbName, string ContainerId)
        {
            try
            {
                // Get a reference to the existing database
                var database = cosmosClient.GetDatabase(dbName);
                var container = database.CreateContainerIfNotExistsAsync(ContainerId, "/id");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateDatabase(string DatabaseId)
        {
            try
            {
                var database = cosmosClient.CreateDatabaseIfNotExistsAsync(DatabaseId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CreateDocument(string dbName, string ContainerId, UserInfo userInfo)
        {
            try
            {
                var database = cosmosClient.GetDatabase(dbName);
                var container = database.GetContainer(ContainerId);

                // Create a new document
                var document = new UserInfo();

                document.id = Guid.NewGuid().ToString();
                document.FirstName = userInfo.FirstName;
                document.LastName = userInfo.LastName;
                document.Department = userInfo.Department;                
                

                var response = container.CreateItemAsync(document, new PartitionKey(document.id));
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeleteUserDocument(string dbName, string ContainerId, string id, string partitionKey)
        {
            try
            {
                var database = cosmosClient.GetDatabase(dbName);
                var container = database.GetContainer(ContainerId);
                var parti = new PartitionKey(partitionKey);
                var response = container.DeleteItemAsync<dynamic>(id, parti);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
