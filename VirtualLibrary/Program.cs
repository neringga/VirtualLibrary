using System;
using System.Windows.Forms;
using VirtualLibrary.Forms;
using VirtualLibrary.Repositories;

namespace VirtualLibrary
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var opening = GetInitializedOpening();
            Application.Run(opening);
        }

        static Opening GetInitializedOpening()
        {
            var userRepository = new UserRepository(DataSources.Data.StaticDataSource._dataSource);
            return new Opening(userRepository);
        }
    }
}
