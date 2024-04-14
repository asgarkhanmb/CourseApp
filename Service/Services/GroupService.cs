using Repository.Repositories.Interfaces;
using Repository.Repositories;
using Service.Services.Interfaces;

using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.DTOs.GroupDTOs;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepo;
        public GroupService()
        {
            _groupRepo = new GroupRepository();
        }

        public async Task CreateAsync(Group entity)
        {
            await _groupRepo.CreateAsync(entity);
        }

        public async Task DeleteAsync(Group entity)
        {
            await _groupRepo.DeleteAsync(entity);
        }
        public async Task<List<Group>> GetAllAsync()
        {
            return await _groupRepo.GetAllAsync();
        }

        public async Task<List<GroupAndEducationDto>> GetAllWithEducationAsync()
        {
            return await _groupRepo.GetAllWithEducationAsync();
        }

        public async Task<Group> GetByIdAsync(int id)
        {
            return await _groupRepo.GetByIdAsync(id);
        }

        public async Task<Group> GetByNameAsync(string name)
        {
            return await _groupRepo.GetByNameAsync(name);
        }

        public async Task<List<Group>> GetGroupByEducationIdAsync(int id)
        {
            return await _groupRepo.GetGroupByEducationIdAsync(id);
        }

        public async Task<List<Group>> SearchByNameAsync(string searchText)
        {
            return await _groupRepo.SearchByNameAsync(searchText);
        }

        public async Task<List<Group>> SortWithCapacityAsync(string text)
        {
            return await _groupRepo.SortWithCapacityAsync(text);
        }

        public async Task UpdateAsync(Group entity)
        {
            await _groupRepo.UpdateAsync(entity);
        }
    }
}
