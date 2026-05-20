This project welcomes contributions and suggestions. Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether
you need to provide a CLA and decorate the PR appropriately (e.g., label,
comment). Simply follow the instructions provided by the bot. You will only need
to do this once across all repositories using our CLA.

There are several ways you can contribute to the [MCPToolKit repository](https://github.com/AzureCosmosDB/MCPToolKit):

- **Ideas, feature requests and bugs**: We are open to all ideas, and we want to get rid of bugs. Use the [Issues](https://github.com/AzureCosmosDB/MCPToolKit/issues) section to report a new issue, provide your ideas, or contribute to existing threads.
- **Documentation**: Found a typo or confusing wording? Submit a PR.
- **Code**: Contribute bug fixes, features, or design changes:
  - Clone the repository and open it in VS Code.
  - Restore dependencies from the repository root:
    - `dotnet restore AzureCosmosDB.MCP.Toolkit.sln`
    - `pip install -r client/requirements.txt` (optional, for Python client updates)
  - Build the solution:
    - `dotnet build AzureCosmosDB.MCP.Toolkit.sln -c Debug`
  - Run tests:
    - `dotnet test AzureCosmosDB.MCP.Toolkit.sln -c Debug`
  - Validate local app behavior as needed:
    - `dotnet run --project src/AzureCosmosDB.MCP.Toolkit/AzureCosmosDB.MCP.Toolkit.csproj`

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/)
or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.