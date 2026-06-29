# Security Policy

## Reporting a Vulnerability

If you discover a security vulnerability in the Azure Cosmos DB MCP Toolkit, please report it responsibly to us rather than disclosing it publicly. This helps us address security issues before they become a widespread problem.

### How to Report

**Please do NOT create a public GitHub issue.** Instead:

1. **Email Security Report:**
   - Send to: [opencode@microsoft.com](mailto:opencode@microsoft.com)
   - Subject line: `[Security] Azure Cosmos DB MCP Toolkit Vulnerability`
   - Include the vulnerability details

2. **What to Include:**
   - Description of the vulnerability
   - Steps to reproduce (if applicable)
   - Potential impact and severity
   - Suggested fix (if you have one)

3. **Expected Response:**
   - We acknowledge receipt within 2 business days
   - We'll investigate and provide updates on our progress
   - We'll work with you to understand and fix the issue
   - We'll credit you in the security advisory (if desired)

---

## Security Considerations

### Authentication & Authorization

- **Entra ID Required:** The MCP server requires Azure Entra ID tokens for all requests
- **Managed Identity:** Azure Container Apps uses managed identity for Cosmos DB access (no keys in code)
- **Role-Based Access (RBAC):** Users must be assigned the `Mcp.Tool.Executor` role
- **Token Validation:** All JWT tokens are validated before processing requests

### Data Security

- **Cosmos DB Protection:** The server only has access to the specific Cosmos DB account you configure
- **HTTPS Only:** All communication is encrypted in transit (HTTPS)
- **No Telemetry:** The server does not collect or send telemetry about your data
- **No Logging:** Query data is not logged by the MCP server itself

### Container Security

- **Multi-stage Docker Build:** Production image includes only runtime, no build tools
- **Azure Container Registry:** Images stored securely with private network options
- **Container Scanning:** Recommend scanning images for vulnerabilities before deployment
- **Managed Service:** Azure Container Apps handles patching and updates

### Network Security

- **Recommended:** Deploy MCP server in a private virtual network with Azure Cosmos DB
- **Firewall Rules:** Use Cosmos DB firewall to restrict access
- **Private Endpoints:** Consider using Private Link for network isolation

---

## Supported Versions

| Version | Status | Security Updates |
|---------|--------|-----------------|
| 1.1.x | Current | ✅ Yes |
| 1.0.x | End of Life | ❌ No |

We recommend upgrading to the latest version to receive security updates and bug fixes.

---

## Security Best Practices

When using the MCP Toolkit:

1. **Keep Dependencies Updated:**
   ```powershell
   # Update .NET SDK regularly
   dotnet tool update -g azure-functions-core-tools
   ```

2. **Secure Cosmos DB Access:**
   - Use connection strings from Key Vault (not hardcoded)
   - Rotate keys regularly
   - Use Managed Identity when possible

3. **Monitor Access:**
   - Enable Azure Monitor for Container Apps
   - Enable Azure Cosmos DB audit logs
   - Review role assignments regularly

4. **Network Isolation:**
   - Deploy in a private VNet
   - Use Private Endpoints for Cosmos DB
   - Restrict Container App ingress

5. **Update Regularly:**
   - Check for new releases monthly
   - Subscribe to security advisories
   - Test updates in a staging environment first

---

## Vulnerability Disclosure Timeline

We aim to:
- 🔴 **Critical** (CVSS 9-10): Patch within 1-2 days
- 🟠 **High** (CVSS 7-8.9): Patch within 1 week
- 🟡 **Medium** (CVSS 4-6.9): Patch within 2 weeks
- 🟢 **Low** (CVSS 0-3.9): Include in next release

---

## Acknowledgments

We thank security researchers who responsibly disclose vulnerabilities. We'll acknowledge your responsible disclosure if you wish (you can request anonymity).

---

## Additional Resources

- [Microsoft Security Response Center (MSRC)](https://msrc.microsoft.com/)
- [Azure Security Best Practices](https://learn.microsoft.com/azure/security/fundamentals/)
- [Cosmos DB Security](https://learn.microsoft.com/azure/cosmos-db/database-security)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)

---

**Last Updated:** June 2026
