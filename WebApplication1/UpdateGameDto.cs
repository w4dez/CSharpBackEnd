using System.ComponentModel.DataAnnotations;

public class UpdateGameDto
{
  [Required(ErrorMessage = "Title is required")]
  [StringLength(100, ErrorMessage = "The Title can be max 100 characters long ")]
  [RegularExpression(@"^[\S]*$", ErrorMessage = "Titile canot be consist only with spaces")]
  public string? Title { get; set; }
  [Required(ErrorMessage = "Genre is required.")]
  [StringLength(50, ErrorMessage = "Genre can be max 50 characters.")]
  [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Genre can contain only letters and spaces.")]
  public string? Genre { get; set; }
}