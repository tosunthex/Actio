using System;
using Actio.Common.Exceptions;

namespace Actio.Services.Activities.Domains.Models
{
    public class Activity
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        protected Activity()
        {
        }

        public Activity(Guid id, string name, string category, string description, Guid userId, DateTime createdAt)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ActioException("empty_activity_name",$"Activity name can not be empty.");
            }
            
            Id = id;
            Category = category;
            Description = description;
            UserId = userId;
            CreatedAt = createdAt;
            Name = name.ToLowerInvariant();
        }
    }
}