using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepository _platformRepository;
    private readonly IMapper _mapper;

    public PlatformsController(IPlatformRepository platformRepository, IMapper mapper)
    {
        _platformRepository = platformRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        var platformItem = _platformRepository.GetAllPlatforms();

        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
    }

    [HttpGet("{id:int}", Name = "GetPlatformById")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
        var platformItem = _platformRepository.GetPlatformById(id);

        if (platformItem == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<PlatformReadDto>(platformItem));
    }

    [HttpPost]
    public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
    {
        var platformModel = _mapper.Map<Platform>(platformCreateDto);

        _platformRepository.CreatePlatform(platformModel);
        _platformRepository.SaveChanges();

        var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

        return CreatedAtRoute(nameof(GetPlatformById), new { platformReadDto.Id }, platformReadDto);
    }
}