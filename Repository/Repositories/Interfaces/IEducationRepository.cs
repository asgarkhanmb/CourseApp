﻿using Domain.Models;
using Repository.DTOs.EducationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IEducationRepository:IBaseRepository<Education>
    {
        Task<List<Education>> SearchByNameAsync(string searchText);
        Task<Education> GetByNameAsync(string name);
        Task<List<EducationAndGroupsDto>> GetAllWithGroupAsync();
        Task<List<Education>> SortWithCreatedDateAsync(string text);

    }
}
