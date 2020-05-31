using TestTask.DataAccess.Entities;

namespace TestTask.DataAccess
{
    public class LogRepository : BaseRepository<Log>
    {
        private readonly TestTaskDbContext _dbContext;

        public LogRepository(TestTaskDbContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
