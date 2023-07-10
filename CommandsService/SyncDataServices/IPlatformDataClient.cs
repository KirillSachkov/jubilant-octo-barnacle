namespace CommandsService.SyncDataServices;

public interface IPlatformDataClient
{
    IEnumerable<Platform> ReturnAllPlatforms();
}