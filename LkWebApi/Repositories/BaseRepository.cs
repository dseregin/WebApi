namespace LkWebApi.Repositories
{
    public abstract class BaseRepository
    {
        static BaseRepository()
        {
            _dbSet = new DbSet();
        }
        protected static DbSet _dbSet;
    }
}
