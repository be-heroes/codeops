﻿using System.Text.Json.Serialization;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Profile
{
    public sealed class ProfileDto : AdoDto
    {
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        [JsonPropertyName("displayName")]
        public string? Name { get; set; }

        [JsonPropertyName("publicAlias")]
        public Guid? Alias { get; set; }

        [JsonPropertyName("emailAddress")]
        public string? Email { get; set; }
    }
}