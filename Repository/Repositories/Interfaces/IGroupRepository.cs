using Domain.Models;
using Repository.DTOs.GroupDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IGroupRepository:IBaseRepository<Group>
    {
        Task<List<Group>> SearchByNameAsync(string searchText);
        Task<Group> GetByNameAsync(string name);
        Task<List<GroupAndEducationDto>> GetAllWithEducationAsync();

        Task<List<Group>> SortWithCapacityAsync(string text);
        Task<List<Group>> GetGroupByEducationIdAsync(int id);


    }
}
