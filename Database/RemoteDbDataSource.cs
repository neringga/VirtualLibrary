using VirtualLibrary.DataSources.Db;

namespace VirtualLibrary.DataSources
{
    class RemoteDbDataSource
    {
        private LibraryDbContext _dbContext;

        public RemoteDbDataSource(string connectionString)
        {
            _dbContext = new LibraryDbContext();
        }
    }
}
