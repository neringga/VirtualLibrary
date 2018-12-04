using Database.Db;
using System.Data.Entity;

namespace VirtualLibrary.DataSources.Db
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbBook> Books { get; set; }

        public DbSet<DbGenre> Genres { get; set; }
        public DbSet<DbHashtag> Hashtags { get; set; }

        public LibraryDbContext() : base()
        {
            // Manually setting the connection string to the database.
            // It is set in the app config but please uncomment this line if connection string retrieval fails for some reason.
            // Database.Connection.ConnectionString = "Data Source=den1.mssql5.gear.host;User ID=libraryproject;Password=Mb19Z_2j?RvZ;Initial Catalog=master;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Database.Connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True";

        }
    }
}
