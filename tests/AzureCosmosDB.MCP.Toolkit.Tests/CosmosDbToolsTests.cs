using Xunit;
using FluentAssertions;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Moq;
using AzureCosmosDB.MCP.Toolkit.Services;
using Microsoft.Azure.Cosmos;

namespace AzureCosmosDB.MCP.Toolkit.Tests;

public class CosmosDbToolsTests
{
    private readonly Mock<ILogger<CosmosDbToolsService>> _loggerMock;
    private readonly Mock<IConfiguration> _configurationMock;
    
    public CosmosDbToolsTests()
    {
        _loggerMock = new Mock<ILogger<CosmosDbToolsService>>();
        _configurationMock = new Mock<IConfiguration>();
    }

    [Fact]
    public void CosmosDbToolsService_Should_Exist()
    {
        // Arrange & Act
        var type = typeof(CosmosDbToolsService);
        
        // Assert
        type.Should().NotBeNull();
        type.Name.Should().Be("CosmosDbToolsService");
    }

    [Fact]
    public async Task TextSearch_Should_Validate_Property_Names()
    {
        // Arrange
        var mockCosmosClient = new Mock<CosmosClient>();
        var service = new CosmosDbToolsService(mockCosmosClient.Object, _loggerMock.Object, _configurationMock.Object);
        var invalidProperty = "invalid-property-name!";
        
        // Act
        var result = await service.TextSearch("testDb", "testContainer", invalidProperty, "search", 1);
        
        // Assert
        result.Should().NotBeNull();
        var resultDict = result as dynamic;
        var errorMessage = JsonSerializer.Serialize(result);
        errorMessage.Should().Contain("Invalid property name");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(21)]
    [InlineData(-1)]
    public async Task GetRecentDocuments_Should_Validate_Count_Parameter(int n)
    {
        // Arrange
        var mockCosmosClient = new Mock<CosmosClient>();
        var service = new CosmosDbToolsService(mockCosmosClient.Object, _loggerMock.Object, _configurationMock.Object);
        
        // Act
        var result = await service.GetRecentDocuments("testDb", "testContainer", n);
        
        // Assert
        result.Should().NotBeNull();
        var errorMessage = JsonSerializer.Serialize(result);
        errorMessage.Should().Contain("must be a whole number between 1 and 20");
    }
    
    [Fact]
    public async Task FindDocumentByID_Should_Require_Parameters()
    {
        // Arrange
        var mockCosmosClient = new Mock<CosmosClient>();
        var service = new CosmosDbToolsService(mockCosmosClient.Object, _loggerMock.Object, _configurationMock.Object);
        
        // Act
        var result = await service.FindDocumentByID("", "", "");
        
        // Assert
        result.Should().NotBeNull();
        var errorMessage = JsonSerializer.Serialize(result);
        errorMessage.Should().Contain("required");
    }

        [Fact]
        public void McpToolRequestValidator_Should_Reject_Unknown_Argument_Properties()
        {
                // Arrange
                var validator = new McpToolRequestValidator();
                using var document = JsonDocument.Parse(
                        """
                        {
                            "name": "list_collections",
                            "arguments": {
                                "databaseId": "db1",
                                "unexpected": "value"
                            }
                        }
                        """);

                // Act
                Action act = () => validator.ValidateToolCall(document.RootElement);

                // Assert
                act.Should().Throw<ToolInputValidationException>()
                        .WithMessage("*Unknown property 'unexpected' in arguments for 'list_collections'.*");
        }

        [Fact]
        public void McpToolRequestValidator_Should_Reject_Wrong_Types()
        {
                // Arrange
                var validator = new McpToolRequestValidator();
                using var document = JsonDocument.Parse(
                        """
                        {
                            "name": "get_recent_documents",
                            "arguments": {
                                "databaseId": "db1",
                                "containerId": "c1",
                                "n": "5"
                            }
                        }
                        """);

                // Act
                Action act = () => validator.ValidateToolCall(document.RootElement);

                // Assert
                act.Should().Throw<ToolInputValidationException>()
                        .WithMessage("*'n' must be an integer.*");
        }

        [Fact]
        public void McpToolRequestValidator_Should_Reject_Oversized_Freeform_Strings()
        {
                // Arrange
                var validator = new McpToolRequestValidator();
                var oversized = new string('a', 2049);
                using var document = JsonDocument.Parse(
                        $$"""
                        {
                            "name": "text_search",
                            "arguments": {
                                "databaseId": "db1",
                                "containerId": "c1",
                                "property": "title",
                                "searchPhrase": "{{oversized}}",
                                "n": 5
                            }
                        }
                        """);

                // Act
                Action act = () => validator.ValidateToolCall(document.RootElement);

                // Assert
                act.Should().Throw<ToolInputValidationException>()
                        .WithMessage("*'searchPhrase' exceeds the maximum length of 2048 characters.*");
        }

        [Fact]
        public void McpToolRequestValidator_Should_Normalize_Valid_Strings()
        {
                // Arrange
                var validator = new McpToolRequestValidator();
                using var document = JsonDocument.Parse(
                        """
                        {
                            "name": "list_collections",
                            "arguments": {
                                "databaseId": "db1"
                            }
                        }
                        """);

                // Act
                var result = validator.ValidateToolCall(document.RootElement);

                // Assert
                result.ToolName.Should().Be("list_collections");
                result.Arguments["databaseId"].Should().Be("db1");
        }
}