# 02_02 Extra Content 1: Build and Publish a JavaScript Package

Continuous delivery workflows for JavaScript packages follow a pattern with these steps:

- Configure the project to work with the package registry
- Authenticate with the target registry
- Build the package
- Publish the package to the registry

## Registry configuration and authentication

JavaScript packages use `package.json` to configure the target registry and authentication.

| Language  | Config File          |
|-----------|---------------------|
| JavaScript| package.json         |
| Ruby      | .gemspec             |
| Java      | settings.xml, pom.xml|
| .Net      | .csproj              |

## Build and publish

JavaScript uses npm for building and publishing packages.

| Language  | Build, publish Commands       |
|-----------|------------------------------|
| JavaScript| npm ci; npm publish           |
| Ruby      | gem build; gem push           |
| Java      | mvn package; maven deploy     |
| .Net      | dotnet pack; dotnet nuget push|

## Package Versions

The `package.json` file defines a version number for the package being published.

> [!IMPORTANT]
> Version numbers can't be reused.

Update code to reference a new version number with each new release. In GitHub Actions workflows, you can use the `GITHUB_RUN_NUMBER` environment variable to generate unique versions.

## References

- [Working with a GitHub Packages registry](https://docs.github.com/en/packages/working-with-a-github-packages-registry)
- [actions/setup-node on GitHub Marketplace](https://github.com/marketplace/actions/setup-node-js-environment)
- [actions/checkout on GitHub Marketplace](https://github.com/marketplace/actions/checkout)
- [Publishing npm packages](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-npm-registry)

## Lab: Publishing a JavaScript Package to GitHub Packages with npm

In this lab, you'll configure and run a GitHub Actions workflow that builds a JavaScript project with npm and publishes the resulting package to GitHub Packages. By the end of the lab, you'll have a versioned JavaScript package automatically built and delivered using a push-based workflow trigger.

### Overview

You'll start with a JavaScript project that already includes:

- Application source code
- A test suite using Jest
- A `package.json` configured for packaging and publishing

Using a GitHub-provided starter workflow, you'll customize the workflow to:

- Run on every push
- Use updated GitHub Actions versions
- Match the Node.js version expected by the project

### Prerequisites

Before starting this lab, make sure you have:

- A GitHub repository containing the provided exercise files

### Instructions

#### 1. Review the Project Files

In your repository, review the files that make up the JavaScript project:

- `currency-converter.js` — the main application code
- `currency-converter.test.js` — the test suite
- `package.json` — the npm configuration file

While reviewing `package.json`, note the following:

- The `publishConfig` section is configured to publish the package to GitHub Packages.
- The package name should follow the format `@OWNER/package-name` for GitHub Packages.

These settings allow npm to package the application and deliver it to GitHub's package registry during the workflow run.

#### 2. Create the Workflow Using a Starter Template

1. Navigate to the **Actions** tab in your repository.
2. Review the suggested workflows based on the repository contents.
3. Locate and select **"Publish Node.js Package."**
4. Choose **Configure** to open the workflow editor.

This starter workflow already includes the core steps needed to build and publish a JavaScript package.

#### 3. Update the Workflow

1. Add a `push:` trigger

    By default, the workflow is triggered by a release event. Update it so it also runs on every push.

    - Under the `on:` section, add a `push:` trigger.

    This change ensures the workflow runs automatically whenever you commit changes to the repository.

2. Update the actions

    To ensure you're using current tooling, update the following actions:

    - `actions/checkout`
    - `actions/setup-node`

    Use the [references section](#references) to find the latest version for each action.

3. Update the Node.js Version

    The project's `package.json` specifies a minimum Node.js version.

    - Change the setup-node step to use **Node.js 18** or higher
    - Update the `node-version` value accordingly

    This ensures npm runs with the correct Node.js runtime during the build and publish steps.

4. Update Package Version

    Before publishing, update the package version using `GITHUB_RUN_NUMBER`:

    ```yaml
    - name: Update package version
      run: |
        VERSION="0.0.${{ github.run_number }}"
        npm version $VERSION --no-git-tag-version
    ```

5. Commit the Workflow

    Commit the updated workflow file to the repository.

    Because the workflow now includes a push trigger, committing the file immediately starts a workflow run.

#### 4. Monitor the Workflow Run

1. Return to the **Actions** tab.
2. Select the running workflow.
3. Wait for the job to complete.

A successful run indicates that:

- The project was built
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
[← 02_02 Build and Publish a Software Package](../02_02_build_publish_a_package/README.md) | [02_02 Extra Content 2: Build and Publish a Ruby Package →](../02_02_xtra_02_ruby_package/README.md)
<!-- FooterEnd -->
