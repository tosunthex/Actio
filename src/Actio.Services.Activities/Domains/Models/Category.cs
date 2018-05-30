﻿using System;

namespace Actio.Services.Activities.Domains.Models
{
    public class Category
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }

        protected Category()
        {
            
        }

        public Category(string name)
        {
            Id = new Guid();
            Name = name.ToLowerInvariant();
        }
    }
}