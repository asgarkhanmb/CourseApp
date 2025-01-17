﻿using Domain.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Repository.Data;
using Repository.DTOs.GroupDTOs;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        private readonly AppDbContext _context;
        public GroupRepository()
        {
            _context = new AppDbContext();
        }

        public async Task<List<GroupAndEducationDto>> GetAllWithEducationAsync()
        {
            var groups = await _context.Groups.Include(m => m.Education).ToListAsync();
            var datas = groups.Select(m => new GroupAndEducationDto
            {
                Group = m.Name,
                Education = m.Education.Name
            });
            return datas.ToList();
        }

        public async Task<Group> GetByNameAsync(string name)
        {
            return await _context.Groups.FirstOrDefaultAsync(m => m.Name == name);
        }

        public async Task<List<Group>> SearchByNameAsync(string searchText)
        {
            return await _context.Groups.Where(m => m.Name.ToLower().Trim().Contains(searchText.ToLower().Trim())).ToListAsync();
        }
        public async Task Delete(int id)
        {
            await _context.Groups.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Group>> SortWithCapacityAsync(string text)
        {
            if (text.ToLower().Trim() == "ASC")
            {
                return await _context.Groups.OrderBy(m => m.Capacity).ToListAsync();
            }
            else if (text.ToLower().Trim() == "DESC")
            {
                return await _context.Groups.OrderByDescending(m => m.Capacity).ToListAsync();
            }
            else
            {
                throw new Exception("Incorrect Operation");
            }
        }

        public async Task<List<Group>> GetGroupByEducationIdAsync(int id)
        {
            return await _context.Groups.Where(m => m.EducationId == id).ToListAsync();
        }
    }
}
