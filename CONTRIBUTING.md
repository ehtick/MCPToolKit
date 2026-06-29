This project welcomes contributions and suggestions. Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit https://cla.microsoft.com.

# Contributing to MCP Toolkit

We welcome contributions from the community! Whether you're fixing bugs, improving docs, or building new features, your help makes this project better.

## 🚀 Getting Started (New Contributors)

### Pick Your Contribution Type

**👶 First time contributing?** Start here:
- 📝 [Good First Issues](https://github.com/AzureCosmosDB/MCPToolKit/issues?q=is%3Aissue+is%3Aopen+label%3A%22good+first+issue%22) — Simple tasks perfect for beginners
- 📖 **Documentation** — Fix typos, clarify instructions, add examples
- 🐛 **Report a Bug** — Found something broken? Open an issue

**Looking for more challenge?**
- 💻 [Medium Issues](https://github.com/AzureCosmosDB/MCPToolKit/issues?q=is%3Aissue+is%3Aopen+label%3A%22help+wanted%22) — Feature requests and improvements
- 🏗️ **Architecture** — Design new systems or refactor existing code
- 🎯 Check our [ROADMAP.md](ROADMAP.md) for planned features

---

## 🛠️ Local Development Setup (2 minutes)

### Prerequisites
- Git
- .NET 9.0 SDK
- PowerShell 7+
- Docker (optional, for full testing)

### Quick Start

```powershell
# 1. Clone the repository
git clone https://github.com/AzureCosmosDB/MCPToolKit.git
cd MCPToolKit

# 2. Restore dependencies
dotnet restore AzureCosmosDB.MCP.Toolkit.sln

# 3. Build the solution
dotnet build AzureCosmosDB.MCP.Toolkit.sln -c Debug

# 4. Run tests
dotnet test AzureCosmosDB.MCP.Toolkit.sln -c Debug

# 5. Run locally
dotnet run --project src/AzureCosmosDB.MCP.Toolkit/AzureCosmosDB.MCP.Toolkit.csproj
```

Server will start at `http://localhost:8080`

---

## 💡 Contribution Ideas

### 📖 Documentation (15 min - 1 hour)
- ✅ Fix typos or grammar
- ✅ Clarify confusing instructions
- ✅ Add code examples
- ✅ Create diagrams for architecture

**How to:**
1. Find a doc in `/docs` or `/README.md`
2. Click "Edit" on GitHub
3. Make your changes
4. Submit a PR with description

### 🐛 Bug Fixes (1 - 4 hours)
- ✅ Reproduce the bug (add test case)
- ✅ Fix the issue
- ✅ Add test to prevent regression
- ✅ Submit a PR

**How to:**
1. Pick a bug from [Issues labeled "bug"](https://github.com/AzureCosmosDB/MCPToolKit/issues?q=is%3Aissue+is%3Aopen+label%3Abug)
2. Create a feature branch: `git checkout -b fix/issue-number`
3. Make your changes
4. Run tests: `dotnet test`
5. Push and create a PR

### ✨ Features (4 - 8 hours)
- ✅ New MCP tools
- ✅ Enhanced search capabilities
- ✅ Security improvements
- ✅ Performance optimizations

**How to:**
1. Discuss in [Issues](https://github.com/AzureCosmosDB/MCPToolKit/issues) or [Discussions](https://github.com/AzureCosmosDB/MCPToolKit/discussions) first
2. Check [ROADMAP.md](ROADMAP.md) for planned features
3. Create feature branch: `git checkout -b feature/your-feature-name`
4. Implement with tests
5. Update docs
6. Submit a PR

### 🧪 Tests & Quality (1 - 2 hours)
- ✅ Add unit tests
- ✅ Add integration tests
- ✅ Improve test coverage
- ✅ Performance benchmarks

**How to:**
See `/tests/AzureCosmosDB.MCP.Toolkit.Tests/` for examples

### 🎯 Help Wanted
Check current priorities:
- [🔴 High Priority](https://github.com/AzureCosmosDB/MCPToolKit/issues?q=is%3Aissue+is%3Aopen+label%3Apriority%3Ahigh)
- [🟡 Medium Priority](https://github.com/AzureCosmosDB/MCPToolKit/issues?q=is%3Aissue+is%3Aopen+label%3Apriority%3Amedium)

---

## 📋 Pull Request Process

### Before You Start
1. Check [existing PRs](https://github.com/AzureCosmosDB/MCPToolKit/pulls) — avoid duplicates
2. Open an issue first for large changes (get feedback early!)
3. Create a feature branch: `git checkout -b feature/your-change`

### Making Changes
```powershell
# Make your changes
# Test them
dotnet test AzureCosmosDB.MCP.Toolkit.sln -c Debug

# Commit with clear message
git commit -m "Fix: Describe what you fixed" -m "Closes #issue-number"

# Push to your fork
git push origin feature/your-change
```

### Submit Your PR
1. Create PR with clear title and description
2. Link related issues: `Fixes #123` or `Related to #456`
3. **First-time contributor?** A CLA bot will ask you to sign. It's quick and one-time.
4. Request review from maintainers
5. Address feedback kindly

### PR Checklist
- [ ] Builds without errors (`dotnet build`)
- [ ] Tests pass (`dotnet test`)
- [ ] New feature has tests
- [ ] Updated docs (if needed)
- [ ] Commit messages are clear
- [ ] No unnecessary dependencies added

---

## 📚 Code Standards

### Style Guide
- Follow C# coding conventions ([Microsoft style guide](https://docs.microsoft.com/dotnet/csharp/fundamentals/coding-style/coding-conventions))
- Use meaningful variable names
- Add comments for complex logic
- Keep methods focused and small

### Testing
- Every feature should have unit tests
- Write integration tests for MCP tools
- Test error cases, not just happy paths
- Use descriptive test names: `TestListDatabasesWithValidCredentials`

### Documentation
- Add XML comments to public methods
- Update README if behavior changes
- Add examples for new features

---

## 🤝 Community & Support

### Get Help
- 💬 [GitHub Discussions](https://github.com/AzureCosmosDB/MCPToolKit/discussions) — Ask questions
- 🐛 [GitHub Issues](https://github.com/AzureCosmosDB/MCPToolKit/issues) — Report bugs or request features
- 📧 Email: [opencode@microsoft.com](mailto:opencode@microsoft.com)

### Share Your Work
- Tell us about your use case in [Discussions](https://github.com/AzureCosmosDB/MCPToolKit/discussions)
- Show off your contribution! We'd love to hear about it.

---

## 📜 Legal Requirements

Most contributions require a **Contributor License Agreement (CLA)** so we can use your work.

- Microsoft will automatically ask you to sign when you submit your first PR
- It takes 2 minutes (read & click)
- You only need to do it once across all Microsoft repositories

For details, visit: https://cla.microsoft.com

---

## Code of Conduct

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).

**Expected Behavior:**
- ✅ Be respectful and inclusive
- ✅ Welcome diverse perspectives
- ✅ Focus on constructive feedback
- ✅ Respect others' time and effort

**Unacceptable Behavior:**
- ❌ Harassment or discrimination
- ❌ Insulting or demeaning comments
- ❌ Personal attacks
- ❌ Sharing sensitive information without consent

**Report Issues:**
Email [opencode@microsoft.com](mailto:opencode@microsoft.com) with details.

---

## 🎉 Thank You!

Your contribution helps make MCP Toolkit better for everyone. We appreciate your time and effort!

**Questions?** Open an issue or start a discussion. We're here to help. 🙌