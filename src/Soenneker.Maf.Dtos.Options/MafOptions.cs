using Microsoft.Agents.AI;
using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Maf.Dtos.Options;

/// <summary>
/// Options for creating a Microsoft Agent Framework <see cref="AIAgent"/> instance.
/// </summary>
public sealed class MafOptions
{
    /// <summary>
    /// Optional identifier for the model or agent configuration.
    /// </summary>
    [JsonPropertyName("modelId")]
    public string? ModelId { get; set; }

    /// <summary>
    /// Optional endpoint (if applicable).
    /// </summary>
    [JsonPropertyName("endpoint")]
    public string? Endpoint { get; set; }

    /// <summary>
    /// Optional API key (if applicable).
    /// </summary>
    [JsonPropertyName("apiKey")]
    public string? ApiKey { get; set; }

    /// <summary>
    /// Delegate that creates an <see cref="AIAgent"/> instance. Required when adding an entry by options.
    /// </summary>
    [JsonIgnore]
    public Func<MafOptions, CancellationToken, ValueTask<AIAgent>>? AgentFactory { get; set; }

    // ---------- Rate limits (usage windows) ----------

    /// <summary>
    /// Maximum number of requests allowed per second. Used for rate limiting.
    /// </summary>
    [JsonPropertyName("requestsPerSecond")]
    public int? RequestsPerSecond { get; set; }

    /// <summary>
    /// Maximum number of requests allowed per minute. Used for rate limiting.
    /// </summary>
    [JsonPropertyName("requestsPerMinute")]
    public int? RequestsPerMinute { get; set; }

    /// <summary>
    /// Maximum number of requests allowed per day. Used for rate limiting.
    /// </summary>
    [JsonPropertyName("requestsPerDay")]
    public int? RequestsPerDay { get; set; }

    /// <summary>
    /// Maximum number of tokens allowed per day (input + output). Used for quota control.
    /// </summary>
    [JsonPropertyName("tokensPerDay")]
    public int? TokensPerDay { get; set; }

    // ---------- Generation parameters (applied per request) ----------

    /// <summary>
    /// The maximum number of tokens the model is allowed to generate in a single response.
    /// </summary>
    [JsonPropertyName("maxTokens")]
    public int? MaxTokens { get; set; }

    /// <summary>
    /// Sampling temperature (0.0 - 2.0). Higher values produce more randomness; lower values are more deterministic.
    /// </summary>
    [JsonPropertyName("temperature")]
    public double? Temperature { get; set; }
}
