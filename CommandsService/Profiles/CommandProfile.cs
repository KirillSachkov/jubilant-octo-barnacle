using AutoMapper;
using CommandsService.Dtos;

namespace CommandsService.Profiles;

public class CommandProfile : Profile
{
    public CommandProfile()
    {
        CreateMap<Platform, PlatformReadDto>();
        CreateMap<CommandCreateDto, Command>();
        CreateMap<Command, CommandReadDto>();
    }
}
