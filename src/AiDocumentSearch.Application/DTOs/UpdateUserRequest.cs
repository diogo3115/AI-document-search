using System.ComponentModel.DataAnnotations;

namespace AiDocumentSearch.Application.DTOs;

public class UpdateUserRequest
{
    [Required]
    [EmailAddress]
    [MaxLength(254)]
    public string Email {set; get;} = string.Empty;
}