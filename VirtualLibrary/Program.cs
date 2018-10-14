using System;
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

            currentContainer.RegisterType<FaceRecognitionLogin>(new InjectionFactory(o =>
            {
                var libraryForm = currentContainer.Resolve<Library>();
                return new FaceRecognitionLogin(libraryForm);
            }));

            currentContainer.RegisterType<Registration>(new InjectionFactory(o =>
            {
                var libraryData = currentContainer.Resolve<ILibraryData>();
                var inputValidator = currentContainer.Resolve<InputValidator>();
                return new Registration(libraryData, inputValidator);
            }));

            currentContainer.RegisterType<Login>(new InjectionFactory(o =>
            {
                var libraryData = currentContainer.Resolve<ILibraryData>();
                var libraryForm = currentContainer.Resolve<Library>();
                return new Login(libraryData, libraryForm);
            }));

            currentContainer.RegisterType<Library>(new InjectionFactory(o =>
            {
                var libraryData = currentContainer.Resolve<ILibraryData>();
                var takenBookPresenter = currentContainer.Resolve<TakenBookPresenter>();
                return new Library(takenBookPresenter, libraryData);
            }));

            currentContainer.RegisterType<BookActions>(new InjectionFactory(o =>
            {
                var libraryData = currentContainer.Resolve<ILibraryData>();
                var libraryForm = currentContainer.Resolve<Library>();
                var takenBookPresenter = currentContainer.Resolve<TakenBookPresenter>();
                return new BookActions(takenBookPresenter, libraryForm, libraryData);
            }));

            currentContainer.RegisterType<Opening>(new InjectionFactory(o =>
            {
                var registrationForm = currentContainer.Resolve<Registration>();
                var loginForm = currentContainer.Resolve<Login>();
                var faceRecognitionForm = currentContainer.Resolve<FaceRecognitionLogin>();

                return new Opening(registrationForm, loginForm, faceRecognitionForm);
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