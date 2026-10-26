using Microsoft.AspNetCore.Mvc;

namespace TestProject2.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumController : ControllerBase
{
  private static readonly string[] AlbumNames =
  [
      "WLR", "DieLit", "Music", "Magnolia", "Future", "Purple", "SpaceCadets"
  ];

  [HttpGet(Name = "GetAlbum")]
  public IEnumerable<Album> Get()
  {
    return Enumerable.Range(1, 5).Select(index => new Album
    {
      DateOfRealese = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
      SoldCopies = Random.Shared.Next(-20, 55),
      AlbumName = AlbumNames[Random.Shared.Next(AlbumNames.Length)],
    })
    .ToArray();
  }
}