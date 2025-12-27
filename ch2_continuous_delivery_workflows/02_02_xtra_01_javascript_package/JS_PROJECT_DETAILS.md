# JavaScript Project Details

A modern JavaScript project that provides currency conversion functionality, demonstrating npm build and package publishing workflows.

## Prerequisites

- Node.js >= 18.0.0
- npm >= 9.0.0
- Git (for version control)

## Project Structure

```
.
├── package.json                                    # npm project configuration
├── src/
│   ├── currency-converter.js                       # Main application class
│   └── __tests__/
│       └── currency-converter.test.js              # Test suite
└── README.md                                       # Project README
```

## Configuration

The project uses npm for configuration. Key settings are defined in `package.json`:

| Property          | Value        | Description                    |
|-------------------|--------------|--------------------------------|
| `main`            | `src/currency-converter.js` | Main entry point        |
| `engines.node`    | `>=18.0.0`   | Minimum Node.js version        |
| `devDependencies.jest` | `^29.7.0` | Jest version for testing |

## Versioning

The package version should be updated to use `GITHUB_RUN_NUMBER` environment variable in GitHub Actions workflows:
- Format: `0.0.${GITHUB_RUN_NUMBER}`
- Example: `0.0.123` for run number 123

## Publishing to GitHub Packages

The `publishConfig` section in `package.json` configures the package to publish to GitHub Packages:
- Registry: `https://npm.pkg.github.com`
- Authentication is handled via GitHub Actions using `GITHUB_TOKEN`
