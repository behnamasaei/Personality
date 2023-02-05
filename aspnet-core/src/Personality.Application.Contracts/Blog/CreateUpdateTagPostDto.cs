using System;
using System.ComponentModel.DataAnnotations;

namespace Personality.Blog;

public class CreateUpdateTagPostDto
{
    [Required]
    public Guid PostId { get; set; }
    [Required]
    public Guid TagId { get; set; }
}