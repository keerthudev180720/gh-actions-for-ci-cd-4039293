# 02_01 Deliver Software artifacts and Packages

## GitHub Packages – Supported Package Formats

|Package Format|Language / Platform|Configuration File|
|--------------|-------------------|------------------|
|npm|JavaScript / Node.js|`package.json`|
|RubyGems|Ruby|`Gemfile`|
|Apache Maven|Java|`pom.xml`|
|Gradle|Java|`build.gradle`, `build.gradle.kts`|
|NuGet|.NET|`.nupkg`|
|Containers (Docker / OCI)|Any (containerized apps)|`Dockerfile`|

## Supported Package Build and Publish Commands

| Language / Platform | Build Command | Publish Command |
|---------------------|---------------|-----------------|
| Java                | mvn package   | mvn deploy      |
| JavaScript          | npm ci        | npm publish     |
| Ruby                | gem build     | gem push        |
| .NET                | dotnet pack   |dotnet nuget push|
| Docker              | docker build  | docker push     |

## References

- [Working with a GitHub Packages registry](https://docs.github.com/en/packages/working-with-a-github-packages-registry)
- [About permissions for GitHub Packages](https://docs.github.com/en/packages/learn-github-packages/about-permissions-for-github-packages#about-scopes-and-permissions-for-package-registries)

<!-- FooterStart -->
---
[← 01_06 Solution: Build a CI Workflow for a Python Project](../../ch1_continous_integration_workflows/01_06_solution_build_a_ci_workflow_for_a_python_project/README.md) | [02_02 Build and Publish a Software Package →](../02_02_build_publish_a_package/README.md)
<!-- FooterEnd -->
