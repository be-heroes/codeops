﻿using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace BeHeroes.CodeOps.Infrastructure.EntityFramework
{
    public class EntityContextOptions
    {
        [Required]
        public IConfigurationSection? ConnectionStrings { get; set; }

        public bool EnableAutoMigrations { get; set; } = false;
    }
}
