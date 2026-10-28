using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Text.Json;

namespace games4you.Controllers;

[ApiController]
[Route("api/[controller]")]

public class GenreController : ControllerBase
{
  private readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "../genres.json");

  private List <Genre> LoadGenres()
  {
    if (!System.IO.File.Exists(_filePath))
    {
      var defaultGenres = new List<Genre>
      {
        new Genre {id = 1}
      }
    }
  }
}