# Ruby Project Details

A modern Ruby project that provides currency conversion functionality, demonstrating gem build and package publishing workflows.

## Prerequisites

- Ruby >= 3.0.0
- Bundler >= 2.0
- Git (for version control)

## Project Structure

```
.
├── currency-converter.gemspec                      # Gem specification
├── lib/
│   ├── currency_converter.rb                       # Main application class
│   └── currency_converter/
│       └── version.rb                              # Version definition
├── spec/
│   ├── currency_converter_spec.rb                  # Test suite
│   └── spec_helper.rb                              # RSpec configuration
└── README.md                                       # Project README
```

## Configuration

The project uses a gemspec file for configuration. Key settings are defined in `currency-converter.gemspec`:

| Property                    | Value        | Description                    |
|-----------------------------|--------------|--------------------------------|
| `required_ruby_version`     | `>= 3.0.0`   | Minimum Ruby version           |
| `devDependencies.rspec`     | `~> 3.12`    | RSpec version for testing      |
| `metadata.allowed_push_host`| GitHub Packages URL | Publishing registry |

## Versioning

The gem version is defined in `lib/currency_converter/version.rb` and uses the `GITHUB_RUN_NUMBER` environment variable:
- Format: `"0.0.#{ENV['GITHUB_RUN_NUMBER']}"`
- Example: `"0.0.123"` for run number 123
- Default: `"0.0.0"` if `GITHUB_RUN_NUMBER` is not set

## Publishing to GitHub Packages

The `allowed_push_host` metadata in the gemspec configures the gem to publish to GitHub Packages:
- Registry: `https://rubygems.pkg.github.com`
- Authentication is handled via GitHub Actions using `GITHUB_TOKEN`
