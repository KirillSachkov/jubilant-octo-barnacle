using AutoMapper;
using Grpc.Net.Client;

namespace CommandsService.SyncDataServices;

public class PlatformDataClient : IPlatformDataClient
{
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public PlatformDataClient(IConfiguration configuration, IMapper mapper)
    {
        _configuration = configuration;
        _mapper = mapper;
    }
    
    public IEnumerable<Platform> ReturnAllPlatforms()
    {
        var channel = GrpcChannel.ForAddress(_configuration["GrpcPlatform"] ?? string.Empty);
    }
}