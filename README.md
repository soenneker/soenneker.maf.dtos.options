[![](https://img.shields.io/nuget/v/soenneker.maf.dtos.options.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.maf.dtos.options/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.maf.dtos.options/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.maf.dtos.options/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.maf.dtos.options.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.maf.dtos.options/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.maf.dtos.options/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.maf.dtos.options/actions/workflows/codeql.yml)

# Soenneker.Maf.Dtos.Options

Options for creating a Microsoft Agent Framework `AIAgent` instance.

## Install

```bash
dotnet add package Soenneker.Maf.Dtos.Options
```

## Usage

```csharp
var options = new MafOptions
{
    ModelId = "my-model",
    Endpoint = "https://api.example.com",
    ApiKey = configuration["AI_API_KEY"],
    RequestsPerMinute = 60,
    MaxTokens = 1_000,
    Temperature = 0.2,
    AgentFactory = static (value, cancellationToken) =>
        CreateAgentAsync(value, cancellationToken)
};
```

`MafOptions` only carries configuration. The rate-limit and generation fields are not enforced or applied by this package; the pool, cache, agent factory, or request pipeline consuming the options must do that work.

## What you get

- `MafOptions` — Options for creating a Microsoft Agent Framework `AIAgent` instance.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `MafOptions.ModelId` | Optional identifier for the model or agent configuration. | Optional identifier for the model or agent configuration. |
| `MafOptions.Endpoint` | Optional endpoint (if applicable). | Optional endpoint (if applicable). |
| `MafOptions.ApiKey` | Optional API key (if applicable). | Optional API key (if applicable). |
| `MafOptions.AgentFactory` | Delegate that creates an `AIAgent` instance. Required when adding an entry by options. | Delegate that creates an `AIAgent` instance. Required when adding an entry by options. |
| `MafOptions.RequestsPerSecond` | Maximum number of requests allowed per second. Used for rate limiting. | Maximum number of requests allowed per second. Used for rate limiting. |
| `MafOptions.RequestsPerMinute` | Maximum number of requests allowed per minute. Used for rate limiting. | Maximum number of requests allowed per minute. Used for rate limiting. |
| `MafOptions.RequestsPerDay` | Maximum number of requests allowed per day. Used for rate limiting. | Maximum number of requests allowed per day. Used for rate limiting. |
| `MafOptions.TokensPerDay` | Maximum number of tokens allowed per day (input + output). Used for quota control. | Maximum number of tokens allowed per day (input + output). Used for quota control. |
| `MafOptions.MaxTokens` | The maximum number of tokens the model is allowed to generate in a single response. | The maximum number of tokens the model is allowed to generate in a single response. |
| `MafOptions.Temperature` | Sampling temperature (0.0 - 2.0). Higher values produce more randomness; lower values are more deterministic. | Sampling temperature (0.0 - 2.0). Higher values produce more randomness; lower values are more deterministic. |

## Security

`ApiKey` is serializable. Do not log or persist populated options, and prefer loading secrets from a secret provider at runtime. `AgentFactory` is excluded from JSON serialization.
