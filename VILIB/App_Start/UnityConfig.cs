using System.Web.Mvc;
using System.Web.UI;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;
using VILIB.Controllers;
using VILIB.DataSources;
using VILIB.Model;
using VILIB.View;
using VILIB.Helpers;
using VILIB.Presenters;
using VILIB.Repositories;

namespace VILIB
{
    public static class UnityConfig
    {
        public static UnityContainer RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterSingleton<DataSources.IDataSource>(
               new InjectionFactory(o => { return new LocalDataSource(); }));

            container.RegisterSingleton<IUserRepository>(new InjectionFactory(o =>
            {
                var dataSource = container.Resolve<DataSources.IDataSource>();
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
            container.RegisterType<UserController>(new InjectionFactory(o =>
            {
                var userRepository = container.Resolve<IUserRepository>();
                var inputValidator = container.Resolve<IInputValidator>();
                return new UserController(userRepository, inputValidator);
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

            container.RegisterType<IExceptionLogger>(new InjectionFactory(o =>
            {
                return new ExceptionToFileLogger();
            }));

            return container;
        }
    }
}