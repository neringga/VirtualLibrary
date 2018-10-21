using System.Data.Entity;

namespace VirtualLibrary.DataSources.Db
{
    public class LibraryDbContext : DbContext
    {
        //public DbSet<DbUser> Users;
        //public DbSet<DbBook> Books;

        public LibraryDbContext() : base()
        {
            // TODO: configure in app settings
            Database.Connection.ConnectionString = "Data Source=den1.mssql5.gear.host;User ID=libraryproject;Password=Mb19Z_2j?RvZ;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
    }
}
