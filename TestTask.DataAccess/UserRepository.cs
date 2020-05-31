using TestTask.DataAccess.Entities;

namespace TestTask.DataAccess
{
    public class UserRepository : BaseRepository<User>
    {
        private readonly TestTaskDbContext _dbContext;

        public UserRepository(TestTaskDbContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
