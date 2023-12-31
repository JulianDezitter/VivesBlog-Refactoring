﻿using System.ComponentModel.DataAnnotations;

namespace VivesBlog.Models;

public class Article
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    [Display(Name = "Author")]
    public int AuthorId { get; set; }

    public Person? Author { get; set; }

    public DateTime CreatedDate { get; set; }
}