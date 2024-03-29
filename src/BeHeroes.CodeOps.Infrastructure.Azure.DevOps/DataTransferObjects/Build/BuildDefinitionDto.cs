﻿using System.Text.Json.Serialization;

using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Project;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Build
{
    public sealed class BuildDefinitionDto : AdoDto
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("project")]
        public ProjectDto? Project { get; set; }

        [JsonPropertyName("revision")]
        public int? Revision { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("uri")]
        public Uri? Uri { get; set; }

        [JsonPropertyName("queueStatus")]
        public string? QueueStatus { get; set; }

        [JsonPropertyName("tags")]
        public IEnumerable<string>? Tags { get; set; }
    }
}