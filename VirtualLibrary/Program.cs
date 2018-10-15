﻿using System;
using System.Windows.Forms;
using Unity;
using Unity.Injection;
using VirtualLibrary.DataSources;
using VirtualLibrary.Forms;
using VirtualLibrary.Helpers;
using VirtualLibrary.Presenters;
using VirtualLibrary.Repositories;

namespace VirtualLibrary
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var unityContainer = BuildContainer();

            Application.Run(unityContainer.Resolve<Opening>());
        }


        public static IUnityContainer BuildContainer()

        {
            var currentContainer = new UnityContainer();

            // Data storage
            currentContainer.RegisterSingleton<IDataSource>(
                new InjectionFactory(o => { return new LocalDataSource(); }));

            currentContainer.RegisterSingleton<IUserRepository>(new InjectionFactory(o =>
            {
                var dataSource = currentContainer.Resolve<IDataSource>();
                return new UserRepository(dataSource);
            }));

            currentContainer.RegisterSingleton<IBookRepository>(new InjectionFactory(o =>
            {
                var dataSource = currentContainer.Resolve<IDataSource>();
                return new BookRepository(dataSource);
            }));

            currentContainer.RegisterSingleton<ILibraryData>(new InjectionFactory(o =>
            {
                var userRepository = currentContainer.Resolve<IUserRepository>();
                var bookRepository = currentContainer.Resolve<IBookRepository>();
                return new LibraryData(userRepository, bookRepository);
            }));

 

            // Helpers & Presenters
            currentContainer.RegisterType<TakenBookPresenter>(new InjectionFactory(o =>
            {
                var bookRepository = currentContainer.Resolve<IBookRepository>();
                return new TakenBookPresenter(bookRepository);
            }));

            currentContainer.RegisterType<IInputValidator>(new InjectionFactory(o =>
            {
                var userRepository = currentContainer.Resolve<IUserRepository>();
                return new InputValidator(userRepository);
            }));

            return currentContainer;
        }
    }
}