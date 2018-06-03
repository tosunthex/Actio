﻿using System;
using System.Threading.Tasks;
using Actio.Common.Exceptions;
using Actio.Services.Activities.Domains.Models;
using Actio.Services.Activities.Domains.Repositories;

namespace Actio.Services.Activities.Services
{
    public class ActivityService:IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ActivityService(IActivityRepository activityRepository,ICategoryRepository categoryRepository)
        {
            _activityRepository = activityRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task AddAsync(Guid id, Guid userId, string category, string name, string description, DateTime createdAt)
        {
            var activityCategory = await _categoryRepository.GetAsync(name);
            if (activityCategory == null)
            {
                throw new ActioException("category_not_found",$"Category:'{category} was not found'");
            }

            var activity = new Activity(id, name,category,description,userId,createdAt);
            await _activityRepository.AddAsync(activity);
        }
    }
}