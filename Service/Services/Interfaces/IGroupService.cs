

using Domain.Models;
using Repository.Data;
using Repository.DTOs.GroupDTOs;



namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        
        Task CreateAsync(Group entity);
        Task UpdateAsync(Group entity);
        Task DeleteAsync(Group entity);
        Task<Group> GetByIdAsync(int id);
        Task<List<Group>> GetAllAsync();
        Task<List<Group>> SearchByNameAsync(string searchText);
        Task<Group> GetByNameAsync(string name);

        Task<List<Group>> SortWithCapacityAsync(string text);
        Task<List<Group>> GetGroupByEducationIdAsync(int id);

    }
}
