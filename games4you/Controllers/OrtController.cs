using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace games4you.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrtController : ControllerBase
{
  private readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "../orts.json");


  private List<Ort> LoadOrts()
  {
    if (!System.IO.File.Exists(_filePath))
    {
      var defaultOrts = new List<Ort>
            {
                new Ort { Id = 1, Bezeichnung = "Zug", PLZ = 6330, },
                new Ort { Id = 2, Bezeichnung = "Zurich", PLZ = 6000 },
                new Ort { Id = 3, Bezeichnung = "Luzern", PLZ = 6300 }
            };
      SaveOrts(defaultOrts);
      return defaultOrts;
    }

    string json = System.IO.File.ReadAllText(_filePath);
    if (string.IsNullOrWhiteSpace(json)) return new List<Ort>();

    try
    {
      return JsonSerializer.Deserialize<List<Ort>>(json) ?? new List<Ort>();
    }
    catch (JsonException)
    {
      return new List<Ort>();
    }
  }

  private void SaveOrts(List<Ort> orts)
  {
    string json = JsonSerializer.Serialize(orts, new JsonSerializerOptions { WriteIndented = true });
    System.IO.File.WriteAllText(_filePath, json);
  }


  // 1. GET ALL (
  [HttpGet]
  public ActionResult<List<Ort>> GetAllOrts()
  {
    var orts = LoadOrts();
    return Ok(orts);
  }

  // 2. GET BY ID
  [HttpGet("{id}")]
  public ActionResult<Ort> GetById(int id)
  {
    var orts = LoadOrts();
    var ort = orts.FirstOrDefault(o => o.Id == id);

    if (ort == null) return NotFound();

    return Ok(ort);
  }

  // 3. POST (Create)
  [HttpPost]
  public ActionResult<Ort> CreateOrt([FromBody] CreateOrt createOrt)
  {
    var orts = LoadOrts();

    var nextId = 1;
    if (orts.Count > 0) nextId = orts.Max(o => o.Id) + 1;

    var newOrt = new Ort
    {
      Id = nextId,
      Bezeichnung = createOrt.Bezeichnung,
      PLZ = createOrt.PLZ ?? 0
    };

    orts.Add(newOrt);
    SaveOrts(orts);

    return Created($"/api/ort/{newOrt.Id}", newOrt);
  }

  // 4. PUT (Update)
  [HttpPut("{id}")]
  public ActionResult<Ort> UpdateOrt(int id, [FromBody] CreateOrt updateOrt)
  {
    var orts = LoadOrts();
    var ortToUpdate = orts.FirstOrDefault(o => o.Id == id);

    if (ortToUpdate == null) return NotFound();

    ortToUpdate.Bezeichnung = updateOrt.Bezeichnung;
    ortToUpdate.PLZ = updateOrt.PLZ ?? 0;

    SaveOrts(orts);

    return Ok(ortToUpdate);
  }

  // 5. DELETE
  [HttpDelete("{id}")]
  public IActionResult DeleteOrt(int id)
  {
    var orts = LoadOrts();
    var ortToDelete = orts.FirstOrDefault(o => o.Id == id);

    if (ortToDelete == null) return NotFound();

    orts.Remove(ortToDelete);
    SaveOrts(orts);

    return NoContent();
  }
  /// <summary>
  /// Retrieves all grades for the logged-in user.
  /// </summary>
  /// <returns>A list of all games in the system.</returns>
  /// <response code="200">Successful retrieval of games.</response>
  /// <response code="401">User is not authenticated.</response>
  [HttpGet("Use")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  public ActionResult<List<Ort>> GetOrt()
  {
    return GetOrt();
  }

}