# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added
- Release channel guidance and customer-facing versioning policy in the README.

### Changed
- Added startup validation for `OPENAI_ENDPOINT` to reject Foundry project URLs and provide actionable guidance.
- Trimmed OpenAI configuration values before use to reduce failures caused by accidental whitespace.
- Enabled MCP HTTP transport registration for SDK endpoint mapping.

### Fixed
- Prevented 500 errors during role-denied tool calls by returning a structured 403 JSON-RPC response.
- Restored MCP compatibility for external clients by mapping the SDK endpoint at `/mcp`.
- Moved custom JSON-RPC controller endpoint to `/mcp/http` and updated web UI calls accordingly.
- Renamed vector score alias from `_score` to `score` so Cosmos query results include similarity score.

## [1.0.0] - 2025-09-15

### Added
- Initial version of the Azure Cosmos DB MCP Toolkit.
- Basic MCP server functionality.
- Azure Cosmos DB integration.
- Azure OpenAI integration for vector search.