﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Actio.Services.Activities.Domains.Models;
using Actio.Services.Activities.Domains.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Actio.Services.Activities.Repositories
{
    public class ActivityRepository:IActivityRepository
    {
        private readonly IMongoDatabase _database;

        public ActivityRepository(IMongoDatabase database)
        {
            _database = database;
        }

        private IMongoCollection<Activity> Collection
            => _database.GetCollection<Activity>("Activities");
        
        public async Task<Activity> GetAsync(Guid id)
            => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(Activity activity)
            => await Collection.InsertOneAsync(activity);
    }
}