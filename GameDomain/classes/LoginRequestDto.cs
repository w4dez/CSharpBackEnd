namespace GameDomain;
using System.ComponentModel.DataAnnotations;
public class LoginRequestDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}