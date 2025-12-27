# Java Project Details

A modern Java project that provides currency conversion functionality, demonstrating Maven build and package publishing workflows.

## Prerequisites

- Java >= 21
- Maven >= 3.8
- Git (for version control)

## Project Structure

```
.
├── pom.xml                                        # Maven project configuration
├── src/
│   ├── main/
│   │   └── java/
│   │       └── com/
│   │           └── example/
│   │               └── CurrencyConverter.java     # Main application class
│   └── test/
│       └── java/
│           └── com/
│               └── example/
│                   └── CurrencyConverterTest.java # Test suite
└── README.md                                      # Project README
```

## Configuration

The project uses Maven for configuration. Key settings are defined in `pom.xml`:

| Property                       | Value    | Description               |
|--------------------------------|----------|---------------------------|
| `maven.compiler.source`        | `25`     | Java source version       |
| `maven.compiler.target`        | `25`     | Java target version       |
| `project.build.sourceEncoding` | `UTF-8`  | Source file encoding      |
| `junit.version`                | `5.10.1` | JUnit version for testing |

