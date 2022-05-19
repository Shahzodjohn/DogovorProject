namespace Repository
{
    public interface ICodeResetRepository
    {
        public Task<ResetPassword> GetUserCodebyId(int id);
        public Task<ResetPassword> Insert(string randomNumber, int UserId, DateTime date);
    }
}
