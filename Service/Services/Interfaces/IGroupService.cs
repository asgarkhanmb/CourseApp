using Domain.Models;
using Repository.DTOs.GroupDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        Task<List<GroupAndEducationDto>> GetAllWithEducationAsync();
        Task<List<Group>> SortWithCapacityAsync(string text);
        Task<List<Group>> GetGroupByEducationIdAsync(int id);

    }
}
