﻿using System;
using System.Windows.Input;

namespace Actio.Common.Events
{
    public class ActivityCreated:IAuthenticatedEvent
    {
        public Guid UserId { get;  }
        public Guid Id { get;  }
        public string Category { get;  }
        public string Name { get;  }
        public string Description { get;  }
        public DateTime CreatedAt { get;  }

        protected ActivityCreated()
        {
        }

        public ActivityCreated(Guid userId, Guid id, string category, string name, string description, DateTime createdAt)
        {
            UserId = userId;
            Id = id;
            Category = category;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
        }
    }
}