﻿using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.ComponentModel.DataAnnotations;

namespace Backend.Core.Models.Users;


public class RefreshToken
{
    [Key] public Guid Id { get; set; }
    [Required] public string Token { get; set; } = string.Empty;       // Сам токен
    [Required] public DateTime ExpiryDate { get; set; }  // Время истечения
    [Required] public Guid UserId { get; set; }
    public User? User { get; set; }
}