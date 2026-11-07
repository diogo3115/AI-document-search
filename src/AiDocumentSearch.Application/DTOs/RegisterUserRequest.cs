using System.ComponentModel.DataAnnotations;

namespace AiDocumentSearch.Application.DTOs;
public class RegisterUserRequest
{
    [Required]
    [EmailAddress]
    [MaxLength(254)]
    public string Email {get; set;} = string.Empty;

    [Required]
    [MinLength(12)]
    [MaxLength(128)]
    public string Password {get; set;} = string.Empty;

}