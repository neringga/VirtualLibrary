using System;
using System.Windows.Forms;
using Unity;
using Unity.Injection;
using VirtualLibrary.DataSources;
using VirtualLibrary.DataSources.Data;
using VirtualLibrary.Forms;
using VirtualLibrary.Helpers;
using VirtualLibrary.Presenters;
using VirtualLibrary.Repositories;

namespace VirtualLibrary
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
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
            currentContainer.RegisterSingleton<IDataSource>(new InjectionFactory(o =>
            {
                return new LocalDataSource();
            }));

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

            // Helpers
            currentContainer.RegisterType<IInputValidator>(new InjectionFactory(o =>
            {
                var userRepository = currentContainer.Resolve<IUserRepository>();
                return new InputValidator(userRepository);
            }));

            // Forms
            currentContainer.RegisterType<Registration>(new InjectionFactory(o =>
            {
                var userRepository = currentContainer.Resolve<IUserRepository>();
                var inputValidator = currentContainer.Resolve<InputValidator>();
                return new Registration(userRepository, inputValidator);
            }));

            currentContainer.RegisterType<Login>(new InjectionFactory(o =>
            {
                var userRepository = currentContainer.Resolve<IUserRepository>();
                var libraryForm = currentContainer.Resolve<Library>();
                return new Login(userRepository, libraryForm);
            }));

            currentContainer.RegisterType<BookActions>(new InjectionFactory(o =>
            {
                var takenBookPresenter = currentContainer.Resolve<TakenBookPresenter>();
                var libraryForm = currentContainer.Resolve<Library>();
                return new BookActions(takenBookPresenter, libraryForm);
            }));

            currentContainer.RegisterType<FaceRecognitionLogin>(new InjectionFactory(o =>
            {
                var dataSource = currentContainer.Resolve<IDataSource>();
                var libraryForm = currentContainer.Resolve<Library>();
                return new FaceRecognitionLogin(dataSource, libraryForm);
            }));

            currentContainer.RegisterType<Library>(new InjectionFactory(o =>
            {
                var takenBookPresenter = currentContainer.Resolve<TakenBookPresenter>();
                var dataSource = currentContainer.Resolve<IDataSource>();
                return new Library(takenBookPresenter, dataSource);
            }));

            currentContainer.RegisterType<Opening>(new InjectionFactory(o =>
            {
                var registrationForm = currentContainer.Resolve<Registration>();
                var loginForm = currentContainer.Resolve<Login>();
                var faceRecognitionForm = currentContainer.Resolve<FaceRecognitionLogin>();

                return new Opening(registrationForm, loginForm, faceRecognitionForm);
            }));

            // Presenters
            currentContainer.RegisterType<TakenBookPresenter>(new InjectionFactory(o =>
            {
                var bookRepository = currentContainer.Resolve<IBookRepository>();
                return new TakenBookPresenter(bookRepository);
            }));

            return currentContainer;
        }
    }
}