using System;
using System.Windows.Forms;
using VirtualLibrary.DataSources.Data;
using VirtualLibrary.Forms;
using VirtualLibrary.Repositories;

namespace VirtualLibrary
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var opening = GetInitializedOpening();
            Application.Run(opening);
        }

        private static Opening GetInitializedOpening()
        {
            var userRepository = new UserRepository(StaticDataSource.DataSource);
            return new Opening(userRepository);
        }
    }
}