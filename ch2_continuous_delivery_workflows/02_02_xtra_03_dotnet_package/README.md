# 02_02 Extra Content 3: Build and Publish a .NET Package

Continuous delivery workflows for .NET packages follow a pattern with these steps:

- Configure the project to work with the package registry
- Authenticate with the target registry
- Build the package
- Publish the package to the registry

## Registry configuration and authentication

.NET packages use `.csproj` to configure the target registry and authentication.

| Language  | Config File          |
|-----------|---------------------|
| JavaScript| package.json         |
| Ruby      | .gemspec             |
| Java      | settings.xml, pom.xml|
| .Net      | .csproj              |

## Build and publish

.NET uses dotnet CLI commands for building and publishing packages.

| Language  | Build, publish Commands       |
|-----------|------------------------------|
| JavaScript| npm ci; npm publish           |
| Ruby      | gem build; gem push           |
| Java      | mvn package; maven deploy     |
| .Net      | dotnet pack; dotnet nuget push|

## Package Versions

The `.csproj` file defines a version number for the package being published.

> [!IMPORTANT]
> Version numbers can't be reused.

Update code to reference a new version number with each new release. In GitHub Actions workflows, you can use the `GITHUB_RUN_NUMBER` environment variable to generate unique versions.

## References

- [Working with a GitHub Packages registry](https://docs.github.com/en/packages/working-with-a-github-packages-registry)
- [actions/setup-dotnet on GitHub Marketplace](https://github.com/marketplace/actions/setup-net-sdk)
- [actions/checkout on GitHub Marketplace](https://github.com/marketplace/actions/checkout)
- [Publishing NuGet packages](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry)

## Lab: Publishing a .NET Package to GitHub Packages with NuGet

In this lab, you'll configure and run a GitHub Actions workflow that builds a .NET project and publishes the resulting NuGet package to GitHub Packages. By the end of the lab, you'll have a versioned .NET package automatically built and delivered using a push-based workflow trigger.

### Overview

You'll start with a .NET project that already includes:

- Application source code
- A test suite using xUnit
- A `.csproj` configured for packaging and publishing

Using a GitHub-provided starter workflow, you'll customize the workflow to:

- Run on every push
- Use updated GitHub Actions versions
- Match the .NET SDK version expected by the project

### Prerequisites

Before starting this lab, make sure you have:

- A GitHub repository containing the provided exercise files

### Instructions

#### 1. Review the Project Files

In your repository, review the files that make up the .NET project:

- `CurrencyConverter.cs` — the main application code
- `CurrencyConverterTests.cs` — the test suite
- `CurrencyConverter.csproj` — the .NET project configuration file

While reviewing `CurrencyConverter.csproj`, note the following:

- The `<PackageId>` defines the NuGet package name.
- The `<Version>` property should be updated using the `GITHUB_RUN_NUMBER` environment variable.
- The `<RepositoryUrl>` links to the GitHub repository.

These settings allow .NET to package the application and deliver it to GitHub's package registry during the workflow run.

#### 2. Create the Workflow Using a Starter Template

1. Navigate to the **Actions** tab in your repository.
2. Review the suggested workflows based on the repository contents.
3. Locate and select **"Publish .NET Package."**
4. Choose **Configure** to open the workflow editor.

This starter workflow already includes the core steps needed to build and publish a .NET package.

#### 3. Update the Workflow

1. Add a `push:` trigger

    By default, the workflow is triggered by a release event. Update it so it also runs on every push.

    - Under the `on:` section, add a `push:` trigger.

    This change ensures the workflow runs automatically whenever you commit changes to the repository.

2. Update the actions

    To ensure you're using current tooling, update the following actions:

    - `actions/checkout`
    - `actions/setup-dotnet`

    Use the [references section](#references) to find the latest version for each action.

3. Update the .NET SDK Version

    The project's `.csproj` specifies a target framework.

    - Change the setup-dotnet step to use **.NET SDK 8.0** or higher
    - Update the `dotnet-version` value accordingly

    This ensures dotnet commands run with the correct .NET SDK during the build and publish steps.

4. Update Package Version

    Before building, update the package version using `GITHUB_RUN_NUMBER`:

    ```yaml
    - name: Update package version
      run: |
        dotnet build-server shutdown
        dotnet build /p:Version=0.0.${{ github.run_number }}
    ```

5. Configure NuGet Source

    Add a step to configure the NuGet source for GitHub Packages:

    ```yaml
    - name: Add NuGet source
      run: |
        dotnet nuget add source https://nuget.pkg.github.com/OWNER/index.json \
          --name github \
          --username OWNER \
          --password ${{ secrets.GITHUB_TOKEN }} \
          --store-password-in-clear-text
    ```

    Replace `OWNER` with your GitHub username or organization name.

6. Commit the Workflow

    Commit the updated workflow file to the repository.

    Because the workflow now includes a push trigger, committing the file immediately starts a workflow run.

#### 4. Monitor the Workflow Run

1. Return to the **Actions** tab.
2. Select the running workflow.
3. Wait for the job to complete.

A successful run indicates that:

- The project was compiled
- Tests passed
- The package was published successfully

#### 5. Verify the Published Package

1. Navigate back to the repository's **Code** tab.
2. Look for the **Packages** section on the repository home page.
3. Refresh the page if needed; packages may take a moment to appear.
4. Select the package name once it becomes visible.

On the package page, you'll find:

- Installation instructions
- Version details
- Download statistics
- Direct links to the published artifacts

<!-- FooterStart -->
---
[← 02_02 Extra Content 2: Build and Publish a Ruby Package](../02_02_xtra_02_ruby_package/README.md) | [02_03 Build and Publish a Container Image →](../02_03_build_publish_a_container_image/README.md)
<!-- FooterEnd -->
