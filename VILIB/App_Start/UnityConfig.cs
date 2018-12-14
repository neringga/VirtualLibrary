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
                var dataSource = container.Resolve<IAsyncDataSource>();
                return new BookRepository(dataSource);
            }));

            container.RegisterSingleton<IReviewRepository>(new InjectionFactory(o =>
            {
                var dataSource = container.Resolve<IAsyncDataSource>();
                return new ReviewRepository(dataSource);
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

            container.RegisterType<ReturnBookController>(new InjectionFactory(o =>
            {
                var takenBookPresenter = container.Resolve<TakenBookPresenter>();
                return new ReturnBookController(takenBookPresenter);
            }));

            container.RegisterType<BookController>(new InjectionFactory(o =>
            {
                var bookPresenter = container.Resolve<BookPresenter>();
                return new BookController(bookPresenter);
            }));

            container.RegisterType<BookHistoryController>(new InjectionFactory(o =>
            {
                var bookPresenter = container.Resolve<BookPresenter>();
                return new BookHistoryController(bookPresenter);
            }));

            container.RegisterType<HashtagController>(new InjectionFactory(o =>
            {
                var dataSource = container.Resolve<IAsyncDataSource>();
                var hashtagRepo = new HastagRepository(dataSource);
                return new HashtagController(hashtagRepo);
            }));

            container.RegisterType<GenreController>(new InjectionFactory(o =>
            {
                var dataSource = container.Resolve<IAsyncDataSource>();
                var genreRepo = new GenreRepository(dataSource);
                return new GenreController(genreRepo);
            }));

            container.RegisterType<FaceDetectionController>(new InjectionFactory(o =>
            {
                return new FaceDetectionController();
            }));

            container.RegisterType<ImageSavingController>(new InjectionFactory(o =>
            {
                var dataSource = container.Resolve<IAsyncDataSource>();
                return new ImageSavingController(dataSource);
            }));

            container.RegisterType<FaceRecognitionController>(new InjectionFactory(o =>
            {
                var dataSource = container.Resolve<IAsyncDataSource>();
                var controller = new FaceRecognitionController(dataSource);
                controller.OnLogin += container.Resolve<IUserRepository>().Login;
                return controller;
            }));

            container.RegisterType<ReviewController>(new InjectionFactory(o =>
            {
                var reviewRepository = container.Resolve<IReviewRepository>();
                var reviewPresenter = container.Resolve<ReviewPresenter>();
                return new ReviewController(reviewPresenter, reviewRepository);
            }));


            // Helpers & Presenters
            container.RegisterType<TakenBookPresenter>(new InjectionFactory(o =>
            {
                var bookRepository = container.Resolve<IBookRepository>();
                var warning = container.Resolve<BookTakingWarning>();
                var userPresenter = container.Resolve<UserPresenter>();
                //return new TakenBookPresenter(bookRepository, warning, userPresenter);
                return new TakenBookPresenter(bookRepository);
            }));

            container.RegisterType<BookPresenter>(new InjectionFactory(o =>
            {
                var bookRepository = container.Resolve<IBookRepository>();
                return new BookPresenter(bookRepository);
            }));

            container.RegisterType<ReviewPresenter>(new InjectionFactory(o =>
            {
                var reviewRepository = container.Resolve<IReviewRepository>();
                return new ReviewPresenter(reviewRepository);
            }));

            container.RegisterType<UserPresenter>(new InjectionFactory(o =>
            {
                var userRepository = container.Resolve<IUserRepository>();
                return new UserPresenter(userRepository);
            }));


            container.RegisterType<IInputValidator>(new InjectionFactory(o =>
            {
                var userRepository = container.Resolve<IUserRepository>();
                return new InputValidator(userRepository);
            }));

            return container;
        }

        private static bool Controller_OnLogin(object sender, LoginEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}