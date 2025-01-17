﻿using Domain.Models;
using Repository.DTOs.EducationDTOs;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;


namespace Service.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepo;
        public EducationService()
        {
            _educationRepo = new EducationRepository();
        }

        public async Task CreateAsync(Education entity)
        {
            await _educationRepo.CreateAsync(entity);
        }

        public async Task DeleteAsync(Education entity)
        {
            await _educationRepo.DeleteAsync(entity);
        }

        public async Task<List<Education>> GetAllAsync()
        {
            return await _educationRepo.GetAllAsync();
        }

        public async Task<Education> GetByIdAsync(int id)
        {
            return await _educationRepo.GetByIdAsync(id);
        }

        public async Task<Education> GetByNameAsync(string name)
        {
            return await _educationRepo.GetByNameAsync(name);
        }

        public async Task<List<EducationAndGroupsDto>> GetEducationWithGroupsAsync()
        {
            return await _educationRepo.GetAllWithGroupAsync();
        }

        public async Task<List<Education>> SearchByNameAsync(string searchText)
        {
            return await _educationRepo.SearchByNameAsync(searchText);
        }

        public async Task<List<Education>> SortWithCreatedDateAsync(string text)
        {
            return await _educationRepo.SortWithCreatedDateAsync(text);
        }

        public async Task UpdateAsync(Education entity)
        {
            await _educationRepo.UpdateAsync(entity);
        }

    }
}
