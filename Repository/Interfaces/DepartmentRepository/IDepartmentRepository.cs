namespace Repository.Interfaces.DepartmentRepository
{
    public interface IDepartmentRepository
    {
        public Task<Department> GetDepartmentbyId(int Id);
    }
}
