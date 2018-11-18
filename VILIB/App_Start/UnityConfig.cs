using Unity;
using Unity.Injection;
using Unity.Lifetime;
using VILIB.Controllers;
using VILIB.DataSources;
using VILIB.Helpers;
using VILIB.Presenters;
using VILIB.Repositories;
using VILIB.DataSources.Data;
using VirtualLibrary.DataSources.Db;

namespace VILIB
{
    public static class UnityConfig
    {
        public static UnityContainer RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterSingleton<DataSources.IDataSource>(
               new InjectionFactory(o => { return new LocalDataSource(); }));

            container.RegisterSingleton<IAsyncDataSource>(
              new InjectionFactory(o =>
              {
                  var dbContext = new LibraryDbContext();
                  return new DbDataSource(dbContext);
              }));

            container.RegisterSingleton<IUserRepository>(new InjectionFactory(o =>
            {
                var dataSource = container.Resolve<IAsyncDataSource>();
                return new UserRepository(dataSource);
            }));

            container.RegisterSingleton<IBookRepository>(new InjectionFactory(o =>
            {
                var dataSource = container.Resolve<DataSources.IDataSource>();
                return new BookRepository(dataSource);
            }));

            container.RegisterSingleton<ILibraryData>(new InjectionFactory(o =>
            {
                var userRepository = container.Resolve<IUserRepository>();
                var bookRepository = container.Resolve<IBookRepository>();
                return new LibraryData(userRepository, bookRepository);
            }));

            //Controllers
            container.RegisterType<UserRegistrationController>(new InjectionFactory(o =>
            {
                var userRepository = container.Resolve<IUserRepository>();
                var inputValidator = container.Resolve<IInputValidator>();
                return new UserRegistrationController(userRepository, inputValidator);
            }));

            container.RegisterType<BarcodeScannerController>(new InjectionFactory(o =>
            {
                var takenBookPresenter = container.Resolve<TakenBookPresenter>();
                var bookPresenter = container.Resolve<BookPresenter>();
                var scannerPresenter = container.Resolve<ScannerPresenter>();
                return new BarcodeScannerController(takenBookPresenter, bookPresenter, scannerPresenter);
            }));

            container.RegisterType<UserSignInController>(new InjectionFactory(o =>
            {
                var userRepository = container.Resolve<IUserRepository>();
                var controller = new UserSignInController(userRepository);
                controller.OnLogin += userRepository.Login;
                return controller;
            }));

            container.RegisterType<TakenBookController>(new InjectionFactory(o =>
            {
                var takenBookPresenter = container.Resolve<TakenBookPresenter>();
                var bookPresenter = container.Resolve<BookPresenter>();
                var scannerPresenter = container.Resolve<ScannerPresenter>();
                return new TakenBookController(takenBookPresenter, bookPresenter, scannerPresenter);
            }));

            container.RegisterType<BookController>(new InjectionFactory(o =>
            {
                var bookPresenter = container.Resolve<BookPresenter>();
                return new BookController(bookPresenter);
            }));

            container.RegisterType<FaceDetectionController>(new InjectionFactory(o =>
            {
                return new FaceDetectionController(
                    System.Configuration.ConfigurationManager.AppSettings["faceDetectionTrainingFile"],
                    System.Configuration.ConfigurationManager.AppSettings["faceImagesPerUser"]);
            }));


            // Helpers & Presenters
            container.RegisterType<TakenBookPresenter>(new InjectionFactory(o =>
            {
                var bookRepository = container.Resolve<IBookRepository>();
                return new TakenBookPresenter(bookRepository);
            }));

            container.RegisterType<BookPresenter>(new InjectionFactory(o =>
            {
                var bookRepository = container.Resolve<IBookRepository>();
                return new BookPresenter(bookRepository);
            }));

            container.RegisterType<IUserPresenter, UserPresenter>(new TransientLifetimeManager());


            container.RegisterType<IInputValidator>(new InjectionFactory(o =>
            {
                var userRepository = container.Resolve<IUserRepository>();
                return new InputValidator(userRepository);
            }));

            return container;
        }
    }
}