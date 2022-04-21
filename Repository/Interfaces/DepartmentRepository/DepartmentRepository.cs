using ConnectionProvider;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.DepartmentRepository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Department> GetDepartmentbyId(int Id)
        {
            var department = await _context.departments.FindAsync(Id);
            return department;
        }
    }
}
