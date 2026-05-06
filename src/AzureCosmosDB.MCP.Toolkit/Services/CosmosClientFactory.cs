using Azure.Identity;
using Microsoft.Azure.Cosmos;

namespace AzureCosmosDB.MCP.Toolkit.Services;

/// <summary>
/// Factory for creating CosmosClient instances with support for both Azure credentials and connection strings.
/// Enables local development with Cosmos DB emulator via connection string.
/// </summary>
public static class CosmosClientFactory
{
    /// <summary>
    /// Create a CosmosClient with fallback support for connection strings and Azure credentials.
    /// 
    /// Priority order:
    /// 1. COSMOS_CONNECTION_STRING - for emulator or local development
    /// 2. COSMOS_ENDPOINT with DefaultAzureCredential - for cloud production
    /// </summary>
    public static CosmosClient CreateCosmosClient(IConfiguration configuration, ILogger logger)
    {
        // Check for connection string first (emulator/local development)
        var connectionString = configuration["COSMOS_CONNECTION_STRING"] 
            ?? Environment.GetEnvironmentVariable("COSMOS_CONNECTION_STRING");

        if (!string.IsNullOrWhiteSpace(connectionString))
        {
            logger.LogInformation("Creating CosmosClient using connection string (emulator/local mode)");
            return new CosmosClient(connectionString, new CosmosClientOptions
            {
                ApplicationName = "AzureCosmosDBMCP",
                EnableContentResponseOnWrite = false,
                RequestTimeout = TimeSpan.FromSeconds(60)
            });
        }

        // Fall back to Azure credentials for cloud production
        var endpoint = configuration["COSMOS_ENDPOINT"] 
            ?? Environment.GetEnvironmentVariable("COSMOS_ENDPOINT");

        if (string.IsNullOrWhiteSpace(endpoint))
        {
            throw new InvalidOperationException(
                "Either COSMOS_ENDPOINT or COSMOS_CONNECTION_STRING environment variable must be set. " +
                "For emulator/local development, use COSMOS_CONNECTION_STRING. " +
                "For cloud production, use COSMOS_ENDPOINT with Azure credentials.");
        }

        logger.LogInformation("Creating CosmosClient using Azure credentials (cloud mode)");
        var credential = new DefaultAzureCredential();

        return new CosmosClient(endpoint, credential, new CosmosClientOptions
        {
            ApplicationName = "AzureCosmosDBMCP",
            EnableContentResponseOnWrite = false,
            RequestTimeout = TimeSpan.FromSeconds(60)
        });
    }
}
