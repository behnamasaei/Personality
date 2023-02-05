using System.ComponentModel.DataAnnotations;

namespace Personality.Blog;

public class CreateUpdateCategoryDto
{
    [Required]
    [StringLength(200)]
    public string Name { get; set; }
    [Required]
    [StringLength(250)]
    public string Slug { get; set; }
    public BlogStatus Status { get; set; } = BlogStatus.Publish;
}