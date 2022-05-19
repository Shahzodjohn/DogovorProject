﻿namespace Repository.Interfaces
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Role> GetRoleById(int Id)
        {
            var role = await _context.roles.FindAsync(Id);
            return role;
        }
    }
}
