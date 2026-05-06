using Azure.AI.OpenAI;
using Azure.Identity;

namespace AzureCosmosDB.MCP.Toolkit.Services;

/// <summary>
/// Factory for creating Azure OpenAI embedding clients with support for both cloud and local development.
/// Enables local development via API key or connection string.
/// </summary>
public static class EmbeddingClientFactory
{
    /// <summary>
    /// Create an AzureOpenAIClient for embedding operations.
    /// 
    /// Priority order:
    /// 1. OPENAI_API_KEY - for local development or scenarios where API key is available
    /// 2. OPENAI_ENDPOINT with DefaultAzureCredential - for cloud production with Azure authentication
    /// </summary>
    public static AzureOpenAIClient CreateEmbeddingClient(IConfiguration configuration, ILogger logger)
    {
        var endpoint = configuration["OPENAI_ENDPOINT"] 
            ?? Environment.GetEnvironmentVariable("OPENAI_ENDPOINT");

        if (string.IsNullOrWhiteSpace(endpoint))
        {
            throw new InvalidOperationException(
                "OPENAI_ENDPOINT environment variable must be set. " +
                "For local development, set OPENAI_ENDPOINT to your local Foundry or OpenAI endpoint URL. " +
                "For cloud production, set OPENAI_ENDPOINT to your Azure OpenAI resource endpoint.");
        }

        // Check for API key first (local development or scenarios where key is available)
        var apiKey = configuration["OPENAI_API_KEY"] 
            ?? Environment.GetEnvironmentVariable("OPENAI_API_KEY");

        if (!string.IsNullOrWhiteSpace(apiKey))
        {
            logger.LogInformation("Creating embedding client using API key (local/key-based mode)");
            return new AzureOpenAIClient(new Uri(endpoint), new Azure.AzureKeyCredential(apiKey));
        }

        // Fall back to Azure credentials for cloud production
        logger.LogInformation("Creating embedding client using Azure credentials (cloud mode)");
        var credential = new DefaultAzureCredential();
        return new AzureOpenAIClient(new Uri(endpoint), credential);
    }
}
