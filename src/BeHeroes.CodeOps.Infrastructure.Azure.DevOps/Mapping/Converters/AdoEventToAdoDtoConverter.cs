using AutoMapper;

using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Events;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Events.Build;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Events.Release;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Mapping.Converters
{
    public class AdoEventToAdoDtoConverter : ITypeConverter<AdoEvent, AdoDto>
    {
        private readonly IAdoClient _vstsClient;

        public AdoEventToAdoDtoConverter(IAdoClient vstsClient)
        {
            _vstsClient = vstsClient;
        }

        public AdoDto Convert(AdoEvent source, AdoDto destination, ResolutionContext context)
        {
            Guid? projectId;

            switch (source.EventType)
            {
                case BuildCompletedEvent.EventIdentifier:
                    var buildId = source.Resource?.GetProperty("id").GetInt32();
                    projectId = source.ResourceContainers?.GetProperty("project").GetProperty("id").GetGuid();

                    if(!projectId.HasValue || !buildId.HasValue)
                        return destination;

                    var fetchUpdatedBuildDtoTask = _vstsClient.GetBuild(projectId.Value.ToString(), buildId.Value);

                    fetchUpdatedBuildDtoTask.Wait();

                    if(fetchUpdatedBuildDtoTask?.Result != null)
                        return fetchUpdatedBuildDtoTask.Result;
                        
                    return destination;

                case ReleaseCreatedEvent.EventIdentifier:
                case ReleaseCompletedEvent.EventIdentifier:
                case ReleaseAbandonedEvent.EventIdentifier:
                case ReleaseApprovalPendingEvent.EventIdentifier:
                case ReleaseApprovalCompletedEvent.EventIdentifier:
                    var releaseId = source.Resource?.GetProperty("release").GetProperty("id").GetInt32();
                    projectId = source.Resource?.GetProperty("project").GetProperty("id").GetGuid();

                    if(!projectId.HasValue || !releaseId.HasValue)
                        return destination;

                    var fetchUpdatedReleaseDtoTask = _vstsClient.GetRelease(projectId.Value.ToString(), releaseId.Value);

                    fetchUpdatedReleaseDtoTask.Wait();

                    if(fetchUpdatedReleaseDtoTask?.Result != null)
                        return fetchUpdatedReleaseDtoTask.Result;

                    return destination;

                default:
                    return destination;
            }
        }
    }
}
