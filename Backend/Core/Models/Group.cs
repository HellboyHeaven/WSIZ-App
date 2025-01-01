﻿using Backend.Core.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Backend.Core.Models;

[Index(nameof(Name), IsUnique = true)]
public class Group
{
    [Key] public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Student> Students { get; set; } = new List<Student>();
    public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    [Required] public Subject? Subject { get; set; }
}