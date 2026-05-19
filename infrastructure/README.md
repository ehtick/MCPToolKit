# Infrastructure Deployment

This directory contains the infrastructure templates for deploying the Azure MCP Toolkit Container App.

## What Gets Deployed

The infrastructure templates create only the necessary resources for running the MCP Toolkit:

- **Azure Container Registry** for storing container images
- **Azure Container Apps Environment** with managed identity
- **Azure Container App** for running the MCP Toolkit
- **Managed Identity** for secure authentication

## Prerequisites

You must already have:
- **Azure Cosmos DB** account with your data
- **Azure AI Services (Cognitive Services)** account with an embedding model deployment (e.g., text-embedding-ada-002 or text-embedding-3-small)

> **Important**: Use the Azure AI Services **account endpoint** from the Cognitive Services resource, not a Microsoft Foundry project endpoint. 
> 
> ✅ **CORRECT format**: `https://<resource-name>.cognitiveservices.azure.com/`
> 
> ❌ **WRONG format** (Foundry project): `https://<project-name>.services.ai.azure.com/api/projects/...`
> 
> To get your endpoint: Go to Azure Portal → Cognitive Services resource → Overview page → copy the "Endpoint" URL

## Deployment Options

### Option 1: PowerShell Script (Recommended)

```powershell
# Navigate to the scripts directory
cd scripts

# Run the deployment script
.\Deploy-Cosmos-MCP-Toolkit.ps1 -ResourceGroup "mcp-toolkit-rg"
```

### Option 3: Manual Bicep Deployment

```powershell
# Create resource group
az group create --name "mcp-toolkit-rg" --location "East US"

# Deploy using Bicep template
az deployment group create \
  --resource-group "mcp-toolkit-rg" \
  --template-file "deploy-all-resources.bicep" \
  --parameters \
    "cosmosEndpoint=https://yourcosmosdb.documents.azure.com:443/" \
    "azureAiServiceEndpoint=https://my-ai-service.cognitiveservices.azure.com/" \
    "embeddingDeploymentName=text-embedding-ada-002"

# Optional: use an existing ACR in another resource group
az deployment group create \
  --resource-group "mcp-toolkit-rg" \
  --template-file "deploy-all-resources.bicep" \
  --parameters \
    "cosmosEndpoint=https://yourcosmosdb.documents.azure.com:443/" \
    "azureAiServiceEndpoint=https://my-ai-service.cognitiveservices.azure.com/" \
    "embeddingDeploymentName=text-embedding-ada-002" \
    "useExistingAcr=true" \
    "existingAcrName=mysharedacr" \
    "existingAcrResourceGroup=shared-acr-rg"
```

## Post-Deployment Steps

After deployment, you need to:

1. **Set up RBAC permissions** for your external resources
2. **Build and deploy the container image**
3. **Test the deployment**

See the [Deploy to Azure Guide](../docs/deploy-to-azure-guide.md) for detailed post-deployment instructions.

## Files

- `deploy-all-resources.bicep` - Main Bicep template for all resources
- `deploy-all-resources.json` - ARM template (auto-generated from Bicep)
- `deploy-all-resources.parameters.template.json` - Parameter template file
- `main.bicep` - Simplified template for existing deployments
