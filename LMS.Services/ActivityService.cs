using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Models.Entities;
using LMS.Shared.DTOs.Create;
using LMS.Shared.DTOs.Read;
using LMS.Shared.DTOs.Update;
using Services.Contracts;

namespace LMS.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ActivityService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ActivityDto> GetActivityAsync(int activityId)
        {
            Activity? activity = await _uow.ActivityRepository.GetActivityByIdAsync(activityId);
            return _mapper.Map<ActivityDto>(activity);
        }

        public async Task<IEnumerable<ActivityTypeDto>> GetAllActivityTypes()
        {
            var activityTypes =  await _uow.ActivityTypeRepository.GetAllActivityTypesAsync();
            return _mapper.Map<IEnumerable<ActivityTypeDto>>(activityTypes);
        }

        public async Task DeleteActivityAsync(int id)
        {
            var courseToDelete = await _uow.ActivityRepository.GetActivityByIdAsync(id, true);
            if (courseToDelete == null) throw new KeyNotFoundException($"{id} not found.");
            _uow.ActivityRepository.Delete(courseToDelete);

            await _uow.CompleteAsync();
        }
        public async Task<ActivityDto> PutActivityAsync(int id, ActivityUpdateDto activity)
        {
            var activityToUpdate = await _uow.ActivityRepository.GetActivityByIdAsync(id, true);
            if (activityToUpdate == null) throw new KeyNotFoundException($"{id} not found.");

            activityToUpdate.Name = activity.Name;
            activityToUpdate.Description = activity.Description;
            activityToUpdate.StartDate = activity.StartDate;
            activityToUpdate.EndDate = activity.EndDate; 
            activityToUpdate.ActivityTypeId = activity.ActivityTypeId;

            await _uow.CompleteAsync();

            return _mapper.Map<ActivityDto>(activityToUpdate);
        }

        public async Task<ActivityDto> CreateActivityAsync(ActivityCreateDto dto)
        {
            // detta la jag till, så en activity kan skapas som kopplas t moduleid
            Activity activity = _mapper.Map<Activity>(dto);

            _uow.ActivityRepository.Create(activity);

            await _uow.CompleteAsync();

            return _mapper.Map<ActivityDto>(activity);
        }
    }
}
