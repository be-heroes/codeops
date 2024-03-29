﻿using System.Text.Json.Serialization;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Project
{
    public sealed class ProjectDto : AdoDto
    {
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        [JsonPropertyName("url")]
        public Uri? Url { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }
    }
}
