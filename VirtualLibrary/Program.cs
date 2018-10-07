using System;
using System.Windows.Forms;
using Unity;
using Unity.Injection;
using VirtualLibrary.DataSources;
using VirtualLibrary.DataSources.Data;
using VirtualLibrary.Forms;
using VirtualLibrary.Helpers;
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

            currentContainer.RegisterSingleton<IDataSource>(new InjectionFactory(o =>
            {
                return new LocalDataSource();
            }));

            currentContainer.RegisterSingleton<IUserRepository>(new InjectionFactory(o =>
            {
                var dataSource = currentContainer.Resolve<IDataSource>();
                return new UserRepository(dataSource);
            }));

            currentContainer.RegisterType<IInputValidator>(new InjectionFactory(o =>
            {
                var userRepository = currentContainer.Resolve<IUserRepository>();
                return new InputValidator(userRepository);
            }));

            currentContainer.RegisterType<Registration>(new InjectionFactory(o =>
            {
                var userRepository = currentContainer.Resolve<IUserRepository>();
                var inputValidator = currentContainer.Resolve<InputValidator>();
                return new Registration(userRepository, inputValidator);
            }));

            currentContainer.RegisterType<Login>(new InjectionFactory(o =>
            {
                var userRepository = currentContainer.Resolve<IUserRepository>();
                return new Login(userRepository);
            }));

            currentContainer.RegisterType<Opening>(new InjectionFactory(o =>
            {
                var registrationForm = currentContainer.Resolve<Registration>();
                var loginForm = currentContainer.Resolve<Login>();

                return new Opening(registrationForm, loginForm);
            }));

            return currentContainer;
        }
    }
}