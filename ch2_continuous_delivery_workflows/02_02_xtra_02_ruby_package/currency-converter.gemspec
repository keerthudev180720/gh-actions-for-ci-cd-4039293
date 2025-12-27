# frozen_string_literal: true

require_relative "lib/currency_converter/version"

Gem::Specification.new do |spec|
  spec.name          = "currency-converter"
  spec.version       = CurrencyConverter::VERSION
  spec.authors       = ["Your Name"]
  spec.email         = ["your.email@example.com"]

  spec.summary       = "A simple currency converter demonstrating Ruby gem build process"
  spec.description   = "A modern Ruby project that provides currency conversion functionality, demonstrating gem build and package publishing workflows."
  spec.homepage      = "https://github.com/OWNER/REPO"
  spec.license       = "MIT"
  spec.required_ruby_version = ">= 3.0.0"

  spec.metadata["allowed_push_host"] = "https://rubygems.pkg.github.com"
  spec.metadata["homepage_uri"] = spec.homepage
  spec.metadata["source_code_uri"] = "https://github.com/OWNER/REPO"
  spec.metadata["changelog_uri"] = "https://github.com/OWNER/REPO/blob/main/CHANGELOG.md"

  # Specify which files should be added to the gem when it is released.
  spec.files = Dir.chdir(__dir__) do
    `git ls-files -z`.split("\x0").reject do |f|
      (File.expand_path(f) == __FILE__) ||
        f.start_with?(*%w[bin/ test/ spec/ features/ .git .github appveyor Gemfile])
    end
  end
  spec.bindir        = "exe"
  spec.executables   = spec.files.grep(%r{\Aexe/}) { |f| File.basename(f) }
  spec.require_paths = ["lib"]

  # Development dependencies
  spec.add_development_dependency "rspec", "~> 3.12"
  spec.add_development_dependency "rake", "~> 13.0"
end
