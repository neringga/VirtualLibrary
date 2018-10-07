namespace VirtualLibrary.DataSources.Data
{
    internal class StaticDataSource
    {
        public static LocalDataSource DataSource = new LocalDataSource();
        public static string CurrUser;
    }
}