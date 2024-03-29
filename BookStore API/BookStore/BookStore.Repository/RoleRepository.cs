﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class RoleRepository : BaseRepository
    {
        public ListResponse<Role> GetRoles(int pageIndex, int pageSize, string keyword)
        {
            keyword = keyword?.ToLower()?.Trim();
            var query = _context.Roles.Where(c => keyword == null || c.Name.ToLower().Contains(keyword)).AsQueryable();
            int totalReocrds = query.Count();
            List<Role> categories = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new ListResponse<Role>()
            {
                Records = categories,
                TotalRecords = totalReocrds,
            };
        }
    }
}
