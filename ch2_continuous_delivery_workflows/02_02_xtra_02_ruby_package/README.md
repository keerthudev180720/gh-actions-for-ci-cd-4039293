# 02_02 Extra Content 2: Build and Publish a Ruby Package

Continuous delivery workflows for Ruby packages follow a pattern with these steps:

- Configure the project to work with the package registry
- Authenticate with the target registry
- Build the package
- Publish the package to the registry

## Registry configuration and authentication

Ruby packages use `.gemspec` to configure the target registry and authentication.

| Language  | Config File          |
|-----------|---------------------|
| JavaScript| package.json         |
| Ruby      | .gemspec             |
| Java      | settings.xml, pom.xml|
| .Net      | .csproj              |

## Build and publish

Ruby uses gem commands for building and publishing packages.

| Language  | Build, publish Commands       |
|-----------|------------------------------|
| JavaScript| npm ci; npm publish           |
| Ruby      | gem build; gem push           |
| Java      | mvn package; maven deploy     |
| .Net      | dotnet pack; dotnet nuget push|

## Package Versions

The `.gemspec` file defines a version number for the package being published.

> [!IMPORTANT]
> Version numbers can't be reused.

Update code to reference a new version number with each new release. In GitHub Actions workflows, you can use the `GITHUB_RUN_NUMBER` environment variable to generate unique versions.

## References

- [Working with a GitHub Packages registry](https://docs.github.com/en/packages/working-with-a-github-packages-registry)
- [ruby/setup-ruby on GitHub Marketplace](https://github.com/marketplace/actions/setup-ruby-jruby-and-truffleruby)
- [actions/checkout on GitHub Marketplace](https://github.com/marketplace/actions/checkout)
- [Publishing RubyGems packages](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-rubygems-registry)

## Lab: Publishing a Ruby Package to GitHub Packages with RubyGems

In this lab, you'll configure and run a GitHub Actions workflow that builds a Ruby project and publishes the resulting gem to GitHub Packages. By the end of the lab, you'll have a versioned Ruby gem automatically built and delivered using a push-based workflow trigger.

### Overview

You'll start with a Ruby project that already includes:

- Application source code
- A test suite using RSpec
- A `.gemspec` configured for packaging and publishing

Using a GitHub-provided starter workflow, you'll customize the workflow to:

- Run on every push
- Use updated GitHub Actions versions
- Match the Ruby version expected by the project

### Prerequisites

Before starting this lab, make sure you have:

- A GitHub repository containing the provided exercise files

### Instructions

#### 1. Review the Project Files

In your repository, review the files that make up the Ruby project:

- `currency_converter.rb` — the main application code
- `currency_converter_spec.rb` — the test suite
- `currency-converter.gemspec` — the gem specification file

While reviewing `currency-converter.gemspec`, note the following:

- The `metadata["allowed_push_host"]` is configured to publish the package to GitHub Packages.
- The version is defined in `lib/currency_converter/version.rb` and uses the `GITHUB_RUN_NUMBER` environment variable.

These settings allow RubyGems to package the application and deliver it to GitHub's package registry during the workflow run.

#### 2. Create the Workflow Using a Starter Template

1. Navigate to the **Actions** tab in your repository.
2. Review the suggested workflows based on the repository contents.
3. Locate and select **"Publish Ruby Gem."**
4. Choose **Configure** to open the workflow editor.

This starter workflow already includes the core steps needed to build and publish a Ruby gem.

#### 3. Update the Workflow

1. Add a `push:` trigger

    By default, the workflow is triggered by a release event. Update it so it also runs on every push.

    - Under the `on:` section, add a `push:` trigger.

    This change ensures the workflow runs automatically whenever you commit changes to the repository.

2. Update the actions

    To ensure you're using current tooling, update the following actions:

    - `actions/checkout`
    - `actions/setup-ruby`

    Use the [references section](#references) to find the latest version for each action.

3. Update the Ruby Version

    The project's `.gemspec` specifies a minimum Ruby version.

    - Change the setup-ruby step to use **Ruby 3.0** or higher
    - Update the `ruby-version` value accordingly

    This ensures gem commands run with the correct Ruby runtime during the build and publish steps.

4. Set Environment Variable

    Before building, set the `GITHUB_RUN_NUMBER` environment variable:

    ```yaml
    - name: Set version from run number
      run: |
        echo "GITHUB_RUN_NUMBER=${{ github.run_number }}" >> $GITHUB_ENV
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
[← 02_02 Extra Content 1: Build and Publish a JavaScript Package](../02_02_xtra_01_javascript_package/README.md) | [02_02 Extra Content 3: Build and Publish a .NET Package →](../02_02_xtra_03_dotnet_package/README.md)
<!-- FooterEnd -->
