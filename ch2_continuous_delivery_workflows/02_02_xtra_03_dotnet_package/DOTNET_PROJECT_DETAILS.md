# .NET Project Details

A modern .NET project that provides currency conversion functionality, demonstrating .NET build and package publishing workflows.

## Prerequisites

- .NET SDK >= 8.0
- Git (for version control)

## Project Structure

```
.
├── CurrencyConverter.csproj                        # .NET project configuration
├── CurrencyConverter.cs                            # Main application class
├── CurrencyConverterTests.cs                        # Test suite
└── README.md                                       # Project README
```

## Configuration

The project uses a `.csproj` file for configuration. Key settings are defined in `CurrencyConverter.csproj`:

| Property                    | Value        | Description                    |
|-----------------------------|--------------|--------------------------------|
| `TargetFramework`           | `net8.0`     | Target .NET framework version  |
| `PackageId`                 | `CurrencyConverter` | NuGet package ID      |
| `PackageLicenseExpression`  | `MIT`        | Package license                |
| `xunit`                     | `2.6.2`      | xUnit version for testing      |

## Versioning

The package version should be updated to use `GITHUB_RUN_NUMBER` environment variable in GitHub Actions workflows:
- Format: `0.0.${GITHUB_RUN_NUMBER}`
- Example: `0.0.123` for run number 123
- Update the `<Version>` property in the `.csproj` file before building

## Publishing to GitHub Packages

To publish to GitHub Packages, configure the NuGet source in GitHub Actions:
- Registry: `https://nuget.pkg.github.com/OWNER/index.json`
- Authentication is handled via GitHub Actions using `GITHUB_TOKEN`

## Building and Testing

- Build: `dotnet build`
- Test: `dotnet test`
- Pack: `dotnet pack`
- Publish: `dotnet nuget push`
