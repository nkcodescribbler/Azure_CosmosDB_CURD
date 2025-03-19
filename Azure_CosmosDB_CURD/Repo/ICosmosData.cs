using Azure_CosmosDB_CURD.Model;

namespace Azure_CosmosDB_CURD.Repo
{
    public interface ICosmosData
    {
        bool CreateDatabase(string name);
        bool CreateCollection(string dbName, string name);
        bool CreateDocument(string dbName, string name, UserInfo userInfo);
        bool DeleteUserDocument(string dbName, string name, string id, string partitionKey);
    }
}
