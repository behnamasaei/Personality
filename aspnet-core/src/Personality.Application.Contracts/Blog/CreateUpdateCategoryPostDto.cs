using System;
using System.ComponentModel.DataAnnotations;

namespace Personality.Blog;

public class CreateUpdateCategoryPostDto
{
    [Required]
    public Guid PostId { get; set; }
    [Required]
    public Guid CategoryId { get; set; }
}