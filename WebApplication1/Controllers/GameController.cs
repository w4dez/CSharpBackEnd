using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
  [HttpGet(Name = "GetGameDto.cs")]
  public IEnumerable<GameDto> Get()
  {
    return new List<GameDto>
        {
            new GameDto
            {
                Id = 1,
                Title = "Cs:go",
                Genre = "Shooter"
            },
            new GameDto
            {
              Id = 2,
              Title = "The Last of Us Part I",
              Genre = "Adventure"
            },
            new GameDto
            {
              Id = 3,
              Title = "GTA 6",
              Genre = "Open World Adventure"
            },
            new GameDto
            {
              Id = 4,
              Title = "Dota 2",
              Genre = "Multiplayer online battle arena"
            }
        };
  }
}
