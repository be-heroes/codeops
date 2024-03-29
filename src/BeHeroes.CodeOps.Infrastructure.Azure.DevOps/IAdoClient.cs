﻿using BeHeroes.CodeOps.Abstractions.Protocols.Http;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Build;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Profile;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Project;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Release;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Shared;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps
{
    public interface IAdoClient : IHttpClient
    {
        Task<ReleaseDto?> GetRelease(string projectIdentifier, int releaseId, string? organization = default, CancellationToken cancellationToken = default);

        Task<ProjectDto?> GetProject(string projectIdentifier, string? organization = default, CancellationToken cancellationToken = default);

        Task<IEnumerable<ProjectDto>?> GetProjects(string? organization = default, CancellationToken cancellationToken = default);

        Task<OperationDto?> CreateProject(ProjectDto project, string? organization = default, CancellationToken cancellationToken = default);

        Task<OperationDto?> UpdateProject(ProjectDto project, string? organization = default, CancellationToken cancellationToken = default);

        Task<ProfileDto?> GetProfile(string profileIdentifier, CancellationToken cancellationToken = default);

        Task<BuildDefinitionDto?> GetBuildDefinition(string projectIdentifier, int definitionId, string? organization = default, CancellationToken cancellationToken = default);

        Task<string?> GetBuildDefinitionYaml(string projectIdentifier, int definitionId, string? organization = default, CancellationToken cancellationToken = default);

        Task<BuildDefinitionDto?> CreateBuildDefinition(string projectIdentifier, BuildDefinitionDto definition, string? organization = default, CancellationToken cancellationToken = default);

        Task<BuildDefinitionDto?> UpdateBuildDefinition(string projectIdentifier, BuildDefinitionDto definition, string? organization = default, CancellationToken cancellationToken = default);

        Task<BuildDto?> GetBuild(string projectIdentifier, int buildId, string? organization = default, CancellationToken cancellationToken = default);

        Task<IEnumerable<ChangeDto>?> GetBuildChanges(string projectIdentifier, int fromBuildId, int toBuildId, string? organization = default, CancellationToken cancellationToken = default);

        Task<IEnumerable<WorkItemDto>?> GetBuildWorkItemRefs(string projectIdentifier, int buildId, string? organization = default, CancellationToken cancellationToken = default);

        Task DeleteBuild(string projectIdentifier, int buildId, string? organization = default, CancellationToken cancellationToken = default);

        Task<BuildDto?> UpdateBuild(string projectIdentifier, BuildDto build, string? organization = default, CancellationToken cancellationToken = default);

        Task<BuildDto?> QueueBuild(string projectIdentifier, int definitionId, string? organization = default, CancellationToken cancellationToken = default);

        Task<BuildDto?> QueueBuild(string projectIdentifier, BuildDefinitionDto definition, string? organization = default, CancellationToken cancellationToken = default);
    }
}