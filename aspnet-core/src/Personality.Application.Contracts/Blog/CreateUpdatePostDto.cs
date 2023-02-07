using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Personality.Blog;

public class CreateUpdatePostDto
{
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(250)]
    public string Title { get; set; }
    
    [Required]
    [MaxLength(350)]
    public string Slug { get; set; }
    
    [Required]
    [MaxLength(250)]
    public string ImageIndexAddress { get; set; }
    
    [Required]
    [MaxLength(4000)]
    public string Content { get; set; }
    
    public BlogStatus Status { get; set; } = BlogStatus.Draft;
    
    [Required]
    public ICollection<TagPostDto> TagsPosts { get; set; }
    
    [Required]
    public ICollection<CategoryPostDto> CategoryPosts { get; set; }
}