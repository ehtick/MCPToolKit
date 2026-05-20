# Azure Cosmos DB MCP Client

This client demonstrates how to use Microsoft Foundry agents with the Cosmos DB MCP Toolkit.

## Setup

1. **Create a `.env` file** from the example:
   ```bash
   cp .env.example .env
   ```

2. **Update the `.env` file** with your values from `deployment-info.json`:
   ```bash
   PROJECT_ENDPOINT=<YOUR-AI-FOUNDRY-PROJECT-ENDPOINT>
   MODEL_DEPLOYMENT_NAME=<YOUR-MODEL-DEPLOYMENT-NAME>
   CONNECTION_NAME=<YOUR-MCP-CONNECTION-NAME>
   MCP_SERVER_URL=https://<YOUR-CONTAINER-APP-URL>/mcp
   MCP_SERVER_LABEL=cosmosdb
   ```
   
   > Get these values from your `deployment-info.json` file or Azure portal.

3. **Install dependencies**:
   ```bash
   pip install -r requirements.txt
   ```

4. **Make sure you have the MCP connection configured in Microsoft Foundry**:
   - Connection Name: `<YOUR-MCP-CONNECTION-NAME>`
   - Target URL: `https://<YOUR-CONTAINER-APP-URL>/mcp`
   - Audience: `<YOUR-ENTRA-APP-CLIENT-ID>`
   - Authentication: Project Managed Identity

## Run

```bash
python agents_cosmosdb_mcp.py
```

## What it does

The script creates an AI agent that can:
- List databases in your Cosmos DB account
- List containers in a database
- Get recent documents
- Search for documents
- Perform vector search
- Get container schemas

## Input Validation

The MCP server now enforces strict server-side validation for tool inputs.

- Tool calls must match the declared `inputSchema` exactly.
- Unknown fields are rejected.
- Required fields, types, and numeric bounds are enforced.
- Free-form string inputs are length-limited and normalized by the server.

For this sample client, tool invocation is still delegated to the Foundry agent runtime rather than manually constructing `tools/call` payloads. That means no client-side protocol changes are required, but invalid tool arguments may now fail fast instead of being loosely accepted.

## Sample Questions

Edit the `input_text` array in the script to test different questions:

```python
input_text = [
    "Can you list all the databases in my Cosmos DB account?",
    "Show me the containers in the first database",
    "What does the schema look like for the first container?",
    "Get me the 5 most recent documents from the first container",
    "Search for documents containing 'test' in the name property",
]
```

Change `content=input_text[0]` to test different questions (e.g., `input_text[1]`, `input_text[2]`, etc.).

## Troubleshooting

If you see "network error":
1. Check container app logs: `az containerapp logs show --name <YOUR-CONTAINER-APP-NAME> --resource-group <YOUR-RESOURCE-GROUP> --tail 50`
2. Verify the MCP connection in Microsoft Foundry has the correct audience
3. Make sure the agent has access to the connection

If authentication fails:
1. Verify the Entra App Client ID matches your `deployment-info.json`
2. Check role assignments are in place (run `Setup-AIFoundry-RoleAssignment.ps1` if needed)
3. Ensure the container app has the correct environment variables

If a tool call fails with `Invalid params`:
1. Check that the tool arguments match the schema returned by `tools/list`.
2. Remove any unexpected properties from the request.
3. Make sure string values are not empty or overly long.
4. Make sure numeric values stay within the documented ranges.
